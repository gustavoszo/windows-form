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
using ZstdSharp.Unsafe;

namespace Projeto_de_Vendas.br.com.projeto.views
{
    public partial class ProductForm : Form
    {

        private Product _product;
        private ProductService _productService;

        public ProductForm()
        {
            _product = new Product();
            _product.Provider = new Provider();
            _productService = new ProductService();
            _productService.ProductDao = new ProductDao();
            InitializeComponent();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            comboBoxProvider.DataSource = new ProviderDao().FindAll();
            comboBoxProvider.DisplayMember = "Name";
            comboBoxProvider.SelectedItem = null;

            table.DataSource = _productService.FindAll();
            table.Columns["IdProduct"].HeaderText = "ID";
            table.Columns["Description"].HeaderText = "Descrição";
            table.Columns["Price"].HeaderText = "Preço";
            table.Columns["QtyAvaiable"].HeaderText = "Qtd Estoque";
            table.Columns["Provider"].HeaderText = "Fornecedor";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool valid = ValidateForm();

            if (!valid)
            {
                MessageBox.Show("Preencha todos os campos corretamente!");
                return;
            }

            Console.WriteLine(((Provider)comboBoxProvider.SelectedItem).Cnpj);
            int? id = _product.IdProduct;

            _product.Description = txtDescription.Text;
            _product.Price = double.Parse(txtPrice.Text);
            _product.QtyAvaiable = int.Parse(txtQtAvaiable.Text);
            _product.Provider = (Provider)comboBoxProvider.SelectedItem;

            try
            {
                if (id == null)
                {
                    _productService.Create(_product);
                    MessageBox.Show("Produto cadastrado com sucesso!", "Cadastrado de Produto");
                }
                else
                {
                    _productService.Update(_product);
                    MessageBox.Show("Produto atualizado com sucesso!", "Atualização do Produto");
                }

                btnClean_Click(sender, e);
                UnloadProduct();
                table.DataSource = _productService.FindAll();
            }
            catch(ApplicationException ex)
            {
                MessageBox.Show(ex.Message, "Gerenciamento de produtos");
            }

        }

        private bool ValidateForm()
        {
            if (txtDescription.Text.Trim() == "") return false;
            if (txtPrice.Text.Trim() == "") return false;
            if (!double.TryParse(txtPrice.Text, out double result)) return false;
            if (txtQtAvaiable.Text.Trim() == "") return false;
            if (comboBoxProvider.SelectedItem == null) return false;

            return true;
        }

        private void txtQtAvaiable_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) e.Handled = true;
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            txtDescription.Text = "";
            txtPrice.Text = "";
            txtQtAvaiable.Text = "";
            comboBoxProvider.SelectedItem = null;
        }
        
        private void LoadProduct(int id)
        {
            btnDelete.Visible = true;
            btnCancel.Visible = true;
            btnSave.Text = "Atualizar";
            _product = _productService.FindById(id);

            txtId.Text = _product.IdProduct.ToString();
            txtDescription.Text = _product.Description;
            txtPrice.Text = _product.Price.ToString();
            txtQtAvaiable.Text = _product.QtyAvaiable.ToString();
            comboBoxProvider.SelectedItem = _product.Provider;
        }

        private void UnloadProduct()
        {
            btnDelete.Visible = false;
            btnCancel.Visible = false;
            btnSave.Text = "Salvar";
            txtId.Text = "";
            _product = new Product();
            _product.Provider = new Provider();
        }

        private void table_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = int.Parse(table.CurrentRow.Cells[0].Value.ToString());
            LoadProduct(id);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnClean_Click(sender, e);
            UnloadProduct();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(
                "Deseja realmente apagar o produto",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    _productService.Delete(_product);
                    MessageBox.Show("Produto deletado com sucesso!", "Exclusão do Produto");

                    btnCancel_Click(sender, e);
                    UnloadProduct();
                    table.DataSource = _productService.FindAll();
                }
                catch (ExceptionDb ex)
                {
                    MessageBox.Show(ex.Message, "Exclusão do Produto");
                }
            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim() == "")
            {
                table.DataSource = _productService.FindAll();
                return;
            }

            table.DataSource = _productService.FindAllByDescription(txtSearch.Text);
        }

        private void IdLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
