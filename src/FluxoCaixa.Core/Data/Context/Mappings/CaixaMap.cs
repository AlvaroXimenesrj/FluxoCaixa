using FluxoCaixa.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluxoCaixa.Core.Data.Context.Mappings
{
    public class CaixaMap : IEntityTypeConfiguration<Caixa>
    {
        public void Configure(EntityTypeBuilder<Caixa> builder)
        {
            builder.ToTable("Caixas");

            builder.HasKey(c => c.Id);

            builder.Property(d => d.Saldo).HasPrecision(11, 2);
        }
    }
}