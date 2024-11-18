using Projeto_de_Vendas.br.com.projeto.dao;
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
using System.Linq;
using System.Globalization;
using ZstdSharp.Unsafe;

namespace Projeto_de_Vendas.br.com.projeto.views
{
    public partial class OrderForm : Form
    {

        // Client Objects
        private ClientService _clientService;
        private Client _client;

        // Product Objects
        private ProductService _productService;
        private Product _product;

        // Cart
        private List<OrderItem> _cart;

        public OrderForm()
        {
            _clientService = new ClientService();
            _clientService.ClientDao = new ClientDao();
            _client = new Client();

            _productService = new ProductService();
            _productService.ProductDao = new ProductDao();
            _product = new Product();

            _cart = new List<OrderItem>();
            
            InitializeComponent();
        }

        private void txtCpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtCpf.Text.Length != 11)
                {
                    MessageBox.Show("Informe todo os digítos do CPF", "CPF inválido");
                    return;
                }

                _client = _clientService.FindByCpf(txtCpf.Text);
                if (_client == null)
                {
                    MessageBox.Show("Cliente não encontrado", "CPF inválido");
                    return;
                }

                txtName.Text = _client.Name;
                txtCpf.Enabled = false;
            }
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtId.Text == "")
                {
                    MessageBox.Show("Informe o ID do produto", "ID do produto inválido");
                    return;
                }

                try
                {
                    _product = _productService.FindById(int.Parse(txtId.Text));
                }
                catch(Exception)
                {
                    MessageBox.Show("Informe um ID válido", "ID do produto inválido");
                }

                if (_product == null)
                {
                    MessageBox.Show("Produto não encontrado", "ID do produto inválido");
                    return;
                }
                txtDescription.Text = _product.Description;
                txtPrice.Text = _product.Price.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateCart()) return;

            double subTotal = int.Parse(txtQty.Text) * _product.Price;

            OrderItem item = _cart.Where(i => i.Product.IdProduct == _product.IdProduct).FirstOrDefault();

            if (item != null)
            {
                item.Amount += int.Parse(txtQty.Text);
                item.SubTotal += subTotal;

            }
            else
            {
                _cart.Add(new OrderItem()
                {
                    Product = _product,
                    Amount = int.Parse(txtQty.Text),
                    SubTotal = subTotal,
                });
            }

            txtTotal.Text = (double.Parse(txtTotal.Text) + subTotal).ToString();

            table.DataSource = null;
            table.DataSource = _cart;  
            table.Columns["Product"].HeaderText = "Produto";
            table.Columns["Amount"].HeaderText = "Quantidade";
            table.Columns["IdOrderItem"].Visible = false;
            table.Columns["Order"].Visible = false;
            table.Refresh();
        }

        private bool ValidateCart()
        {
            if (_client.Cpf == null || _client.Cpf == "")
            {
                MessageBox.Show("Informe o cliente", "Adicionar item no carrinho");
                return false;
            }
            if (_product.IdProduct == null)
            {
                MessageBox.Show("Informe o produto", "Adicionar item no carrinho");
                return false;
            }
            if (txtQty.Text == "")
            {
                MessageBox.Show("Informe a quantidade do produto", "Adicionar item no carrinho");
                return false;
            }
            if (_product.QtyAvaiable < int.Parse(txtQty.Text))
            {
                MessageBox.Show("Quantidade indisponível em estoque\nQuantidade disponível: " + _product.QtyAvaiable, "Adicionar item no carrinho");
                return false;
            }

            return true;
        }

        private void table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnRemove.Enabled = true;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Product product;
            try
            {
                product = (Product) table.CurrentRow.Cells[2].Value;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Selecione um item para remover!", "Carrinho de compras");
                return;
            }

            if (product == null) 
            {
                MessageBox.Show("Selecione um item para remover!", "Carrinho de compras");
                return;
            }


            for (int i = 0; i < _cart.Count; i++)
            {
                OrderItem item = _cart[i];
                if (item.Product == product)
                {
                    double total = double.Parse(txtTotal.Text) - item.SubTotal;
                    txtTotal.Text = total.ToString();

                    _cart.RemoveAt(i);

                    break;  
                }
            }

            table.DataSource = null;
            table.DataSource = _cart;
            table.Columns["Product"].HeaderText = "Produto";
            table.Columns["Amount"].HeaderText = "Quantidade";
            table.Columns["IdOrderItem"].Visible = false;
            table.Columns["Order"].Visible = false;
            table.Refresh();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            
            PaymentForm paymentForm = new PaymentForm(_cart, _client, double.Parse(txtTotal.Text), this);
            paymentForm.ShowDialog();

        }

        public void Clean()
        {
            _client = new Client();
            _cart = new List<OrderItem>();
            _product = new Product();
            txtCpf.Clear();
            txtName.Clear();
            txtDescription.Clear();
            txtPrice.Clear();
            txtTotal.Clear();
            txtId.Clear();
            txtQty.Clear();

            table.DataSource = _cart;
            table.Columns["Product"].HeaderText = "Produto";
            table.Columns["Amount"].HeaderText = "Quantidade";
            table.Columns["IdOrderItem"].Visible = false;
            table.Columns["Order"].Visible = false;
            table.Refresh();
        }
    }
}
