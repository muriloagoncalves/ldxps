
using System;
using FluentValidation.Results;
using LDXPS.Domain.Validacoes;

namespace LDXPS.Domain.Entidades
{
    public class Cliente
    {
        protected Cliente() { }

        public Cliente(Guid codigo, string nome, string tipoPessoa)
        {
            Codigo = codigo;
            Nome = nome;
            TipoPessoa = tipoPessoa;
        }

        public Guid Codigo { get; set; }
        public string Nome { get; set; }
        public string TipoPessoa { get; set; }
        public Guid? CodigoVendedor { get; set; }
        public Vendedor Vendedor { get; set; }
        public decimal LimiteCredito { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool EhValido()
        {
            ValidationResult = new ClienteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
