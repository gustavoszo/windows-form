using MySql.Data.MySqlClient;
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
    internal class ProductDao
    {
        private MySqlConnection _connection;

        public ProductDao()
        {
            _connection = ConnectionDb.GetConnection();
        }

        public void Create(Product obj)
        {
            _connection.Open();
            MySqlTransaction transaction = null;

            try
            {
                transaction = _connection.BeginTransaction();
          
                string query = @"INSERT INTO produtos(descricao, preco, qtd_estoque, cnpj_fornecedor)
                                VALUES(@descricao, @preco, @qtd_estoque, @cnpj_fornecedor)";

                MySqlCommand command = new MySqlCommand(query, _connection, transaction);
                command.Parameters.AddWithValue("@descricao", obj.Description);
                command.Parameters.AddWithValue("@preco", obj.Price);
                command.Parameters.AddWithValue("@qtd_estoque", obj.QtyAvaiable);
                command.Parameters.AddWithValue("@cnpj_fornecedor", obj.Provider.Cnpj);
                command.ExecuteNonQuery();

                transaction.Commit();

            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new ExceptionDb("Ocorreu um erro ao tentar salvar o Produto: " + e.Message);
            }
            finally
            {
                _connection.Close();
            }

        }

        public List<Product> FindAll()
        {
            List<Product> products = new List<Product>();
            _connection.Open();
            try
            {

                string query = "SELECT * FROM produtos P, fornecedores F " +
                      "WHERE P.cnpj_fornecedor = F.cnpj";

                MySqlCommand command = new MySqlCommand(query, _connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        products.Add(new Product() 
                        {
                            IdProduct = reader.GetInt32("id_produto"), 
                            Description = reader.GetString("descricao"),
                            Price = reader.GetDouble("preco"),
                            QtyAvaiable = reader.GetInt32("qtd_estoque"),
                            Provider = new Provider()
                            {
                                Name = reader.GetString("nome"),
                                Cnpj = reader.GetString("cnpj")
                            }
                        });
                    }
                }
                return products;
            }
            catch (Exception e)
            {
                throw new ExceptionDb("Ocorreu um erro ao buscar os produtos: " + e.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public void Update(Product obj)
        {
            _connection.Open();
            MySqlTransaction transaction = null;

            try
            {
                transaction = _connection.BeginTransaction();

                string query = @"UPDATE produtos 
                                      SET descricao = @descricao, preco = @preco, qtd_estoque = @qtd_estoque, cnpj_fornecedor = @cnpj_fornecedor
                                      WHERE id_produto = @id_produto";

                MySqlCommand command = new MySqlCommand(query, _connection, transaction);
                command.Parameters.AddWithValue("@descricao", obj.Description);
                command.Parameters.AddWithValue("@preco", obj.Price);
                command.Parameters.AddWithValue("@qtd_estoque", obj.QtyAvaiable);
                command.Parameters.AddWithValue("@cnpj_fornecedor", obj.Provider.Cnpj);
                command.Parameters.AddWithValue("@id_produto", obj.IdProduct);
                command.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new ExceptionDb("Ocorreu um erro ao tentar atualizar o Produto: " + e.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public void Delete(Product obj)
        {
            _connection.Open();
            MySqlTransaction transaction = null;

            try
            {
                transaction = _connection.BeginTransaction();

                string query = @"DELETE FROM produtos WHERE id_produto = @id_produto";

                MySqlCommand command = new MySqlCommand(query, _connection, transaction);
                command.Parameters.AddWithValue("@id_produto", obj.IdProduct);
                command.ExecuteNonQuery();

                transaction.Commit();

            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new ExceptionDb("Ocorreu um errro ao tentar deletar o Produto " + e.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public Product FindById(int id)
        {
            Product product = null;
            _connection.Open();
            try
            {

                string query = "SELECT * FROM produtos P, fornecedores F " +
                      "WHERE P.cnpj_fornecedor = F.cnpj AND p.id_produto = @id";

                MySqlCommand command = new MySqlCommand(query, _connection);
                command.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        product = new Product()
                        {
                            IdProduct = reader.GetInt32("id_produto"),
                            Description = reader.GetString("descricao"),
                            Price = reader.GetDouble("preco"),
                            QtyAvaiable = reader.GetInt32("qtd_estoque"),
                            Provider = new Provider()
                            {
                                Name = reader.GetString("nome"),
                                Cnpj = reader.GetString("cnpj")
                            }
                        };
                    }
                }
                return product;
            }
            catch (Exception e)
            {
                throw new ExceptionDb("Ocorreu um erro ao buscar o produto: " + e.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public List<Product> FindAllByDescription(string description)
        {
            List<Product> products = new List<Product>();
            _connection.Open();
            try
            {

                string query = "SELECT * FROM produtos P, fornecedores F " +
                      "WHERE P.cnpj_fornecedor = F.cnpj AND p.descricao LIKE @descricao";

                MySqlCommand command = new MySqlCommand(query, _connection);
                command.Parameters.AddWithValue("@descricao", "%" + description + "%");

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product()
                        {
                            IdProduct = reader.GetInt32("id_produto"),
                            Description = reader.GetString("descricao"),
                            Price = reader.GetDouble("preco"),
                            QtyAvaiable = reader.GetInt32("qtd_estoque"),
                            Provider = new Provider()
                            {
                                Name = reader.GetString("nome"),
                                Cnpj = reader.GetString("cnpj")
                            }
                        });
                    }
                }
                return products;
            }
            catch (Exception e)
            {
                throw new ExceptionDb("Ocorreu um erro ao buscar o produto: " + e.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public List<Product> FindAllByProvider(string cnpj)
        {
            List<Product> products = new List<Product>();
            _connection.Open();
            try
            {

                string query = "SELECT * FROM produtos P, fornecedores F " +
                      "WHERE P.cnpj_fornecedor = F.cnpj AND p.cnpj_fornecedor = @cnpj";

                MySqlCommand command = new MySqlCommand(query, _connection);
                command.Parameters.AddWithValue("@cnpj", cnpj);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product()
                        {
                            IdProduct = reader.GetInt32("id_produto"),
                            Description = reader.GetString("descricao"),
                            Price = reader.GetDouble("preco"),
                            QtyAvaiable = reader.GetInt32("qtd_estoque"),
                            Provider = new Provider()
                            {
                                Name = reader.GetString("nome"),
                                Cnpj = reader.GetString("cnpj")
                            }
                        });
                    }
                }
                return products;
            }
            catch (Exception e)
            {
                throw new ExceptionDb("Ocorreu um erro ao buscar os produtos: " + e.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

    }
}
