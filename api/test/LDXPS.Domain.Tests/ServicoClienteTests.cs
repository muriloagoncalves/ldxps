
using LDXPS.Domain.Entidades;
using LDXPS.Domain.Repositorios;
using LDXPS.Domain.Servicos;
using LDXPS.Domain.Tests.Builders;
using Moq;
using Xunit;

namespace LDXPS.Domain.Tests
{
    public class ServicoClienteTests
    {
        [Fact]
        public void AdicionarVendedor_Valido_DeveExecutar()
        {
            var cliente = new ClienteBuilder().Valido().Build();

            var servicoCliente = new Mock<IServicoCliente>();
            var clienteRepository = new Mock<IClienteRepository>();
            var controleTransacao = new Mock<IControleTransacao>();

            controleTransacao.Setup(c => c.Salvar()).ReturnsAsync(true);

            clienteRepository.Setup(v => v.Obter(cliente.Codigo)).ReturnsAsync((Cliente) null);

            servicoCliente.Setup(s => s.Adicionar(cliente));

            Assert.True(cliente.EhValido());
        }
        [Fact]
        public void AdicionarVendedor_InValido_NaoDeveExecutar()
        {
            var cliente = new ClienteBuilder().InValido().Build();

            var servicoCliente = new Mock<IServicoCliente>();
            var clienteRepository = new Mock<IClienteRepository>();
            var controleTransacao = new Mock<IControleTransacao>();

            controleTransacao.Setup(c => c.Salvar()).ReturnsAsync(true);

            clienteRepository.Setup(v => v.Obter(cliente.Codigo)).ReturnsAsync((Cliente) null);

            servicoCliente.Setup(s => s.Adicionar(cliente));

            Assert.False(cliente.EhValido());
        }
    }
}
