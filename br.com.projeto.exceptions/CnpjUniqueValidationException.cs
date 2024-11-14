using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_de_Vendas.br.com.projeto.exceptions
{
    internal class CnpjUniqueValidationException : ApplicationException
    {

        public CnpjUniqueValidationException(string message) : base(message) { }

    }
}
