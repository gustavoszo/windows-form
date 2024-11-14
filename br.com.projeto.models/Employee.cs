using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_de_Vendas.br.com.projeto.models
{
    internal class Employee : Person
    {

        public string Password { get; set; }
        public AccessLevel AccessLevel { get; set; } = AccessLevel.USER;
        public string Position;

        public Employee() { }

        public Employee(string name, string cpf, string email, string phone, Address address, string password, string position) : base(name, cpf, email, phone, address)
        {
            Password = password;
            AccessLevel = AccessLevel.USER;
            Position = position;
        }

    }
}
