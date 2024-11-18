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
    public partial class HistoryForm : Form
    {

        private OrderService _orderService;

        public HistoryForm()
        {
            _orderService = new OrderService();
            _orderService.OrderDao = new OrderDao();
            _orderService.ClientService = new ClientService();
            _orderService.ClientService.ClientDao = new ClientDao();
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime initialDate = dateTimeInitial.Value;
            DateTime finalDate = dateTimeFinal.Value;
            table.DataSource = _orderService.FindOrdersByDate(initialDate, finalDate);

            table.Columns["IdOrder"].HeaderText = "ID";
            table.Columns["Client"].HeaderText = "Cliente";
            table.Columns["Note"].HeaderText = "Observações";
            
        }

        private void table_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OrderDetailForm orderDetailForm = new OrderDetailForm();

            Order order = _orderService.FindById((int)table.CurrentRow.Cells[0].Value);
            orderDetailForm.txtClient.Text = order.Client.Name;
            orderDetailForm.txtDate.Text = order.Date.ToString();
            orderDetailForm.txtNote.Text = order.Note;
            orderDetailForm.txtTotal.Text = order.Total.ToString();
            orderDetailForm.Order = order;
            orderDetailForm.LoadTable();
            orderDetailForm.ShowDialog();
        }
    }
}
