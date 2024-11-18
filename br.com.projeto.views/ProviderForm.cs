using MySqlX.XDevAPI;
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
    public partial class ProviderForm : Form
    {

        private Provider _provider;
        private Address _address;
        private ProviderService _providerService;

        public ProviderForm()
        {
            _provider = new Provider();
            _address = new Address();
            _provider.Address = _address;
            _providerService = new ProviderService();
            _providerService.ProviderDao = new ProviderDao();
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string id = _provider.Cnpj;
            bool valid = ValidateForm();
            
            if (!valid)
            {
                MessageBox.Show("Preencha todos os campos corretamente");
                return;
            }

            _provider.Name = txtName.Text;
            _provider.Cnpj = txtCnpj.Text;
            _provider.Email = txtEmail.Text;
            _provider.Phone = txtPhone.Text;
            _address.Place = txtAddress.Text;
            _address.Number = int.Parse(txtAddressNumber.Text);
            _address.City = txtCity.Text;
            _address.State = (string)comboBoxState.SelectedItem;

            try
            {
                if (id == null)
                {
                    _providerService.Create(_provider);
                    MessageBox.Show("Fornecedor cadastrado com sucesso!", "Cadastro de Fornecedor");
                }
                else
                {
                    _providerService.Update(_provider);
                    MessageBox.Show("Fornecedor atualizado com sucesso!", "Atualização de Fornecedor");
                }

                btnClean_Click(sender, e);
                UnloadProvider();
                table.DataSource = _providerService.FindAll();
            
            }
            catch(ApplicationException ex)
            {
               MessageBox.Show(ex.Message);
            }

        }

        private bool ValidateForm()
        {
            if (txtName.Text.Trim() == "") return false;
            if (txtCnpj.Text.Length != 14) return false;
            if (txtEmail.Text.Trim() == "") return false;
            if (txtPhone.Text.Length != 11) return false;
            if (txtAddress.Text.Trim() == "") return false;
            if (txtAddressNumber.Text.Trim() == "") return false;
            if (txtCity.Text.Trim() == "") return false;
            if (comboBoxState.SelectedItem == null) return false;

            return true;
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtCnpj.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtAddressNumber.Text = "";
            txtCity.Text = "";
            comboBoxState.SelectedItem = null;
        }

        private void txtAddressNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
        }

        private void UnloadProvider()
        {
            btnSave.Text = "Salvar";
            btnDelete.Visible = false;
            btnCancel.Visible = false;
            txtCnpj.Enabled = true;
            _provider = new Provider();
            _address = new Address();
            _provider.Address = _address;
        }
        private void LoadProvider(string cnpj)
        {
            _provider = _providerService.FindByCnpj(cnpj);

            btnSave.Text = "Atualizar";
            btnDelete.Visible = true;
            btnCancel.Visible = true;
            txtCnpj.Enabled = false;

            txtName.Text = _provider.Name;
            txtCnpj.Text = _provider.Cnpj;
            txtEmail.Text = _provider.Email;
            txtPhone.Text = _provider.Phone;
            txtAddress.Text = _provider.Address.Place;
            txtAddressNumber.Text = _provider.Address.Number.ToString();
            txtCity.Text = _provider.Address.City;
            comboBoxState.SelectedItem = _provider.Address.State;

        }

        private void ProviderForm_Load(object sender, EventArgs e)
        {
            table.DataSource = _providerService.FindAll();
        }


        private void table_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string cnpj = table.CurrentRow.Cells[1].Value.ToString();

            LoadProvider(cnpj);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            UnloadProvider();
            btnClean_Click(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                var result = MessageBox.Show(
                    "Deseja realmente apagar o fornecedor",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                    );

                if (result == DialogResult.Yes)
                {
                    _providerService.Delete(_provider);
                    MessageBox.Show("Fornecedor deletado com sucesso!", "Exclusão de Fornecedor");
                    btnClean_Click(sender, e);
                    UnloadProvider();
                    table.DataSource = _providerService.FindAll();
                }

            }
            catch(ExceptionDb ex)
            {
                MessageBox.Show(ex.Message, "Exclusão  de fornecedor");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim() == "")
            {
                table.DataSource = _providerService.FindAll();
                return;
            }

            table.DataSource = _providerService.FindAllByName(txtSearch.Text);
        }

        private void table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
