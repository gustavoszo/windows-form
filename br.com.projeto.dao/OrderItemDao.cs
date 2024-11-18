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
    internal class OrderItemDao
    {

        private MySqlConnection _connection;

        public OrderItemDao()
        {
            _connection = ConnectionDb.GetConnection();
        }

        public void Create(OrderItem obj)
        {
            _connection.Open();
            MySqlTransaction transaction = null;

            try
            {
                transaction = _connection.BeginTransaction();

                string queryInsertOrderItem = @"INSERT INTO itensvendas(id_venda, id_produto, quantidade, subtotal)
                                VALUES(@id_venda, @id_produto, @quantidade, @subtotal)";

                MySqlCommand command = new MySqlCommand(queryInsertOrderItem, _connection, transaction);
                command.Parameters.AddWithValue("@id_venda", obj.Order.IdOrder);
                command.Parameters.AddWithValue("@id_produto", obj.Product.IdProduct);
                command.Parameters.AddWithValue("@quantidade", obj.Amount);
                command.Parameters.AddWithValue("@subtotal", obj.SubTotal);
                command.ExecuteNonQuery();

                string queryUpdateProductQuantityAvaiable = @"UPDATE produtos
                               SET qtd_estoque = @qtd 
                               WHERE id_produto = @id_produto";

                command = new MySqlCommand(queryUpdateProductQuantityAvaiable, _connection, transaction);
                command.Parameters.AddWithValue("@id_venda", obj.Product.QtyAvaiable);
                command.Parameters.AddWithValue("@id_produto", obj.Product.IdProduct);
                command.ExecuteNonQuery();

                transaction.Commit();

            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new ExceptionDb("Ocorreu um erro ao tentar salvar o item da venda: " + e.Message);
            }
            finally
            {
                _connection.Close();
            }

        }


    }
}
