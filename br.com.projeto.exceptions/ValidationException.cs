using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_de_Vendas.br.com.projeto.exceptions
{
    internal class ValidationException : ApplicationException
    {
        public ValidationException(string message) : base(message) { }

    }
}
