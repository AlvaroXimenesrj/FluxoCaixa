using FluxoCaixa.Core.Data.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace FluxoCaixa.Core
{
    public class GetDataBaseConfig
    {
        public static void RegisterServices(IServiceCollection services)
        {
            var conn = "Server=sqlserver;Database=DbFluxoCaixa;User Id=sa;Password=Abc*1256;TrustServerCertificate=true";
#if DEBUG
            conn = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=DbFluxoCaixa;Integrated Security=True;TrustServerCertificate=True";
            
#endif
                       
            services
                .AddTransient<IDbConnection>(x => new SqlConnection(conn))
                .AddDbContext<AppDbContext>(
                options =>
                {
                    options.UseSqlServer(conn,
                    providerOptions =>
                    providerOptions.EnableRetryOnFailure());
                });
        }
    }
}
