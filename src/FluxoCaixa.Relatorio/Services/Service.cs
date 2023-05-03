using FluxoCaixa.Data.Repository;
using FluxoCaixa.Relatorio.Models;

namespace FluxoCaixa.Relatorio.Services
{
    public class Service : IService
    {
        private readonly IRepository _repository;
        public Service(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<RelatorioDto>> GetRelatorioDiario()
        {
            var relatorio = await _repository.GetRelatorio();

            return relatorio;
        }
    }
}
