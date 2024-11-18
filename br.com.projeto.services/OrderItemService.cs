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
    internal class OrderItemService
    {

        public OrderItemDao OrderItemDao { get; set; }
        public ProductService ProductService { get; set; }

        public void Create(OrderItem orderItem)
        {
            OrderItemDao.Create(orderItem);
        }

        public List<OrderItem> FindAllById(int id)
        {
            List<OrderItem> itens = OrderItemDao.FindAllByOrderId(id);
            itens.ForEach(i =>
            {
                i.Product = ProductService.FindById((int)i.Product.IdProduct);
            });
            return itens;
        }

    }
}
