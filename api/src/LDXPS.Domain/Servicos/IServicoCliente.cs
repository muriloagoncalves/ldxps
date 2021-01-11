
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation.Results;
using LDXPS.Domain.Entidades;
using LDXPS.Domain.Paginations;

namespace LDXPS.Domain.Servicos
{
    public interface IServicoCliente
    {
        Task<ValidationResult> Adicionar(Cliente cliente);
        Task<ValidationResult> Atualizar(Cliente cliente);
        Task<ICollection<Cliente>> ObterTodos();
        Task<Pagination<Cliente>> ObterTodos(Pagination<Cliente> pagination);
        Task<Cliente> Obter(Guid codigo);
        Task Deletar(Guid codigo);
    }
}
