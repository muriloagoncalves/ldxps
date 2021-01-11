
using FluentValidation;
using LDXPS.Domain.Entidades;
using System;
using System.Linq;

namespace LDXPS.Domain.Validacoes
{
    public class ClienteValidation : AbstractValidator<Cliente>
    {
        public ClienteValidation()
        {
            RuleFor(v => v.Codigo)
                .NotEqual(Guid.Empty)
                .WithMessage(CodigoClienteErroMsg);

            RuleFor(v => v.Nome)
                .NotEmpty()
                .WithMessage(NomeClienteErroMsg);

            RuleFor(c => c.TipoPessoa)
                .Must(c => new[] { "PF", "PJ" }.Contains(c))
                .WithMessage(TipoPessoaClienteErroMsg);
        }

        public static string CodigoClienteErroMsg = "Codigo do cliente inválido";
        public static string NomeClienteErroMsg = "Nome do cliente deve ser informado";
        public static string TipoPessoaClienteErroMsg = "Tipo pessoa do cliente inválido";
    }
}
