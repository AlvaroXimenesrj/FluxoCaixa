namespace FluxoCaixa.Core.Domain
{
    public class Transacao
    {
        public int Id { get; private set; }
        public DateTime Data { get; private set; }
        public TipoTransacao TipoTransacao { get; private set; }
        public decimal Valor { get; private set; }
        public string Descricao { get; private set; }
        public virtual Caixa Caixa { get; private set; }
        public int CaixaId { get; private set; }

        public static Transacao TransacaoFactory(TipoTransacao tipoTransacao, decimal valor, string descricao, int caixaId)
        {
            var transacao = new Transacao();

            transacao.Data = DateTime.Now;
            transacao.Valor = valor;
            transacao.Descricao = descricao;
            transacao.TipoTransacao = tipoTransacao;
            transacao.CaixaId = caixaId;

            return transacao;

        }       

    }
}