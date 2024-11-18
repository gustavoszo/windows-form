using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Projeto_de_Vendas.br.com.projeto.db;
using Projeto_de_Vendas.br.com.projeto.exceptions;
using Projeto_de_Vendas.br.com.projeto.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_de_Vendas.br.com.projeto.dao
{
    internal class EmployeeDao
    {

        private MySqlConnection _connection;

        public EmployeeDao()
        {
            _connection = ConnectionDb.GetConnection();
        }

        public void Create(Employee obj)
        {

            MySqlTransaction transaction = null;
            _connection.Open();
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

                string getLastInsertIdQuery = "SELECT LAST_INSERT_ID()";
                command = new MySqlCommand(getLastInsertIdQuery, _connection);

                var result = command.ExecuteScalar();

                if (result != null)
                {
                    int addressId = Convert.ToInt32(result);
                    obj.Address.IdAddress = addressId;
                }

                string employeeQuery = @"INSERT INTO funcionarios(nome, cpf, email, senha, cargo, nivel_acesso, celular, id_endereco)
                                       VALUES(@nome, @cpf, @email, @senha, @cargo, @nivel_acesso, @celular, @id_endereco)";

                command = new MySqlCommand(employeeQuery, _connection, transaction);
                command.Parameters.AddWithValue("@nome", obj.Name);
                command.Parameters.AddWithValue("@cpf", obj.Cpf);
                command.Parameters.AddWithValue("@email", obj.Email);
                command.Parameters.AddWithValue("@senha", obj.Password);
                command.Parameters.AddWithValue("@cargo", obj.Position);
                command.Parameters.AddWithValue("@nivel_acesso", obj.AccessLevel.ToString());
                command.Parameters.AddWithValue("@celular", obj.Phone);
                command.Parameters.AddWithValue("@id_endereco", obj.Address.IdAddress);
                command.ExecuteNonQuery();

                transaction.Commit();

            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new ExceptionDb("Ocorreu um erro ao tental salvar o Funcionario: " + e.Message);
            }
            finally
            {
                _connection.Close();
            }

        }

        public List<Employee> FindAll()
        {
            List<Employee> list = new List<Employee>();
            _connection.Open();

            try
            {
                string query = @"SELECT * FROM funcionarios F, enderecos E
                                WHERE F.id_endereco = E.id_endereco";

                MySqlCommand command = new MySqlCommand(query, _connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Employee()
                        {   
                            Name = reader.GetString("nome"),
                            Cpf = reader.GetString("cpf"),
                            Email = reader.GetString("email"),
                            Password = reader.GetString("senha"),
                            Phone = reader.GetString("celular"),
                            AccessLevel = (AccessLevel)Enum.Parse(typeof(AccessLevel), reader.GetString("nivel_acesso")),
                            Position = reader.GetString("cargo"),

                            Address = new Address
                            {
                                IdAddress = reader.GetInt32("id_endereco"),
                                Place = reader.GetString("logradouro"),
                                Number = reader.GetInt32("numero"),
                                City = reader.GetString("cidade"),
                                State = reader.GetString("estado")
                            }
                        }
                        );
                    }
                }
                return list;
            }
            catch (Exception e)
            {
                throw new ExceptionDb("Ocorreu um erro ao buscar os funcionários: " + e.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public void Update(Employee obj)
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

                string clientQuery = @"UPDATE funcionarios
                                     SET nome = @nome, email = @email, celular = @celular, cargo = @cargo
                                     WHERE cpf = @cpf";

                command = new MySqlCommand(clientQuery, _connection, transaction);
                command.Parameters.AddWithValue("@nome", obj.Name);
                command.Parameters.AddWithValue("@email", obj.Email);
                command.Parameters.AddWithValue("@celular", obj.Phone);
                command.Parameters.AddWithValue("@cpf", obj.Cpf);
                command.Parameters.AddWithValue("@cargo", obj.Position);
                command.ExecuteNonQuery();

                transaction.Commit();

            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new ExceptionDb("Ocorreu um erro ao tentar atualizar o Funcionário: " + e.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public void Delete(Employee obj)
        {
            _connection.Open();
            MySqlTransaction transaction = null;

            try
            {
                transaction = _connection.BeginTransaction();

                string deleteEmployeeQuery = @"DELETE FROM funcionarios WHERE cpf = @cpf";

                MySqlCommand command = new MySqlCommand(deleteEmployeeQuery, _connection, transaction);
                command.Parameters.AddWithValue("@cpf", obj.Cpf);
                command.ExecuteNonQuery();

                string deleteAddressQuery = @"DELETE FROM address WHERE id_endereco = @id_endereco";
                command = new MySqlCommand(deleteAddressQuery, _connection, transaction);
                command.Parameters.AddWithValue("@id_endereco", obj.Address.IdAddress);

                transaction.Commit();

            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new ExceptionDb("Ocorreu um errro ao tentar deletar o Funcionário: " + e.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public Employee FindByCpf(string cpf)
        {
            Employee employee = null;

            _connection.Open();
            try
            {

                string query = "SELECT * FROM funcionarios F, enderecos E " +
                               "WHERE F.id_endereco = E.id_endereco AND " +
                               "F.cpf = @cpf";

                MySqlCommand command = new MySqlCommand(query, _connection);
                command.Parameters.AddWithValue("@cpf", cpf);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        employee = new Employee
                        {
                            Name = reader.GetString("nome"),
                            Cpf = reader.GetString("cpf"),
                            Email = reader.GetString("email"),
                            Phone = reader.GetString("celular"),
                            Password = reader.GetString("senha"),
                            Position = reader.GetString("cargo"),
                            AccessLevel = (AccessLevel)Enum.Parse(typeof(AccessLevel), reader.GetString("nivel_acesso")),
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

                return employee;
            }
            catch (Exception e)
            {
                throw new ExceptionDb("Ocorreu um erro ao buscar o funcionário pelo CPF: " + e.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public Employee FindByEmail(string email)
        {
            Employee employee = null;

            _connection.Open();
            try
            {
                string query = "SELECT * FROM funcionarios F, enderecos E " +
                               "WHERE F.id_endereco = E.id_endereco AND " +
                               "F.email = @email";

                MySqlCommand command = new MySqlCommand(query, _connection);
                command.Parameters.AddWithValue("@email", email);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        employee = new Employee
                        {
                            Name = reader.GetString("nome"),
                            Cpf = reader.GetString("cpf"),
                            Email = reader.GetString("email"),
                            Phone = reader.GetString("celular"),
                            Password = reader.GetString("senha"),
                            Position = reader.GetString("cargo"),
                            AccessLevel = (AccessLevel)Enum.Parse(typeof(AccessLevel), reader.GetString("nivel_acesso")),
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
                return employee;
            }
            catch(Exception e)
            {
                throw new ExceptionDb("Ocorreu um erro ao buscar o funcionário por email: " + e.Message);
            }
            finally
            {
                _connection.Close();
            }
            
        }

        public List<Employee> FindByName(string name)
        {
            _connection.Open();
            try
            {
                List<Employee> employees = new List<Employee>();

                string query = @"SELECT * FROM funcionarios F, enderecos E 
                                 WHERE F.id_endereco = E.id_endereco AND F.nome LIKE %@nome%";

                MySqlCommand command = new MySqlCommand(query, _connection);
                command.Parameters.AddWithValue("@nome", name);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employees.Add(new Employee 
                        {
                            Name = reader.GetString("nome"),
                            Cpf = reader.GetString("cpf"),
                            Email = reader.GetString("email"),
                            Phone = reader.GetString("celular"),
                            Password = reader.GetString("senha"),
                            Position = reader.GetString("cargo"),
                            AccessLevel = (AccessLevel)Enum.Parse(typeof(AccessLevel), reader.GetString("nivel_acesso")),
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

                return employees;
            }
            catch (Exception e)
            {
                throw new ExceptionDb("Ocorreu um erro ao buscar os funcionários pelo nome: " + e.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public List<Employee> FindAllByName(string name)
        {
            List<Employee> list = new List<Employee>();
            _connection.Open();

            try
            {
                string query = @"SELECT * FROM funcionarios F, enderecos E
                                WHERE F.id_endereco = E.id_endereco AND F.nome LIKE @nome";

                MySqlCommand command = new MySqlCommand(query, _connection);
                command.Parameters.AddWithValue("@nome", "%" + name + "%");

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Employee()
                        {
                            Name = reader.GetString("nome"),
                            Cpf = reader.GetString("cpf"),
                            Email = reader.GetString("email"),
                            Password = reader.GetString("senha"),
                            Phone = reader.GetString("celular"),
                            AccessLevel = (AccessLevel)Enum.Parse(typeof(AccessLevel), reader.GetString("nivel_acesso")),
                            Position = reader.GetString("cargo"),

                            Address = new Address
                            {
                                IdAddress = reader.GetInt32("id_endereco"),
                                Place = reader.GetString("logradouro"),
                                Number = reader.GetInt32("numero"),
                                City = reader.GetString("cidade"),
                                State = reader.GetString("estado")
                            }
                        }
                        );
                    }
                }
                return list;
            }
            catch (Exception e)
            {
                throw new ExceptionDb("Ocorreu um erro ao buscar os funcionários: " + e.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

    }
}
