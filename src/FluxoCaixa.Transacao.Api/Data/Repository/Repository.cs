using FluxoCaixa.Core.Data.Context;
using FluxoCaixa.Core.Domain;

namespace FluxoCaixa.Api.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _db;
        public Repository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<Caixa> GetCaixaById(int id)
        {
            var caixa = await _db.Caixas.FindAsync(id);

            return caixa!;
        }

        public async Task<bool> SalvarTransacao(Transacao transacao)
        {
            await _db.Transacoes.AddAsync(transacao);
            
            return _db.SaveChanges() > 0;
        }

        public async Task<bool> UpdateCaixa(Caixa caixa)
        {
            await Task.Run(() => _db.Caixas.Update(caixa));

            return _db.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task<Caixa> CriarCaixa()
        {
            var caixa = new Caixa(0);

            await _db.Caixas.AddAsync(caixa);

            _db.SaveChanges();

            return caixa;
        }
    }
}