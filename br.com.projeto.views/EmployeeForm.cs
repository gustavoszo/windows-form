using MySqlX.XDevAPI;
using Projeto_de_Vendas.br.com.projeto.dao;
using Projeto_de_Vendas.br.com.projeto.exceptions;
using Projeto_de_Vendas.br.com.projeto.models;
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
            bool valid = ValidateForm();
            if (!valid)
            {
                MessageBox.Show("Informe todos os campos corretamente!");
                return;
            }

            _employee.Name = txtName.Text;
            _employee.Cpf = txtCpf.Text;
            _employee.Email = txtEmail.Text;
            _employee.Phone = txtPhone.Text;
            _employee.Password = txtPassword.Text;
            _employee.Position = comboBoxPosition.SelectedItem as string;
            _address.Place = txtAddress.Text;
            _address.Number = int.Parse(txtAddressNumber.Text);
            _address.City = txtCity.Text;
            _address.State = (string) comboBoxState.SelectedItem;

            try
            {
                _employeeDao.Create(_employee);
                MessageBox.Show("Funcionário cadastrado com sucesso!");

            }
            catch(ApplicationException ex)
            {
                MessageBox.Show(ex.Message);
            }

            btnClean_Click(sender, e);

        }

        private bool ValidateForm()
        {
            if (txtName.Text.Trim() == "") return false;
            if (txtCpf.Text.Length != 11)
            {
                Console.WriteLine("CPF");
                return false;
            }
            if (txtEmail.Text.Trim() == "") return false;
            if (txtPassword.Text.Trim() == "") return false;
            if (txtPhone.Text.Length != 11)
            {
                Console.WriteLine("Phone");
                return false;
            }
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
            comboBoxState.SelectedItem = null;
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            try
            {
                List<Employee> list = _employeeDao.FindAll();
                 table.DataSource = list;
            }
            catch(ExceptionDb ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
