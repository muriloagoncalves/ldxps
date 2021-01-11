using System;
using LDXPS.Domain.Entidades;

namespace LDXPS.Domain.Tests.Builders
{
    public class VendedorBuilder
    {
        private int _codigoPrecoPadrao;
        private string _nome;
        private Guid _codigo;

        public VendedorBuilder Valido()
        {
            _codigo = Guid.NewGuid();
            _nome = "VENDEDOR TESTE 1";
            _codigoPrecoPadrao = 1;
            return this;
        }

        public VendedorBuilder InValido()
        {
            _codigo = Guid.Empty;
            _nome = "";
            _codigoPrecoPadrao = 0;
            return this;
        }
        public Vendedor Build()
        {
            return new Vendedor(_codigo, _nome, _codigoPrecoPadrao);
        }
    }
}
