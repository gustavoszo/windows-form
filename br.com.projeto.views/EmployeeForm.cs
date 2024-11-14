using MySqlX.XDevAPI;
using Projeto_de_Vendas.br.com.curso.utils;
using Projeto_de_Vendas.br.com.projeto.dao;
using Projeto_de_Vendas.br.com.projeto.exceptions;
using Projeto_de_Vendas.br.com.projeto.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_de_Vendas.br.com.projeto.views
{
    public partial class EmployeeForm : Form
    {

        private Employee _employee;
        private Address _address;
        private EmployeeDao _employeeDao;

        public EmployeeForm()
        {
            _employee = new Employee();
            _address= new Address();    
            _employee.Address = _address;
            _employeeDao = new EmployeeDao();   
            InitializeComponent();
        }

        private void clientTabPage_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxPosititon_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string id = _employee.Cpf;

            bool valid = ValidateForm(_employee.Cpf == null);
            if (!valid)
            {
                MessageBox.Show("Informe todos os campos corretamente!");
                return;
            }

            _employee.Name = txtName.Text;
            _employee.Cpf = txtCpf.Text;
            _employee.Email = txtEmail.Text;
            _employee.Phone = txtPhone.Text;
            _employee.Position = comboBoxPosition.SelectedItem as string;
            _address.Place = txtAddress.Text;
            _address.Number = int.Parse(txtAddressNumber.Text);
            _address.City = txtCity.Text;
            _address.State = (string) comboBoxState.SelectedItem;

            try
            {
                if (id == null)
                {
                    _employee.Password = txtPassword.Text;
                    if (_employeeDao.FindByEmail(_employee.Email) != null) throw new EmailUniqueValidationException("E-mail já cadastrado!");
                    if (_employeeDao.FindByCpf(_employee.Cpf) != null) throw new CpfUniqueValidationException("CPF já cadastrado!");
                    string salt;
                    _employee.Password = PasswordHashUtil.GeneratePasswordHash(_employee.Password, out salt);
                    _employeeDao.Create(_employee);
                    MessageBox.Show("Funcionário cadastrado com sucesso!", "Cadastro de Funcionário");
                }
                else
                {
                    Employee employee = _employeeDao.FindByEmail(_employee.Email);
                    if (employee != null && employee.Cpf != _employee.Cpf) throw new EmailUniqueValidationException("E-mail já cadastrado");
                    _employeeDao.Update(_employee);
                    MessageBox.Show("Funcionário atualizado com sucesso!", "Atualizaçao de Funcionário");
                }

                btnClean_Click(sender, e);
                UnloadEmployee();
                table.DataSource = _employeeDao.FindAll();
            }
            catch(ApplicationException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private bool ValidateForm(bool isCreate)
        {
            if (txtName.Text.Trim() == "") return false;
            if (txtCpf.Text.Length != 11) return false;
            if (txtEmail.Text.Trim() == "") return false;
            if (isCreate)
            {
                if (txtPassword.Text.Trim() == "") return false;
            }
            if (txtPhone.Text.Length != 11) return false;
            if (comboBoxPosition.SelectedItem == null) return false;
            if (txtAddress.Text.Trim() == "") return false;
            if (txtAddressNumber.Text.Trim() == "") return false;
            if (txtCity.Text.Trim() == "") return false;
            if (comboBoxState.SelectedItem == null) return false;

            return true;
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtCpf.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtAddressNumber.Text = "";
            txtCity.Text = "";
            comboBoxPosition.SelectedItem = null;
            comboBoxState.SelectedItem = null;
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            table.DataSource = _employeeDao.FindAll();
        }

        private void table_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string cpf = table.CurrentRow.Cells[3].Value.ToString();

            LoadEmployee(cpf);
        }

        private void LoadEmployee(string cpf)
        {
            _employee = _employeeDao.FindByCpf(cpf);

            btnSave.Text = "Atualizar";
            btnDelete.Visible = true;
            btnCancel.Visible = true;
            txtPassword.Visible = false;
            labelPassword.Visible = false;

            txtCpf.Enabled = false;

            txtName.Text = _employee.Name;
            txtCpf.Text = _employee.Cpf;
            txtEmail.Text = _employee.Email;
            txtPhone.Text = _employee.Phone;
            comboBoxPosition.SelectedItem = _employee.Position;
            txtAddress.Text = _employee.Address.Place;
            txtAddressNumber.Text = _employee.Address.Number.ToString();
            txtCity.Text = _employee.Address.City;
            comboBoxState.SelectedItem = _employee.Address.State;
        }

        private void UnloadEmployee()
        {
            btnSave.Text = "Salvar";
            btnDelete.Visible = false;
            btnCancel.Visible = false;
            txtCpf.Enabled = true;
            txtPassword.Visible=true;
            labelPassword.Visible = true;
            _employee = new Employee();
            _address = new Address();
            _employee.Address = _address;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnClean_Click(sender, e);
            UnloadEmployee();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Tem certeza de que deseja excluir este funcionário?",
                    "Confirmar exclusão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _employeeDao.Delete(_employee);
                    MessageBox.Show("Funcionário deletado com sucesso!", "Exclusão de Funcionário");
                    UnloadEmployee();
                    btnClean_Click(sender, e);
                    table.DataSource = _employeeDao.FindAll();
                }

            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim() == "") return;
            List<Employee> list = _employeeDao.FindAllByName(txtSearch.Text);

            if (list.Count == 0)
            {
                table.DataSource = _employeeDao.FindAll();
                return;
            }

            table.DataSource = list;
             
        }

        private void txtAddressNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAddressNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) e.Handled = true; 
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
