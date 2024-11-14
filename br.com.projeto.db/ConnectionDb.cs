using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_de_Vendas.br.com.projeto.db
{
    internal class ConnectionDb
    {

        public static MySqlConnection GetConnection()
        {
            string connection = ConfigurationManager.ConnectionStrings["vendas"].ConnectionString;
            return new MySqlConnection(connection);

        }

    }
}
