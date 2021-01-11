
using System;
using System.Collections.Generic;
using FluentValidation.Results;
using LDXPS.Domain.Validacoes;

namespace LDXPS.Domain.Entidades
{
    public class Vendedor
    {
        protected Vendedor() { }
        public Vendedor(Guid codigo, string nome, int codigoPrecoPadrao)
        {
            Codigo = codigo;
            Nome = nome;
            CodigoPrecoPadrao = codigoPrecoPadrao;
            Clientes = new List<Cliente>();
        }

        public Guid Codigo { get; set; }
        public string Nome { get; set; }
        public int CodigoPrecoPadrao { get; set; }
        public DateTime? DataNascimento { get; set; }

        public ICollection<Cliente> Clientes { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool EhValido()
        {
            ValidationResult = new VendedorValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
