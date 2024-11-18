using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_de_Vendas.br.com.projeto.models
{
    public class Address
    {
        public int IdAddress { get; set; }
        public string Place { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public Address() { }

        public Address(int idEndereco, string logradouro, int number, string city, string state)
        {
            IdAddress = idEndereco;
            Place = logradouro;
            Number = number;
            City = city;
            State = state;
        }

        public override string ToString()
        {
            return $"{Place}, {Number}";
        }
    }
}
