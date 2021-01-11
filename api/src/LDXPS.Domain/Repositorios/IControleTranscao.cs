
using System.Threading.Tasks;

namespace LDXPS.Domain.Repositorios
{
    public interface IControleTransacao
    {
        Task<bool>  Salvar();
    }
}
