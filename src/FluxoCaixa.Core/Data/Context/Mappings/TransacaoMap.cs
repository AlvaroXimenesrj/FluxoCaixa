using FluxoCaixa.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluxoCaixa.Core.Data.Context.Mappings
{
    public class TransacaoMap : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder.ToTable("Transacoes");

            builder.HasKey(c => c.Id);

            builder.Property(p => p.Descricao)
                .HasColumnType("varchar(200)");
            
            builder.Property(p => p.TipoTransacao)
                .HasColumnType("varchar(200)");

            builder.HasOne(c => c.Caixa)
                .WithMany(c => c.Transacoes)
                .HasForeignKey(m => m.CaixaId);
        }
    }
}
