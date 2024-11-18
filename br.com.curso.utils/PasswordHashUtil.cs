using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_de_Vendas.br.com.curso.utils
{
    using System;
    using System.Security.Cryptography;

    public static class PasswordHashUtil
    {

        // Método para gerar o hash da senha sem salt
        public static string GeneratePasswordHash(string password)
        {
            // Salt fixo de 8 bytes
            byte[] salt = new byte[8];  // Salt fixo de 8 bytes
            for (int i = 0; i < salt.Length; i++) salt[i] = (byte)(i + 1);  // Preenche o salt com valores fixos (exemplo: 1, 2, 3... até 8)

            // Usando PBKDF2 para gerar o hash da senha com o salt fixo
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000)) // Salt fixo de 8 bytes
            {
                byte[] hash = pbkdf2.GetBytes(20);  // Produz um hash de 20 bytes
                return Convert.ToBase64String(hash);  // Retorna o hash em base64
            }
        }

        // Método para verificar a senha fornecida
        public static bool VerifyPassword(string password, string storedHash)
        {
            // Salt fixo usado para gerar o hash da senha (deve ser o mesmo salt usado na geração do hash)
            byte[] salt = new byte[8];  // Salt fixo de 8 bytes
            for (int i = 0; i < salt.Length; i++) salt[i] = (byte)(i + 1);  // Preenche o salt com os mesmos valores

            // Gerar o hash da senha fornecida com o mesmo salt fixo
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000))
            {
                byte[] hash = pbkdf2.GetBytes(20);
                string hashedPassword = Convert.ToBase64String(hash);

                // Comparando o hash gerado com o hash armazenado
                return storedHash == hashedPassword;
            }
        }
    }
}
