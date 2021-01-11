
using System;

namespace LDXPS.Common.Entidades
{
    public class Cliente
    {
        public Cliente()
        {
            TipoPessoa = "PF";
        }
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
    }
}
