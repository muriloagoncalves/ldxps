using LDXPS.Data.Contexto;
using LDXPS.Data.Repositorios;
using LDXPS.Domain.Repositorios;
using LDXPS.Domain.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace LDXPS.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IServicoVendedor, ServicoVendedor>();
            services.AddScoped<IVendedorRepository, VendedorRepository>();
            services.AddScoped<IServicoCliente, ServicoCliente>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IControleTransacao, ControleTransacao>();
            services.AddScoped<ContextoEF>();
        }
    }
}
