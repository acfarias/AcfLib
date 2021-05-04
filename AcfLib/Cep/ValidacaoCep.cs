namespace AcfLib.Cep
{
    public abstract class ValidacaoCep
    {
        public bool ValidarCep(string cep)
        {
            if (string.IsNullOrWhiteSpace(cep))
                return false;

            cep = cep.Trim();
            cep = cep.Replace("-", "");

            return cep.Length == 8;
        }
    }
}
