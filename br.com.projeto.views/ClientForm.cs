﻿using Projeto_de_Vendas.br.com.projeto.dao;
using Projeto_de_Vendas.br.com.projeto.exceptions;
using Projeto_de_Vendas.br.com.projeto.models;
using Projeto_de_Vendas.br.com.projeto.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_de_Vendas.br.com.projeto.views
{
    public partial class ClientForm : Form
    {

        private Client _client;
        private Address _address;
        private ClientService _clientService;

        public ClientForm()
        {
            InitializeComponent();
            _client = new Client();
            _address = new Address();
            _client.Address = _address;
            _clientService = new ClientService();
            _clientService.ClientDao = new ClientDao();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            table.DataSource = _clientService.FindAll();

            // Personaliza as colunas, se necessário
            table.Columns["Name"].HeaderText = "Nome";
            table.Columns["Cpf"].HeaderText = "CPF";
            table.Columns["Email"].HeaderText = "Email";
            table.Columns["Phone"].HeaderText = "Telefone";
            table.Columns["FullAddress"].HeaderText = "Endereço"; 

            // Exemplo de ocultar a coluna "Address" se não for necessário
            table.Columns["Address"].Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string id = _client.Cpf;
            bool valid = ValidateForm();

            if (!valid)
            {
                MessageBox.Show("Preencha todos os campos corretamente!");
                return;
            }

            _client.Name = txtName.Text;
            _client.Cpf = txtCpf.Text;
            _client.Email = txtEmail.Text;
            _client.Phone = txtPhone.Text;
            _address.Place = txtAddress.Text;
            _address.Number = int.Parse(txtAddressNumber.Text);
            _address.City = txtCity.Text;
            _address.State = (string) comboBoxState.SelectedItem;

            try
            {

                if (id == null)  
                {
                    _clientService.Create(_client);
                    MessageBox.Show("Cliente cadastrado com sucesso!", "Cadastro de Cliente");
                } 
                else
                {
                    _clientService.Update(_client);
                    MessageBox.Show("Cliente atualizado com sucesso!", "Atualização de Cliente");
                }

                btnClean_Click(sender, e);
                unloadClient();
                table.DataSource = _clientService.FindAll();

            }
            catch(ApplicationException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtCpf.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtAddressNumber.Text = "";
            txtCity.Text = "";
            comboBoxState.SelectedItem = null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult result = MessageBox.Show(
                    "Deseja realmente apagar o Cliente?",
                    "Confirmar remoção",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    _clientService.Delete(_client);
                    MessageBox.Show("Cliente deletado com sucesso!", "Exclusão de Cliente");
                    btnClean_Click(sender, e);
                    unloadClient();
                }

                table.DataSource = _clientService.FindAll();
            }
            catch (ExceptionDb ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addressLabel_Click(object sender, EventArgs e)
        {

        }

        private void txtAddressNumber_TextChanged(object sender, EventArgs e)
        {
            
        }

        private bool ValidateForm()
        {
            if (txtName.Text.Trim() == "") return false;
            if (txtCpf.Text.Length != 11) return false;
            if (txtEmail.Text.Trim() == "") return false;
            if (txtPhone.Text.Length != 11) return false;
            if (txtAddress.Text.Trim() == "") return false;
            if (txtAddressNumber.Text.Trim() == "") return false;
            if (txtCity.Text.Trim() == "") return false;
            if (comboBoxState.SelectedItem == null) return false;

            return true;
        }

        private void TxTAddressNumberKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;  // Impede que o caractere seja inserido
            }
        }

        private void loadClient(string cpf)
        {
            _client = _clientService.FindByCpf(cpf);

            btnSave.Text = "Atualizar";
            btnDelete.Visible = true;
            btnCancel.Visible = true;

            txtCpf.Enabled = false;

            txtName.Text = _client.Name;
            txtCpf.Text = _client.Cpf;
            txtEmail.Text = _client.Email;
            txtPhone.Text = _client.Phone;
            txtAddress.Text = _client.Address.Place;
            txtAddressNumber.Text = _client.Address.Number.ToString();
            txtCity.Text = _client.Address.City;
            comboBoxState.SelectedItem = _client.Address.State;
        }


        private void unloadClient()
        {
            btnSave.Text = "Salvar";
            btnDelete.Visible = false;
            btnCancel.Visible= false;
            txtCpf.Enabled = true;
            _client = new Client();
            _address = new Address();
            _client.Address = _address;
        }

        private void table_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string cpf = table.CurrentRow.Cells[1].Value.ToString();

            loadClient(cpf);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim() == "") return;
            List<Client> clients = _clientService.FindAllByName(txtSearch.Text);

            if (clients.Count == 0)
            {
                table.DataSource = _clientService.FindAll(); 
                return;
            }

            table.DataSource = clients;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnClean_Click(sender, e);
            unloadClient();
        }

        private void table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBoxState_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
