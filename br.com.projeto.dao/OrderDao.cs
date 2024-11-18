using MySql.Data.MySqlClient;
using Projeto_de_Vendas.br.com.projeto.db;
using Projeto_de_Vendas.br.com.projeto.exceptions;
using Projeto_de_Vendas.br.com.projeto.models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_de_Vendas.br.com.projeto.dao
{
    internal class OrderDao
    {

        private MySqlConnection _connection;

        public OrderDao()
        {
            _connection = ConnectionDb.GetConnection();
        }

        public void Create(Order obj)
        {
            _connection.Open();
            MySqlTransaction transaction = null;

            try
            {
                transaction = _connection.BeginTransaction();

                string query = @"INSERT INTO vendas(cpf_cliente, data_venda, total_venda, observacao)
                                VALUES(@cpf_cliente, @data_venda, @total_venda, @observacao)";

                MySqlCommand command = new MySqlCommand(query, _connection, transaction);
                command.Parameters.AddWithValue("@cpf_cliente", obj.Client.Cpf);
                command.Parameters.AddWithValue("@data_venda", obj.Date);
                command.Parameters.AddWithValue("@total_venda", obj.Total);
                command.Parameters.AddWithValue("@observacoes", obj.Note);
                command.ExecuteNonQuery();

                transaction.Commit();

            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new ExceptionDb("Ocorreu um erro ao tentar salvar a venda: " + e.Message);
            }
            finally
            {
                _connection.Close();
            }

        }

        public Order FindLastInsertOrder()
        {
            Order order = null;
            _connection.Open();
            try
            {
                int id = 0;
                string query = @"SELECT MAX(id_venda) FROM vendas";

                MySqlCommand command = new MySqlCommand(query, _connection);
                var result = command.ExecuteScalar();

                if (result != null)
                {
                    id = Convert.ToInt32(result);
                }

                query = @"SELECT * FROM vendas WHERE id_venda = @id_venda";
                command = new MySqlCommand(query, _connection);
                command.Parameters.AddWithValue("@id_venda", id);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        order = new Order()
                        {
                            IdOrder = reader.GetInt32("id_order"),
                            Client = new Client()
                            {
                                Cpf = reader.GetString("cpf_cliente")
                            },
                            Date = DateTime.Parse(reader.GetString("data_venda")),
                            Note = reader.GetString("observacao"),
                            Total = reader.GetDouble("total")
                        };
                    }
                }
                return order;
            }
            catch (Exception e)
            {
                throw new ExceptionDb("Ocorreu um erro: " + e.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

    }
}
