using FluxoCaixa.Core.Domain;

namespace FluxoCaixa.Api.Data.Repository
{
    public interface IRepository : IDisposable
    {
        Task<bool> SalvarTransacao(Transacao transacao);
        Task<bool> UpdateCaixa(Caixa caixa);
        Task<Caixa> GetCaixaById(int id);
        Task<Caixa> CriarCaixa();
    }
}