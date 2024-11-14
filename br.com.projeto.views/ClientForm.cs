using Projeto_de_Vendas.br.com.projeto.dao;
using Projeto_de_Vendas.br.com.projeto.exceptions;
using Projeto_de_Vendas.br.com.projeto.models;
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
        private ClientDao _clientDao;

        public ClientForm()
        {
            InitializeComponent();
            _client = new Client();
            _address = new Address();
            _client.Address = _address;
            _clientDao = new ClientDao();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            table.DataSource = _clientDao.FindAll();

            // Personaliza as colunas, se necessário
            table.Columns["Name"].HeaderText = "Nome";
            table.Columns["Cpf"].HeaderText = "CPF";
            table.Columns["Email"].HeaderText = "Email";
            table.Columns["Phone"].HeaderText = "Telefone";
            table.Columns["FullAddress"].HeaderText = "Endereço"; 

            // Exemplo de ocultar a coluna "Address" se não for necessário
            table.Columns["Address"].Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void numberLabel_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void cpfMaskedTextBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {

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
                    if (_clientDao.FindByCpf(txtCpf.Text) != null) throw new CpfUniqueValidationException("CPF já cadastrado!");
                    if (_clientDao.FindByEmail(_client.Email) != null) throw new EmailUniqueValidationException("E-mail já cadastrado!");
                    _clientDao.Create(_client);
                    MessageBox.Show("Cliente cadastrado com sucesso!");
                } 
                else
                {
                    Client client = _clientDao.FindByEmail(_client.Email);
                    if (client != null && client.Cpf != id) throw new EmailUniqueValidationException("E-mail já cadastrado");
                    _clientDao.Update(_client);
                    MessageBox.Show("Cliente atualizado com sucesso!");
                }

                btnClean_Click(sender, e);
                unloadClient();
                table.DataSource = _clientDao.FindAll();

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
                _clientDao.Delete(_client);
                MessageBox.Show("Cliente deletado com sucesso!");
                btnClean_Click(sender, e);
                unloadClient();

                table.DataSource = _clientDao.FindAll();
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

        private void table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void loadClient(Client client)
        {
            btnSave.Text = "Atualizar";
            btnDelete.Visible = true;
            txtCpf.Enabled = false;

            txtName.Text = client.Name;
            txtCpf.Text = client.Cpf;
            txtEmail.Text = client.Email;
            txtPhone.Text = client.Phone;
            txtAddress.Text = client.Address.Place;
            txtAddressNumber.Text = client.Address.Number.ToString();
            txtCity.Text = client.Address.City;
            comboBoxState.SelectedItem = client.Address.State;
        }


        private void unloadClient()
        {
            btnSave.Text = "Salvar";
            btnDelete.Visible = false;
            txtCpf.Enabled = true;
            _client = new Client();
            _address = new Address();
            _client.Address = _address;
        }

        private void table_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string cpf = table.CurrentRow.Cells[1].Value.ToString();
            _client = _clientDao.FindByCpf(cpf);

            tabControlClient.SelectedTab = clientTabPage;

            loadClient(_client);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            List<Client> clients = _clientDao.FindAllByName(txtSearch.Text);
            Console.WriteLine(clients);

            if (clients.Count == 0)
            {
                table.DataSource = _clientDao.FindAll(); 
                return;
            }

            table.DataSource = clients;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            List<Client> clients = _clientDao.FindByName(txtSearch.Text);
            table.DataSource = clients;
        }
    }
}
