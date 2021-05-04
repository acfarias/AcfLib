namespace AcfLib.Telefone
{
    public abstract class ValidacaoDeNumeroCelular
    {
        public bool ValidarCelular(string numeroCelular)
        {
            if (string.IsNullOrWhiteSpace(numeroCelular))
                return false;

            numeroCelular = numeroCelular.Trim();
            numeroCelular = numeroCelular.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");

            return numeroCelular.Length == 11;
        }
    }
}
