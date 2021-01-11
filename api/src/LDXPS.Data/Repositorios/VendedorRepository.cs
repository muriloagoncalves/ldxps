
using LDXPS.Domain.Entidades;
using LDXPS.Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LDXPS.Data.Contexto;
using LDXPS.Data.Extensions;
using LDXPS.Domain.Paginations;
using Microsoft.EntityFrameworkCore;

namespace LDXPS.Data.Repositorios
{
    public class VendedorRepository : IVendedorRepository
    {
        private readonly ContextoEF _contexto;

        public VendedorRepository(ContextoEF contexto)
        {
            _contexto = contexto;
        }

        public void Adicionar(Vendedor vendedor)
        {
            _contexto.Vendedores.Add(vendedor);
        }

        public void Atualizar(Vendedor vendedor)
        {
            _contexto.Vendedores.Update(vendedor);
        }

        public async Task<Vendedor> Obter(Guid codigo)
        {
            return await _contexto.Vendedores
                .Include(x => x.Clientes)
                .FirstOrDefaultAsync(x => x.Codigo == codigo);
        }

        public void Deletar(Vendedor vendedor)
        {
            _contexto.Vendedores.Remove(vendedor);
        }
        public async Task<List<Vendedor>> ObterTodos()
        {
            return await _contexto.Vendedores
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<List<Vendedor>> ObterTodos(Pagination<Vendedor> pagination)
        {
            return await _contexto.Vendedores
                    .OrderByAscOrDesc(pagination.OrderByField, pagination.OrderByAscending)
                    .Pagination(pagination)
                    .AsNoTracking()
                    .ToListAsync();
        }

        public async Task<int> ObterQuantidade()
        {
            return await _contexto.Vendedores.CountAsync();
        }
    }
}
