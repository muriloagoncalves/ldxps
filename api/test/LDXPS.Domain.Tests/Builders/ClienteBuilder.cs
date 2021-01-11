using System;
using LDXPS.Domain.Entidades;

namespace LDXPS.Domain.Tests.Builders
{
    public class ClienteBuilder
    {
        private string _nome;
        private Guid _codigo;
        private string _tipoPessoa;

        public ClienteBuilder Valido()
        {
            _nome = "CLIENTE TESTE VALIDO";
            _codigo = Guid.NewGuid();
            _tipoPessoa = "PF";
            return this;
        }

        public ClienteBuilder InValido()
        {
            _nome = "";
            _codigo = Guid.Empty;
            _tipoPessoa = "XX";
            return this;
        }

        public Cliente Build()
        {
            return new Cliente(_codigo, _nome, _tipoPessoa);
        }
    }
}
