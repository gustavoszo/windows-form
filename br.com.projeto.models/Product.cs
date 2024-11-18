using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_de_Vendas.br.com.projeto.models
{
    public class Product
    {
        public int? IdProduct { set; get; }
        public string Description { set; get; }
        public double Price { set; get; }
        public int QtyAvaiable { set; get; }
        public Provider Provider { set; get; }

        public Product() { }

        public Product(string description, double price, int qtyAvaiable, Provider provider)
        {
            Description = description;
            Price = price;
            QtyAvaiable = qtyAvaiable;
            Provider = provider;
        }

        public override string ToString()
        {
            return Description;
        }
    }
}
