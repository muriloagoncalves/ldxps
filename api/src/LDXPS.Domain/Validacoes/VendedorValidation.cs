using System;
using FluentValidation;
using LDXPS.Domain.Entidades;

namespace LDXPS.Domain.Validacoes
{
    public class VendedorValidation : AbstractValidator<Vendedor>
    {
        public VendedorValidation()
        {
            RuleFor(v => v.Codigo)
                .NotEqual(Guid.Empty)
                .WithMessage(CodigoVendedorErroMsg);

            RuleFor(v => v.Nome)
                .NotEmpty()
                .WithMessage(NomeVendedorErroMsg);

            RuleFor(v => v.CodigoPrecoPadrao)
                .GreaterThan(0)
                .WithMessage(CodigoPrecoPadraoErroMsg);
        }

        public static string CodigoVendedorErroMsg = "Codigo do vendedor inválido";
        public static string NomeVendedorErroMsg = "Nome do vendedor deve ser informado";
        public static string CodigoPrecoPadraoErroMsg = "Codigo do preço padrão deve ser informado";
    }
}