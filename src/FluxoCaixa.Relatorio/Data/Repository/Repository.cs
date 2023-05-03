using Dapper;
using FluxoCaixa.Core.Data.Context;
using FluxoCaixa.Relatorio.Models;
using System.Data;

namespace FluxoCaixa.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly IDbConnection _connection;
        private readonly AppDbContext _db;
        public Repository(IDbConnection connection, AppDbContext db)
        {
            _connection = connection;
            _db = db;
        }
        public async Task<IEnumerable<RelatorioDto>> GetRelatorio()
        {
            var sqlCommand = @"SELECT * FROM Caixas";

            var relatorio = await _connection.QueryAsync<RelatorioDto>(sqlCommand);

            return relatorio;
        }
    }
}
