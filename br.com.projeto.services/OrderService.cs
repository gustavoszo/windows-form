using Projeto_de_Vendas.br.com.projeto.dao;
using Projeto_de_Vendas.br.com.projeto.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_de_Vendas.br.com.projeto.services
{
    internal class OrderService
    {

        public OrderDao OrderDao { get; set; }
        public ClientService ClientService { get; set; }

        public void Create(Order order)
        {   
            OrderDao.Create(order);
        }

        public Order FindLastInsertOrder()
        {
            return OrderDao.FindLastInsertOrder();
        }

        public List<Order> FindOrdersByDate(DateTime initialDate, DateTime finalDate)
        {
            List<Order> orders = OrderDao.FindOrdersByDate(initialDate, finalDate);
            orders.ForEach(o =>
            {
                o.Client = ClientService.FindByCpf(o.Client.Cpf);
            });
            return orders;
        }

        public Order FindById(int id)
        {
            return OrderDao.FindById(id);
        }

    }
}
