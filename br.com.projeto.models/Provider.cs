using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_de_Vendas.br.com.projeto.models
{
    public class Provider
    {
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public Address Address { get; set; }

        public Provider() { }

        public Provider(string name, string cnpj, string email, string phone, Address address)
        {
            Name = name;
            Cnpj = cnpj;
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