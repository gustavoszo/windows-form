using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using Projeto_de_Vendas.br.com.projeto.db;
using Projeto_de_Vendas.br.com.projeto.exceptions;
using Projeto_de_Vendas.br.com.projeto.models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;
using Client = Projeto_de_Vendas.br.com.projeto.models.Client;

namespace Projeto_de_Vendas.br.com.projeto.dao
{
    internal class ClientDao
    {

        private MySqlConnection _connection; 

        public ClientDao()
        {
            _connection = ConnectionDb.GetConnection();
        }

        public void Create(Client obj)
        {
            MySqlTransaction transaction = null;

            try
            {
                _connection.Open();
                transaction = _connection.BeginTransaction();

                string addressQuery = @"INSERT INTO enderecos(logradouro, numero, cidade, estado)
                                  VALUES(@logradouro, @numero, @cidade, @estado)";

                MySqlCommand command = new MySqlCommand(addressQuery, _connection, transaction);
                command.Parameters.AddWithValue("@logradouro", obj.Address.Place);
                command.Parameters.AddWithValue("@numero", obj.Address.Number);
                command.Parameters.AddWithValue("@cidade", obj.Address.City);
                command.Parameters.AddWithValue("@estado", obj.Address.State);
                command.ExecuteNonQuery();

                string getLastInsertIdQuery = "SELECT LAST_INSERT_ID();";  // A consulta SQL que retorna o último ID inserido
                command = new MySqlCommand(getLastInsertIdQuery, _connection, transaction);

                // O método ExecuteScalar() serve para pegar o valor retornado pela consulta
                var result = command.ExecuteScalar();

                if (result != null)
                {
                    int addressId = Convert.ToInt32(result); // Converte para int o valor retornado
                    obj.Address.IdAddress = addressId;  
                }

                string clientQuery = @"INSERT INTO clientes(nome, cpf, email, celular, id_endereco)
                                     VALUES(@nome, @cpf, @email, @celular, @id_endereco)";

                command = new MySqlCommand(clientQuery, _connection, transaction);
                command.Parameters.AddWithValue("@nome", obj.Name);
                command.Parameters.AddWithValue("@cpf", obj.Cpf);
                command.Parameters.AddWithValue("@email", obj.Email);
                command.Parameters.AddWithValue("@celular", obj.Phone);
                command.Parameters.AddWithValue("@id_endereco", obj.Address.IdAddress);
                command.ExecuteNonQuery();

                transaction.Commit();

            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new ExceptionDb("Ocorreu um erro ao tentar salvar o Cliente: " + e.Message);
            }
            finally
            {
                _connection.Close();
            }

        }
        
        public List<Client> FindAll()
        {   
            List<Client> clients = new List<Client>();
            _connection.Open();
            try
            {

                string query = "SELECT * FROM clientes C" +
                      "INNER JOIN enderecos E USING(id_endereco)";

                MySqlCommand command = new MySqlCommand(query, _connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Client client = new Client
                        {
                            Name = reader.GetString("nome"),
                            Cpf = reader.GetString("cpf"),
                            Email = reader.GetString("email"),
                            Phone = reader.GetString("celular"),
                            Address = new Address
                            {
                                Place = reader.GetString("logradouro"),
                                Number = reader.GetInt32("numero"),
                                City = reader.GetString("cidade"),
                                State = reader.GetString("estado")
                            }
                        };

                        clients.Add(client);
                    }
                }
                return clients;
            }
            catch (Exception e)
            {
                throw new ExceptionDb("Ocorreu um erro ao buscar os clientes: " + e.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public void Update(Client obj)
        {
            _connection.Open();
            MySqlTransaction transaction = null;

            try
            {
                transaction = _connection.BeginTransaction();

                string addressQuery = @"UPDATE enderecos 
                                      SET logradouro = @logradouro, numero = @numero, cidade = @cidade, estado = @estado
                                      WHERE id_endereco = @id_endereco";

                MySqlCommand command = new MySqlCommand(addressQuery, _connection, transaction);
                command.Parameters.AddWithValue("@logradouro", obj.Address.Place);
                command.Parameters.AddWithValue("@numero", obj.Address.Number);
                command.Parameters.AddWithValue("@cidade", obj.Address.City);
                command.Parameters.AddWithValue("@estado", obj.Address.State);
                command.Parameters.AddWithValue("@id_endereco", obj.Address.IdAddress);
                command.ExecuteNonQuery();

                string clientQuery = @"UPDATE clientes
                                     SET nome = @nome, email = @email, celular = @celular
                                     WHERE cpf = @cpf";

                command = new MySqlCommand(clientQuery, _connection, transaction);
                command.Parameters.AddWithValue("@nome", obj.Name);
                command.Parameters.AddWithValue("@email", obj.Email);
                command.Parameters.AddWithValue("@celular", obj.Phone);
                command.Parameters.AddWithValue("@cpf", obj.Cpf);
                command.ExecuteNonQuery();

                transaction.Commit();

            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new ExceptionDb("Ocorreu um erro ao tentar atualizar o Cliente: " + e.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public void Delete(Client obj)
        {
            _connection.Open();
            MySqlTransaction transaction = null;

            try
            {
                transaction = _connection.BeginTransaction();

                string deleteClientQuery = @"DELETE FROM clientes WHERE cpf = @cpf";
                
                MySqlCommand command = new MySqlCommand(deleteClientQuery, _connection, transaction);
                command.Parameters.AddWithValue("@cpf", obj.Cpf);
                command.ExecuteNonQuery();

                string deleteAddressQuery = @"DELETE FROM address WHERE id_endereco = @id_endereco";
                command = new MySqlCommand(deleteAddressQuery, _connection, transaction);
                command.Parameters.AddWithValue("@id_endereco", obj.Address.IdAddress);

                transaction.Commit();

            }
            catch(Exception e)
            {
                transaction.Rollback();
                throw new ExceptionDb("Ocorreu um errro ao tentar deletar o Cliente " + e.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public Client FindByCpf(string cpf)
        {
            Client client = null;

            _connection.Open(); 
            try
            {

                string query = "SELECT * FROM clientes C, enderecos E " +
                               "WHERE C.id_endereco = E.id_endereco AND " +
                               "C.cpf = @cpf";

                MySqlCommand command = new MySqlCommand(query, _connection);
                command.Parameters.AddWithValue("@cpf", cpf);  
                
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read()) 
                    {
                        client = new Client
                        {
                            Name = reader.GetString("nome"),
                            Cpf = reader.GetString("cpf"),
                            Email = reader.GetString("email"),
                            Phone = reader.GetString("celular"),
                            Address = new Address
                            {
                                IdAddress = reader.GetInt32("id_endereco"),
                                Place = reader.GetString("logradouro"),
                                Number = reader.GetInt32("numero"),
                                City = reader.GetString("cidade"),
                                State = reader.GetString("estado")
                            }
                        };
                    }
                }

                return client;
            }
            catch (Exception e)
            {
                throw new ExceptionDb("Ocorreu um erro ao buscar o cliente pelo CPF: " + e.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public Client FindByEmail(string email)
        {
            Client client = null;

            _connection.Open();
            try
            {

                string query = "SELECT * FROM clientes C, enderecos E " +
                               "WHERE C.id_endereco = E.id_endereco AND " +
                               "C.email = @email";

                MySqlCommand command = new MySqlCommand(query, _connection);
                command.Parameters.AddWithValue("@email", email);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        client = new Client
                        {
                            Name = reader.GetString("nome"),
                            Cpf = reader.GetString("cpf"),
                            Email = reader.GetString("email"),
                            Phone = reader.GetString("celular"),
                            Address = new Address
                            {
                                IdAddress = reader.GetInt32("id_endereco"),
                                Place = reader.GetString("logradouro"),
                                Number = reader.GetInt32("numero"),
                                City = reader.GetString("cidade"),
                                State = reader.GetString("estado")
                            }
                        };
                    }
                }
                return client;
            }

            catch (Exception e)
            {
                throw new ExceptionDb("Ocorreu um erro ao tentar buscar o cliente por email: " + e.Message);
            }
            finally
            {
                _connection.Close();
            }
        }
        public List<Client> FindByName(string name)
        {
            _connection.Open();
            try
            {
                List<Client> clients = new List<Client>();

                string query = @"SELECT * FROM clientes C, enderecos E 
                               WHERE C.id_endereco = E.id_endereco AND C.nome LIKE %@nome%";

                MySqlCommand command = new MySqlCommand(query, _connection);
                command.Parameters.AddWithValue("@nome", name);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clients.Add(new Client
                        {
                            Name = reader.GetString("nome"),
                            Cpf = reader.GetString("cpf"),
                            Email = reader.GetString("email"),
                            Phone = reader.GetString("celular"),
                            Address = new Address
                            {
                                IdAddress = reader.GetInt32("id_endereco"),
                                Place = reader.GetString("logradouro"),
                                Number = reader.GetInt32("numero"),
                                City = reader.GetString("cidade"),
                                State = reader.GetString("estado")
                            }
                        });
                      
                    }
                }

                return clients;
            }
            catch (Exception e)
            {
                throw new ExceptionDb("Ocorreu um erro ao buscar o cliente pelo CPF: " + e.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public List<Client> FindAllByName(string name)
        {
            List<Client> clients = new List<Client>();
            _connection.Open();
            try
            {

                string query = "SELECT * FROM clientes C " +
                      "INNER JOIN enderecos E USING(id_endereco) " +
                      "WHERE C.nome LIKE @nome";

                MySqlCommand command = new MySqlCommand(query, _connection);
                command.Parameters.AddWithValue("@nome", "%" + name + "%");

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Client client = new Client
                        {
                            Name = reader.GetString("nome"),
                            Cpf = reader.GetString("cpf"),
                            Email = reader.GetString("email"),
                            Phone = reader.GetString("celular"),
                            Address = new Address
                            {
                                Place = reader.GetString("logradouro"),
                                Number = reader.GetInt32("numero"),
                                City = reader.GetString("cidade"),
                                State = reader.GetString("estado")
                            }
                        };

                        clients.Add(client);
                    }
                }
                return clients;

            }
            catch(Exception e)
            {
                throw new ExceptionDb("Ocorreu um erro ao buscar os clientes por nome: " + e.Message);
            }
            finally
            {
                _connection.Close();
            }
        }
    }

}
