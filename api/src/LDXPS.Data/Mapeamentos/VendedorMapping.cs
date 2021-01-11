
using LDXPS.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LDXPS.Data.Mapeamentos
{
    public class VendedorMapping : IEntityTypeConfiguration<Vendedor>
    {
        public void Configure(EntityTypeBuilder<Vendedor> builder)
        {
            builder.ToTable("VENDEDORES");

            builder.HasKey(x => x.Codigo);

            builder.Property(x => x.Codigo)
                .HasColumnName("CDVEND")
                .HasMaxLength(36);

            builder.Property(x => x.Nome)
                .HasColumnName("DSNOME")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.CodigoPrecoPadrao)
                .HasColumnName("CDTAB")
                .IsRequired();

            builder.Property(x => x.DataNascimento)
                .HasColumnName("DTNASC");

            builder.HasMany(x => x.Clientes)
                .WithOne(c => c.Vendedor)
                .HasForeignKey(v => v.CodigoVendedor)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
