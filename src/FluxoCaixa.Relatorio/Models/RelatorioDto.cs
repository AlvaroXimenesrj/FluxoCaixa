namespace FluxoCaixa.Relatorio.Models
{
    public class RelatorioDto
    {
        public int Id { get; set; }
        public decimal Saldo { get; set; }

        public List<TransacaoDTO> Transacoes { get; set; }
    }

    public class TransacaoDTO
    {
        public int TransacaoId { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public string TipoTransacao { get; set; }
        public decimal valor { get; set; }
    }
}
