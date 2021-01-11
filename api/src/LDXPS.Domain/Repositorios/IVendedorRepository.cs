using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LDXPS.Domain.Entidades;
using LDXPS.Domain.Paginations;

namespace LDXPS.Domain.Repositorios
{
    public interface IVendedorRepository
    {
        void Adicionar(Vendedor vendedor);
        void Atualizar(Vendedor vendedor);
        Task<List<Vendedor>> ObterTodos();
        Task<List<Vendedor>> ObterTodos(Pagination<Vendedor> pagination);
        Task<int> ObterQuantidade();
        Task<Vendedor> Obter(Guid codigo);
        void Deletar(Vendedor vendedor);
    }
}
