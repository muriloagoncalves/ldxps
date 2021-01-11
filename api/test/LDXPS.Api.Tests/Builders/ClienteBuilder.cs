using System;
using LDXPS.Domain.Entidades;

namespace LDXPS.Api.Tests.Builders
{
    public class ClienteBuilder
    {
        private string _nome;
        private Guid _codigo;
        private string _tipoPessoa;

        public ClienteBuilder Valido(string codigo)
        {
            _codigo = new Guid(codigo);
            _nome = "CLIENTE TESTE VALIDO";
            _tipoPessoa = "PF";
            return this;
        }

        public ClienteBuilder Invalido()
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
