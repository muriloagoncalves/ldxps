
using System.Linq;
using LDXPS.Domain.Tests.Builders;
using LDXPS.Domain.Validacoes;
using Xunit;

namespace LDXPS.Domain.Tests
{
    public class ClienteTests
    {
        [Fact]
        public void Cliente_Valido()
        {
            var cliente = new ClienteBuilder().Valido().Build();

            Assert.True(cliente.EhValido());
            Assert.Equal(0, cliente.ValidationResult.Errors.Count);
        }

        [Fact]
        public void Cliente_Invalido()
        {
            var cliente = new ClienteBuilder().InValido().Build();

            var result = cliente.EhValido();

            Assert.False(result);
            Assert.Equal(3, cliente.ValidationResult.Errors.Count);

            Assert.Contains(ClienteValidation.CodigoClienteErroMsg,
                cliente.ValidationResult.Errors.Select(e => e.ErrorMessage));
            Assert.Contains(ClienteValidation.NomeClienteErroMsg,
                cliente.ValidationResult.Errors.Select(e => e.ErrorMessage));
            Assert.Contains(ClienteValidation.TipoPessoaClienteErroMsg,
                cliente.ValidationResult.Errors.Select(e => e.ErrorMessage));
        }
    }
}
