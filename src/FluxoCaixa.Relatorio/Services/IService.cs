using FluxoCaixa.Relatorio.Models;

namespace FluxoCaixa.Relatorio.Services
{
    public interface IService
    {
        Task<IEnumerable<RelatorioDto>> GetRelatorioDiario(int caixaId);
    }
}
