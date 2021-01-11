
using System.Threading.Tasks;
using FluentValidation.Results;
using LDXPS.Domain.Entidades;
using LDXPS.Domain.Repositorios;
using LDXPS.Domain.Servicos;
using LDXPS.Domain.Tests.Builders;
using Moq;
using Xunit;

namespace LDXPS.Domain.Tests
{
    public class ServicoVendedorTests
    {
        [Fact]
        public void AdicionarVendedor_Valido_DeveExecutar()
        {
            var vendedor = new VendedorBuilder().Valido().Build();

            var servicoVendedor = new Mock<IServicoVendedor>();
            var vendedorRepository = new Mock<IVendedorRepository>();
            var controleTransacao = new Mock<IControleTransacao>();

            controleTransacao.Setup(c => c.Salvar()).ReturnsAsync(true);

            vendedorRepository.Setup(v => v.Obter(vendedor.Codigo)).ReturnsAsync((Vendedor) null);

            servicoVendedor.Setup(s => s.Adicionar(vendedor));

            Assert.True(vendedor.EhValido());
        }
        [Fact]
        public void AdicionarVendedor_InValido_NaoDeveExecutar()
        {
            var vendedor = new VendedorBuilder().InValido().Build();

            var servicoVendedor = new Mock<IServicoVendedor>();
            var vendedorRepository = new Mock<IVendedorRepository>();
            var controleTransacao = new Mock<IControleTransacao>();

            controleTransacao.Setup(c => c.Salvar()).ReturnsAsync(true);

            vendedorRepository.Setup(v => v.Obter(vendedor.Codigo)).ReturnsAsync((Vendedor) null);

            servicoVendedor.Setup(s => s.Adicionar(vendedor));

            Assert.False(vendedor.EhValido());
        }
    }
}
