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
    internal class ProviderService
    {

        public ProviderDao ProviderDao { get; set; }
        public ProductService ProductService { get; set; }

        public ProviderService()
        {
            ProductService = new ProductService();
            ProductService.ProductDao = new ProductDao();
        }

        public void Create(Provider provider)
        {
            if (ProviderDao.FindByCnpj(provider.Cnpj) != null) throw new CnpjUniqueValidationException("CNPJ já cadastrado!");
            if (ProviderDao.FindByEmail(provider.Email) != null) throw new EmailUniqueValidationException("Email já cadastrado!");
            ProviderDao.Create(provider);
        }

        public List<Provider> FindAll()
        {
            return ProviderDao.FindAll();
        }

        public void Update(Provider provider)
        {
            Provider providerByEmail = ProviderDao.FindByEmail(provider.Email);
            if (providerByEmail != null && providerByEmail.Cnpj != provider.Cnpj) throw new EmailUniqueValidationException("E-mail já cadastrado");
            ProviderDao.Update(provider);
        }

        public void Delete(Provider provider)
        {
            if (ProductService.FindAllByProvider(provider.Cnpj).Count > 0) throw new ExceptionDb("O fornecedor possui produto(s) associados(s)");
            ProviderDao.Delete(provider);
        }

        public Provider FindByCnpj(string cpf)
        {
            return ProviderDao.FindByCnpj(cpf);
        }

        public List<Provider> FindAllByName(string name)
        {
            return ProviderDao.FindAllByName(name);
        }

    }
}
