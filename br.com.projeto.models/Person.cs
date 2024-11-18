using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_de_Vendas.br.com.projeto.models
{
    public class Person
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public Address Address { get; set; }

        public Person() { }

        public Person(string name, string cpf, string email, string phone, Address address)
        {
            Name = name;
            Cpf = cpf;
            Email = email;
            Phone = phone;
            Address = address;
        }

        public string FullAddress
        {
            get
            {
                return $"{Address.Place}, {Address.Number}";
            }
        }

        public override string ToString()
        {
            return $"{Name} - {Email}";
        }
    }
}
