using FluxoCaixa.Relatorio.Models;

namespace FluxoCaixa.Data.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<RelatorioDto>> GetRelatorio(int caixaId, DateTime dia);
    }
}
