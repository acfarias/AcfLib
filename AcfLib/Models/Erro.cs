namespace AcfLib.Models
{
    internal sealed class Erro
    {
        public Erro(string codigo, string descricao)
        {
            Codigo = codigo;
            Descricao = descricao;
        }

        public string Codigo { get; private set; }
        public string Descricao { get; private set; }
    }
}
