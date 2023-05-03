namespace FluxoCaixa.Core.Domain
{
    public class Caixa
    {
        public Caixa(decimal saldo)
        {
            Saldo = saldo;
            Transacoes = new List<Transacao>();
        }
        public int Id { get; private set; }
        public decimal Saldo { get; private set; }
        public IEnumerable<Transacao> Transacoes { get; private set; }

        public void AtualizarSaldo(decimal valor, TipoTransacao tipo)
        {
            if (tipo == TipoTransacao.debito)
                Saldo = Saldo - valor;

            if (tipo == TipoTransacao.credito)
                Saldo = Saldo + valor;
        }
    }
}