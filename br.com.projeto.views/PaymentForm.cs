﻿using Projeto_de_Vendas.br.com.projeto.dao;
using Projeto_de_Vendas.br.com.projeto.exceptions;
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
    public partial class PaymentForm : Form
    {

        private List<OrderItem> _cart;
        private Client _client;
        private OrderService _orderService;
        private OrderItemService _orderItemService;
        private OrderForm _orderForm;

        public PaymentForm(List<OrderItem> cart, Client client, double total, OrderForm orderForm)
        {
            _orderForm = orderForm;

            _orderService = new OrderService();
            _orderService.OrderDao = new OrderDao();

            _orderItemService = new OrderItemService();
            _orderItemService.OrderItemDao = new OrderItemDao();

            _cart = cart;
            _client = client;
            InitializeComponent();
            txtTotal.Text = total.ToString();
            _orderForm = orderForm;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!ValidatePayment()) return;

            try
            {
                _orderService.Create(new Order()
                {
                    Client = _client,
                    Date = DateTime.Now,
                    Total = double.Parse(txtTotal.Text),
                    Note = txtNote.Text
                });

                Order order = _orderService.FindLastInsertOrder();

                _cart.ForEach(orderItem =>
                {
                    orderItem.Product.QtyAvaiable -= orderItem.Amount;
                    orderItem.Order = order;
                    _orderItemService.Create(orderItem);
                });

                MessageBox.Show("Venda confirmada!", "Pagamento");
                _orderForm.Clean();
                this.Close();
            }
            catch (ExceptionDb ex)
            {
                throw ex;
            }
        }

        private bool ValidatePayment()
        {
            if ((!radioCard.Checked) && (!radioMoney.Checked))
            {
                MessageBox.Show("Selecione a forma de pagamento", "Pagamento");
                return false;
            }

            return true;
        }
    }
}
