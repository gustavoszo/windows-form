using Projeto_de_Vendas.br.com.curso.utils;
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
    public partial class LoginForm : Form
    {

        private EmployeeService _employeeService;

        public LoginForm()
        {
            _employeeService = new EmployeeService();
            _employeeService.EmployeeDao = new EmployeeDao();
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Employee employee = _employeeService.FindByEmail(txtEmail.Text);
            if (employee == null)
            {
                MessageBox.Show("E-mail e ou senha inválido(s)", "Login");
                return;
            }
     
            if (!PasswordHashUtil.VerifyPassword(txtPassword.Text, employee.Password))
            {
                MessageBox.Show("E-mail e ou senha inválido(s)", "Login");
                return;
            }

            Session.LoadEmployee(employee);
            HomeForm homeForm = new HomeForm();
            homeForm.ShowDialog();
            this.Visible = false;
            this.Close();
        }
    }
}
