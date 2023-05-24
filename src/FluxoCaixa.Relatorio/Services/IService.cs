using FluxoCaixa.Relatorio.Models;
using System.Security.Cryptography;

namespace FluxoCaixa.Relatorio.Services
{
    public interface IService
    {
        Task<IEnumerable<RelatorioDto>> GetRelatorioDiario(int caixaId,DateTime dia);
    }
}
