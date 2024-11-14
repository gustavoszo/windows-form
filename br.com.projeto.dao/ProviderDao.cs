using MySql.Data.MySqlClient;
using Projeto_de_Vendas.br.com.projeto.db;
using Projeto_de_Vendas.br.com.projeto.exceptions;
using Projeto_de_Vendas.br.com.projeto.models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace Projeto_de_Vendas.br.com.projeto.dao
{
    internal class ProviderDao
    {

        private MySqlConnection _connection;

        public ProviderDao()
        {
            _connection = ConnectionDb.GetConnection();
        }
        
        public void Create(Provider obj)
        {   
            _connection.Open();
            MySqlTransaction transaction = null;
            try
            {
                transaction = _connection.BeginTransaction();

                string addressQuery = @"INSERT INTO enderecos(logradouro, numero, cidade, estado)
                                  VALUES(@logradouro, @numero, @cidade, @estado)";

                MySqlCommand command = new MySqlCommand(addressQuery, _connection, transaction);
                command.Parameters.AddWithValue("@logradouro", obj.Address.Place);
                command.Parameters.AddWithValue("@numero", obj.Address.Number);
                command.Parameters.AddWithValue("@cidade", obj.Address.City);
                command.Parameters.AddWithValue("@estado", obj.Address.State);
                command.ExecuteNonQuery();

                string getLastInsertIdQuery = "SELECT LAST_INSERT_ID();";
                command = new MySqlCommand(getLastInsertIdQuery, _connection, transaction);

                var result = command.ExecuteScalar();

                if (result != null)
                {
                    int addressId = Convert.ToInt32(result);
                    obj.Address.IdAddress = addressId;
                }
                
                string providerQuery = @"INSERT INTO fornecedores(nome, cnpj, email, celular, id_endereco)
                                       VALUES(@nome, @cnpj, @email, @celular, @id_endereco)";

                command = new MySqlCommand(providerQuery, _connection, transaction);
                command.Parameters.AddWithValue("@nome", obj.Name);
                command.Parameters.AddWithValue("@email", obj.Email);
                command.Parameters.AddWithValue("@celular", obj.Phone);
                command.Parameters.AddWithValue("@cnpj", obj.Cnpj);
                command.Parameters.AddWithValue("@id_endereco", obj.Address.IdAddress);
                command.ExecuteNonQuery();

                transaction.Commit();
            }
            catch(Exception ex)
            { 
                transaction.Rollback();
                throw new ExceptionDb("Ocorreu um erro ao tentar cadastrar o Fornecedor: " + ex.Message);
            } 
            finally
            {
                _connection?.Close();
            }
        }

        public List<Provider> FindAll()
        {
            List<Provider> providers = new List<Provider>();
            _connection.Open();
            try
            {
                string query = "SELECT * FROM fornecedores F" +
                      "INNER JOIN enderecos E USING(id_endereco)";

                MySqlCommand command = new MySqlCommand(query, _connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        providers.Add(new Provider
                        {
                            Name = reader.GetString("nome"),
                            Cnpj = reader.GetString("cnpj"),
                            Email = reader.GetString("email"),
                            Phone = reader.GetString("celular"),
                            Address = new Address
                            {
                                Place = reader.GetString("logradouro"),
                                Number = reader.GetInt32("numero"),
                                City = reader.GetString("cidade"),
                                State = reader.GetString("estado")
                            }
                        });
                    }
                }
                return providers;
            }
            catch (Exception e)
            {
                throw new ExceptionDb("Ocorreu um erro ao buscar os fornecedores: " + e.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public void Update(Provider obj)
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
                command.Parameters.AddWithValue("@id_endereco", obj.Address.IdAddress);
                command.Parameters.AddWithValue("@logradouro", obj.Address.Place);
                command.Parameters.AddWithValue("@numero", obj.Address.Number);
                command.Parameters.AddWithValue("@cidade", obj.Address.City);
                command.Parameters.AddWithValue("@estado", obj.Address.State);
                command.ExecuteNonQuery();

                string providerQuery = @"UPDATE fornecedores
                                       SET nome = @nome, email = @email, celular = @celular
                                       WHERE cnpj = @cnpj";

                command = new MySqlCommand(providerQuery, _connection, transaction);
                command.Parameters.AddWithValue("@nome", obj.Name);
                command.Parameters.AddWithValue("@email", obj.Email);
                command.Parameters.AddWithValue("@celular", obj.Phone);
                command.Parameters.AddWithValue("@cnpj", obj.Cnpj);
                command.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new ExceptionDb("Ocorreu um erro ao tentar atualizar o Fornecedor: " + ex.Message);
            }
            finally
            {
                _connection?.Close();
            }
        }

        public Provider FindByCnpj(string cnpj)
        {
            Provider provider = null;
            _connection.Open();
            try
            {
                string query = @"SELECT * FROM fornecedores F, enderecos E
                               WHERE F.id_endereco = E.id_endereco AND F.cnpj = @cnpj";

                MySqlCommand command = new MySqlCommand(query, _connection);
                command.Parameters.AddWithValue("@cnpj", cnpj);
                
                using(MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        provider = new Provider
                        {
                            Name = reader.GetString("nome"),
                            Cnpj = reader.GetString("cnpj"),
                            Email = reader.GetString("email"),
                            Phone = reader.GetString("celular"),
                            Address = new Address
                            {
                                IdAddress = reader.GetInt32("id_endereco"),
                                Place = reader.GetString("logradouro"),
                                Number = reader.GetInt32("numero"),
                                City = reader.GetString("cidade"),
                                State = reader.GetString("estado"),
                            }
                        };
                    }
                }

                return provider;
            }
            catch(Exception e)
            {
                throw e;
                throw new ExceptionDb("Ocorreu um erro ao buscar o fornecedor pelo CNPJ: " + e.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public Provider FindByEmail(string email)
        {
            Provider provider = null;

            _connection.Open();
            try
            {
                string query = "SELECT * FROM fornecedores F, enderecos E " +
                               "WHERE F.id_endereco = E.id_endereco AND " +
                               "F.email = @email";

                MySqlCommand command = new MySqlCommand(query, _connection);
                command.Parameters.AddWithValue("@email", email);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        provider = new Provider
                        {
                            Name = reader.GetString("nome"),
                            Cnpj = reader.GetString("cnpj"),
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

                    }
                }
                return provider;
            }
            catch (Exception e)
            {
                throw new ExceptionDb("Ocorreu um erro ao buscar o fornecedor por email: " + e.Message);
            }
            finally
            {
                _connection.Close();
            }

        }

    }
}
