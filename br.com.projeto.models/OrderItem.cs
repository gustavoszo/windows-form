using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_de_Vendas.br.com.projeto.models
{
    public class OrderItem
    {

        public int IdOrderItem { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
        public double SubTotal { get; set; }

        public OrderItem() { }

        public OrderItem(int idOrderItem, Order order, Product product, int amount, double subTotal)
        {
            IdOrderItem = idOrderItem;
            Order = order;
            Product = product;
            Amount = amount;
            SubTotal = subTotal;
        }

        public override string ToString()
        {
            return $"{Product} | {Amount} - R$ {SubTotal}";
        }

    }
}
