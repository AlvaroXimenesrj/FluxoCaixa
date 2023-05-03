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
        public async Task<IEnumerable<RelatorioDto>> GetRelatorio(int caixaId)
        {
            var sqlCommand = @"SELECT
                                Caixas.Id,
                                Caixas.Saldo,
                                Transacoes.Id as TransacaoId,
                                Transacoes.Descricao,
                                Transacoes.Data,
                                Transacoes.TipoTransacao,
                                Transacoes.valor
                                FROM Caixas
                                LEFT JOIN Transacoes ON Caixas.Id = Transacoes.CaixaId
                                WHERE Caixas.Id = @caixaId
                                ORDER by Transacoes.Data desc";            

            var relatorioDictionary = new Dictionary<int, RelatorioDto>();

            var relatorio = _connection.Query<RelatorioDto, TransacaoDTO, RelatorioDto>(sqlCommand,
                    (relatorio, transacao) =>
                    {
                        RelatorioDto relatorioEntry;

                        if (!relatorioDictionary.TryGetValue(relatorio.Id, out relatorioEntry))
                        {
                            relatorioEntry = relatorio;
                            relatorioEntry.Transacoes = new List<TransacaoDTO>();
                            relatorioDictionary.Add(relatorioEntry.Id, relatorioEntry);
                        }

                        if (transacao != null)
                        {
                            relatorioEntry.Transacoes.Add(transacao);
                        }
                        return relatorioEntry;

                    }, new { caixaId },splitOn: "TransacaoId").Distinct().ToList();

            return relatorio;
        }
    }
}
