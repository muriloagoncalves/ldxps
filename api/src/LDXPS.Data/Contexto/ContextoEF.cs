
using FluentValidation.Results;
using LDXPS.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LDXPS.Data.Contexto
{
    public class ContextoEF : DbContext
    {
        public ContextoEF(DbContextOptions<ContextoEF> options) : base(options) { }

        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => {  });
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<ValidationResult>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContextoEF).Assembly);
        }
    }
}
