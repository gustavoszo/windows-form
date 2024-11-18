using Projeto_de_Vendas.br.com.curso.utils;
using Projeto_de_Vendas.br.com.projeto.dao;
using Projeto_de_Vendas.br.com.projeto.exceptions;
using Projeto_de_Vendas.br.com.projeto.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_de_Vendas.br.com.projeto.services
{
    internal class EmployeeService
    {

        public EmployeeDao EmployeeDao { get; set; }

        public void Create(Employee employee)
        {
            if (EmployeeDao.FindByCpf(employee.Cpf) != null) throw new CpfUniqueValidationException("CPF já cadastrado!");
            if (EmployeeDao.FindByEmail(employee.Email) != null) throw new EmailUniqueValidationException("E-mail já cadastrado!");

            string salt;
            employee.Password = PasswordHashUtil.GeneratePasswordHash(employee.Password, out salt);
            EmployeeDao.Create(employee);
        }

        public List<Employee> FindAll()
        {
            return EmployeeDao.FindAll();
        }

        public void Update(Employee employee)
        {
            Employee EmployeeByEmail = EmployeeDao.FindByEmail(employee.Email);
            if (EmployeeByEmail != null && EmployeeByEmail.Cpf != employee.Cpf) throw new EmailUniqueValidationException("E-mail já cadastrado");
            EmployeeDao.Update(employee);
        }

        public void Delete(Employee employee)
        {
            EmployeeDao.Delete(employee);
        }

        public Employee FindByCpf(string cpf)
        {
            return EmployeeDao.FindByCpf(cpf);
        }

        public List<Employee> FindAllByName(string name)
        {
            return EmployeeDao.FindAllByName(name);
        }

    }
}
