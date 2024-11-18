using Projeto_de_Vendas.br.com.projeto.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_de_Vendas.br.com.curso.utils
{
    public class Session
    {

        public static Employee Employee { get; set; }

        public static void LoadEmployee(Employee employee)
        {
            if(employee != null) Employee = employee; 
        }

        public static void UnloadEmployee()
        {
            if (Employee != null) Employee = null;
        }

    }
}
