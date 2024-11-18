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

            _cart.ForEach(i => {
                if (i.Product == _product)
                {
                    i.Amount += int.Parse(txtQty.Text);
                    i.SubTotal += subTotal;
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
            });

            table.DataSource = _cart;
            table.Columns["Product"].HeaderText = "Produto";
            table.Columns["Amount"].HeaderText = "Quantidade";

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
            /*
            Product product = (Product) table.CurrentRow.Cells[3].Value;

            _cart.ForEach(i =>
            {
                if (i.Product == product)
                {
                    txtTotal.Text = (double.Parse(txtTotal.Text) - i.SubTotal).ToString();
                    _cart.Remove(i);
                }
            });

            table.DataSource = _cart;
            */
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            
            // PaymentForm paymentForm = new PaymentForm();

        }
    }
}
