namespace AcfLib.Cartao
{
    public abstract class ValidacaoDeCartao
    {
        public bool ValidarCartao(string numeroCartao)
        {
            if (string.IsNullOrWhiteSpace(numeroCartao))
                return false;

            numeroCartao = numeroCartao.Trim();
            numeroCartao = numeroCartao.Replace("-", "");

            return numeroCartao.Length == 16;
        }
    }
}
