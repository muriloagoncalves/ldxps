
using System;
using System.Collections.Generic;

namespace LDXPS.Common.Entidades
{
    public class Vendedor
    {
        public Vendedor()
        {
            CodigoPrecoPadrao = 1;
        }
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

        public IList<Cliente> Clientes { get; set; }
    }
}
