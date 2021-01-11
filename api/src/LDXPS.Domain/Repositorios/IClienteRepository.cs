using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LDXPS.Domain.Entidades;
using LDXPS.Domain.Paginations;

namespace LDXPS.Domain.Repositorios
{
    public interface IClienteRepository
    {
        void Adicionar(Cliente cliente);
        void Atualizar(Cliente cliente);
        Task<List<Cliente>> ObterTodos();
        Task<List<Cliente>> ObterTodos(Pagination<Cliente> pagination);
        Task<int> ObterQuantidade();
        Task<Cliente> Obter(Guid codigo);
        Task<IEnumerable<Cliente>> Obter(IEnumerable<Guid> codigos);
        void Deletar(Cliente vendedor);
    }
}
