using Projeto_de_Vendas.br.com.projeto.dao;
using Projeto_de_Vendas.br.com.projeto.exceptions;
using Projeto_de_Vendas.br.com.projeto.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_de_Vendas.br.com.projeto.services
{
    internal class ClientService
    {

        public ClientDao ClientDao { get; set; }

        public void Create(Client client)
        {
            if (ClientDao.FindByCpf(client.Cpf) != null) throw new CpfUniqueValidationException("CPF já cadastrado!");
            if (ClientDao.FindByEmail(client.Email) != null) throw new EmailUniqueValidationException("E-mail já cadastrado!");
            ClientDao.Create(client);
        }

        public List<Client> FindAll()
        {
            return ClientDao.FindAll();
        }

        public void Update(Client client)
        {
            Client clientByEmail = ClientDao.FindByEmail(client.Email);
            if (clientByEmail != null && clientByEmail.Cpf != client.Cpf) throw new EmailUniqueValidationException("E-mail já cadastrado");
            ClientDao.Update(client);
        }

        public void Delete(Client client)
        {
            ClientDao.Delete(client);
        }

        public Client FindByCpf(string cpf)
        {
            return ClientDao.FindByCpf(cpf);
        }

        public List<Client> FindAllByName(string name)
        {
            return ClientDao.FindAllByName(name);
        }

    }
}
