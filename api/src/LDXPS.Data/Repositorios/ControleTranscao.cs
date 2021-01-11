
using LDXPS.Data.Contexto;
using LDXPS.Domain.Repositorios;
using System.Threading.Tasks;

namespace LDXPS.Data.Repositorios
{
    public class ControleTransacao : IControleTransacao
    {
        private readonly ContextoEF _contexto;
        public ControleTransacao(ContextoEF contexto)
        {
            _contexto = contexto;
        }
        public async Task<bool> Salvar()
        {
            return await _contexto.SaveChangesAsync() > 0;
        }
    }
}
