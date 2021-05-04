using System.Text;
using System.Threading.Tasks;

namespace AcfLib.EncriptSenha
{
    public static class Encript
    {
        private const string TokenSenha = "b9e5936b-c44d-467e-a7c4-b7f289f79912";
        public static string Encriptar(string pwd)
        {
            if (string.IsNullOrWhiteSpace(pwd))
                return string.Empty;

            System.Security.Cryptography.SHA384 sha384 = System.Security.Cryptography.SHA384.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(string.Concat(pwd, TokenSenha));
            byte[] hash = sha384.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return Task.FromResult(sb.ToString()).GetAwaiter().GetResult();
        }
    }
}
