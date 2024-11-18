using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_de_Vendas.br.com.projeto.models
{
    public class Order
    {

        public int IdOrder { get; set; }
        public Client Client { get; set; }
        public DateTime Date { get; set; }
        public double Total { get; set; }
        public string Note { get; set; }
        
        public Order() { }

        public Order(int idOrder, Client client, DateTime date, double total, string note)
        {
            IdOrder = idOrder;
            Client = client;
            Date = date;
            Total = total;
            Note = note;
        }

        public override string ToString()
        {
            return $"{IdOrder} - R$ {Total}";
        }
    }
}
