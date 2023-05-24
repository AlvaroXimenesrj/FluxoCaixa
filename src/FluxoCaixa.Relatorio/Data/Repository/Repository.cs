using Dapper;
using FluxoCaixa.Relatorio.Models;
using System.Data;

namespace FluxoCaixa.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly IDbConnection _connection;        
        public Repository(IDbConnection connection)
        {
            _connection = connection;           
        }
        public async Task<IEnumerable<RelatorioDto>> GetRelatorio(int caixaId, DateTime dia)
        {
            var diaConsulta = dia.ToString("yyy/MM/dd");

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
                               --AND Transacoes.Data < @dia
                               AND CAST(Transacoes.Data AS date) = @diaConsulta
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

                    }, new { caixaId, diaConsulta }, splitOn: "TransacaoId").Distinct().ToList();

           
            return relatorio;
        }
    }
}
