
using LDXPS.Domain.Entidades;
using LDXPS.Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LDXPS.Data.Contexto;
using LDXPS.Data.Extensions;
using LDXPS.Domain.Paginations;
using Microsoft.EntityFrameworkCore;

namespace LDXPS.Data.Repositorios
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ContextoEF _contexto;

        public ClienteRepository(ContextoEF contexto)
        {
            _contexto = contexto;
        }

        public void Adicionar(Cliente cliente)
        {
            _contexto.Clientes.Add(cliente);
        }

        public void Atualizar(Cliente cliente)
        {
            _contexto.Clientes.Update(cliente);
        }

        public async Task<Cliente> Obter(Guid codigo)
        {
            return await _contexto.Clientes
                .Include(x => x.Vendedor)
                .FirstOrDefaultAsync(x => x.Codigo == codigo);
        }

        public async Task<IEnumerable<Cliente>> Obter(IEnumerable<Guid> codigos)
        {
            return await _contexto.Clientes.Where(x => codigos.ToList().Contains(x.Codigo)).ToListAsync();
        }
        public void Deletar(Cliente cliente)
        {
            _contexto.Clientes.Remove(cliente);
        }
        public async Task<List<Cliente>> ObterTodos()
        {
            return await _contexto.Clientes
                    .AsNoTracking()
                    .ToListAsync();
        }
        public async Task<List<Cliente>> ObterTodos(Pagination<Cliente> pagination)
        {
            return await _contexto.Clientes
                    .OrderByAscOrDesc(pagination.OrderByField, pagination.OrderByAscending)
                    .Pagination(pagination)
                    .AsNoTracking()
                    .ToListAsync();
        }
        public async Task<int> ObterQuantidade()
        {
            return await _contexto.Clientes.CountAsync();
        }
    }
}
