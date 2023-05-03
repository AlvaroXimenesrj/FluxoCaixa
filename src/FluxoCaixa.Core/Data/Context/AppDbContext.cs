using FluxoCaixa.Core.Data.Context.Mappings;
using FluxoCaixa.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace FluxoCaixa.Core.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {   
            Database.EnsureCreated();
        }

        public DbSet<Transacao> Transacoes { get; set; }
        public DbSet<Caixa> Caixas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TransacaoMap());
            modelBuilder.ApplyConfiguration(new CaixaMap());
        }

        public void EnsureCreated()
        {
            var created = Database.EnsureCreated();            
        }
    }


}
