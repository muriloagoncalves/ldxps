
using LDXPS.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LDXPS.Data.Mapeamentos
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("CLIENTES");

            builder.HasKey(x => x.Codigo);

            builder.Property(x => x.Codigo)
                .HasColumnName("CDCL")
                .HasMaxLength(36);

            builder.Property(x => x.Nome)
                .HasColumnName("DSNOME")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.TipoPessoa)
                .HasColumnName("IDTIPO")
                .HasMaxLength(2)
                .IsRequired()
                .HasDefaultValue("PF");

            builder.Property(x => x.CodigoVendedor)
                .HasColumnName("CDVEND");

            builder.Property(x => x.LimiteCredito)
                .HasColumnName("DSLIM")
                .IsRequired()
                .HasPrecision(15, 2);
        }
    }
}
