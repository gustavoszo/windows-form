using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_de_Vendas.br.com.curso.utils
{
    internal class PasswordHashUtil
    {

        // Função que gera um hash seguro utilizando PBKDF2
        public static string GeneratePasswordHash(string password, out string sal)
        {
            // Gerar um "sal" (salt) aleatório
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] saltBytes = new byte[16];
                rng.GetBytes(saltBytes);
                sal = Convert.ToBase64String(saltBytes);

                // Aplicar PBKDF2 com o "sal" e a senha
                using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 10000))
                {
                    byte[] hash = pbkdf2.GetBytes(20);  // Produz um hash de 20 bytes
                    return Convert.ToBase64String(hash);  // Retorna o hash em base64
                }
            }
        }

        public static bool VerifyPassword(string passsword, string storedHash, string sal)
        {
            // Convertendo o sal de volta para um array de bytes
            byte[] saltBytes = Convert.FromBase64String(sal);

            // Usar PBKDF2 para gerar o hash da senha fornecida
            using (var pbkdf2 = new Rfc2898DeriveBytes(passsword, saltBytes, 10000))
            {
                byte[] hash = pbkdf2.GetBytes(20);
                string verifiedHash = Convert.ToBase64String(hash);

                // Comparando o hash gerado com o armazenado
                return storedHash == verifiedHash;
            }
        }


    }
}
