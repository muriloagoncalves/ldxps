
using System.Linq;
using System.Threading.Tasks;
using LDXPS.Domain.Entidades;
using LDXPS.Domain.Tests.Builders;
using LDXPS.Domain.Validacoes;
using Xunit;

namespace LDXPS.Domain.Tests
{
    public class VendedorTests
    {
        [Fact]
        public void Vendedor_Valido()
        {
            var vendedor = new VendedorBuilder().Valido().Build();

            Assert.True(vendedor.EhValido());
            Assert.Equal(0, vendedor.ValidationResult.Errors.Count);
        }

        [Fact]
        public void Vendedor_Invalido()
        {
            var vendedor = new VendedorBuilder().InValido().Build();

            var result = vendedor.EhValido();

            Assert.False(result);
            Assert.Equal(3, vendedor.ValidationResult.Errors.Count);
            Assert.Contains(VendedorValidation.CodigoVendedorErroMsg,
                vendedor.ValidationResult.Errors.Select(e => e.ErrorMessage));
            Assert.Contains(VendedorValidation.NomeVendedorErroMsg,
                vendedor.ValidationResult.Errors.Select(e => e.ErrorMessage));
            Assert.Contains(VendedorValidation.CodigoPrecoPadraoErroMsg,
                vendedor.ValidationResult.Errors.Select(e => e.ErrorMessage));
        }
    }
}
