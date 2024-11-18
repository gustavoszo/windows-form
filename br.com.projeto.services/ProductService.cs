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
    internal class ProductService
    {

        public ProductDao ProductDao { get; set; }

        public void Create(Product product)
        {
            ProductDao.Create(product);
        }

        public List<Product> FindAll()
        {
            return ProductDao.FindAll();
        }

        public void Update(Product product)
        {
            ProductDao.Update(product);
        }

        public void Delete(Product product)
        {
            ProductDao.Delete(product);
        }

        public Product FindById(int id)
        {
            return ProductDao.FindById(id);
        }

        public List<Product> FindAllByDescription(string description)
        {
            return ProductDao.FindAllByDescription(description);
        }

        public List<Product> FindAllByProvider(string cnpj)
        {
            return ProductDao.FindAllByProvider(cnpj);
        }

    }
}
