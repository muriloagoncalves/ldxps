using LDXPS.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation.Results;
using LDXPS.Domain.Exceptions;
using LDXPS.Domain.Paginations;
using LDXPS.Domain.Repositorios;

namespace LDXPS.Domain.Servicos
{
    public class ServicoCliente : IServicoCliente
    {
        private readonly IClienteRepository _clienteRepository;

        public ServicoCliente(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ValidationResult> Adicionar(Cliente cliente)
        {
            var clienterBanco = await _clienteRepository.Obter(cliente.Codigo);
            if (clienterBanco != null)
            {
                throw new Exception("Cliente já cadastrado");
            }

            if(cliente.Codigo == Guid.Empty) cliente.Codigo = Guid.NewGuid();

            if (!cliente.EhValido()) return cliente.ValidationResult;
            _clienteRepository.Adicionar(cliente);
            return cliente.ValidationResult;
        }

        public async Task<ValidationResult> Atualizar(Cliente cliente)
        {
            var clienteBanco = await _clienteRepository.Obter(cliente.Codigo);
            if (clienteBanco == null) throw new EntidadeNaoEncontradaException("Cliente não encontrado");
            if (!cliente.EhValido()) return cliente.ValidationResult;

            clienteBanco.CodigoVendedor = cliente.CodigoVendedor;
            clienteBanco.Nome = cliente.Nome;
            clienteBanco.TipoPessoa = cliente.TipoPessoa;
            clienteBanco.LimiteCredito = cliente.LimiteCredito;

            _clienteRepository.Atualizar(clienteBanco);

            return cliente.ValidationResult;
        }

        public async Task<Cliente> Obter(Guid codigo)
        {
            return await _clienteRepository.Obter(codigo);
        }

        public async Task Deletar(Guid codigo)
        {
            var clienteBanco = await _clienteRepository.Obter(codigo);
            if (clienteBanco == null) throw new EntidadeNaoEncontradaException("Cliente não encontrado");
            _clienteRepository.Deletar(clienteBanco);
        }
        public async Task<ICollection<Cliente>> ObterTodos()
        {
            return await _clienteRepository.ObterTodos();
        }
        public async Task<Pagination<Cliente>> ObterTodos(Pagination<Cliente> pagination)
        {
            pagination.Data = await _clienteRepository.ObterTodos(pagination);
            pagination.Total = await _clienteRepository.ObterQuantidade();

            return pagination;
        }
    }
}
