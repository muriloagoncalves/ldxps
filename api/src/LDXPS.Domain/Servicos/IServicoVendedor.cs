
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation.Results;
using LDXPS.Domain.Entidades;
using LDXPS.Domain.Paginations;

namespace LDXPS.Domain.Servicos
{
    public interface IServicoVendedor
    {
        Task<ValidationResult> Adicionar(Vendedor vendedor);
        Task<ValidationResult> Atualizar(Vendedor vendedor);
        Task<ICollection<Vendedor>> ObterTodos();
        Task<Pagination<Vendedor>> ObterTodos(Pagination<Vendedor> pagination);
        Task<Vendedor> Obter(Guid codigo);
        Task Deletar(Guid codigo);
    }
}
