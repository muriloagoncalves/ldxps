
using System;

namespace LDXPS.Domain.Exceptions
{
    public class EntidadeNaoEncontradaException : Exception
    {
        public EntidadeNaoEncontradaException(string mensagem) : base(mensagem) { }
    }
}
