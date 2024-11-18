using Projeto_de_Vendas.br.com.projeto.dao;
using Projeto_de_Vendas.br.com.projeto.models;
using Projeto_de_Vendas.br.com.projeto.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_de_Vendas.br.com.projeto.views
{
    public partial class OrderDetailForm : Form
    {

        public Order Order { get; set; }
        private OrderItemService _orderItemService;

        public OrderDetailForm()
        {
            _orderItemService = new OrderItemService();
            _orderItemService.OrderItemDao = new dao.OrderItemDao();
            _orderItemService.ProductService = new ProductService();
            _orderItemService.ProductService.ProductDao = new ProductDao();
            InitializeComponent();
        }

       public void LoadTable()
       {
            table.DataSource = _orderItemService.FindAllById(Order.IdOrder);
            table.Columns["IdOrderItem"].HeaderText = "ID";
            table.Columns["Order"].Visible = false;
            table.Columns["Product"].HeaderText = "Produto";
            table.Columns["Amount"].HeaderText = "Quantidade";
        }

        private void table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
