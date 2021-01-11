
using LDXPS.Domain.Entidades;
using System;
using System.Collections;
using System.Threading.Tasks;
using FluentValidation.Results;
using LDXPS.Domain.Exceptions;
using LDXPS.Domain.Paginations;
using LDXPS.Domain.Repositorios;
using System.Collections.Generic;
using System.Linq;

namespace LDXPS.Domain.Servicos
{
    public class ServicoVendedor : IServicoVendedor
    {
        private readonly IVendedorRepository _vendedorRepository;
        private readonly IClienteRepository _clienteRepository;

        public ServicoVendedor(IVendedorRepository vendedorRepository, IClienteRepository clienteRepository)
        {
            _vendedorRepository = vendedorRepository;
            _clienteRepository = clienteRepository;
        }

        public async Task<ValidationResult> Adicionar(Vendedor vendedor)
        {
            var vendedorBanco = await _vendedorRepository.Obter(vendedor.Codigo);
            if (vendedorBanco != null)
            {
                throw new Exception("Vendedor já cadastrado");
            }

            if(vendedor.Codigo == Guid.Empty) vendedor.Codigo = Guid.NewGuid();

            if (!vendedor.EhValido()) return vendedor.ValidationResult;
            var validationResult = await VerificarClientesJaCadastrados(vendedor);
            if (!validationResult.IsValid) return validationResult;

            _vendedorRepository.Adicionar(vendedor);
            return vendedor.ValidationResult;
        }

        private async Task<List<Cliente>> ObterClientesCadastrados(Vendedor vendedor)
        {
            var codigos = vendedor.Clientes.Select(x => x.Codigo).ToList();
            var clientesCadastrados = await _clienteRepository.Obter(codigos);
            return clientesCadastrados.ToList();
        }

        private async Task<ValidationResult> VerificarClientesJaCadastrados(Vendedor vendedor)
        {
            var codigos = vendedor.Clientes.Select(x => x.Codigo).ToList();
            var clientesCadastrados = await ObterClientesCadastrados(vendedor);
            var clienteNaoExiste = codigos.Except(clientesCadastrados.Select(x => x.Codigo)).ToList();
            var validationResult = new ValidationResult();
            if (clienteNaoExiste.Any())
            {
                foreach (var codigo in clienteNaoExiste)
                {
                    validationResult.Errors.Add(new ValidationFailure(nameof(Vendedor.Codigo), $"Cliente não existe {codigo}"));
                }
            }
            else
            {
                vendedor.Clientes.Clear();
                vendedor.Clientes = clientesCadastrados;
            }
            
            return validationResult;
        }
        public async Task<ValidationResult> Atualizar(Vendedor vendedor)
        {
            var vendedorBanco = await _vendedorRepository.Obter(vendedor.Codigo);
            if (vendedorBanco == null) throw new EntidadeNaoEncontradaException("Vendedor não encontrado");
            if (!vendedor.EhValido()) return vendedor.ValidationResult;

            vendedorBanco.Nome = vendedor.Nome;
            vendedorBanco.CodigoPrecoPadrao = vendedor.CodigoPrecoPadrao;
            vendedorBanco.DataNascimento = vendedor.DataNascimento;

            foreach (var cliente in vendedor.Clientes)
            {
                if (vendedorBanco.Clientes.All(x => x.Codigo != cliente.Codigo))
                {
                    var clienteCadastrado =  await _clienteRepository.Obter(cliente.Codigo);
                    vendedorBanco.Clientes.Add(clienteCadastrado);
                }
            }
            
            foreach (var cliente in vendedorBanco.Clientes)
            {
                if (vendedor.Clientes.All(x => x.Codigo != cliente.Codigo))
                {
                    vendedorBanco.Clientes.Remove(cliente);
                }
            }
            _vendedorRepository.Atualizar(vendedorBanco);

            return vendedor.ValidationResult;
        }

        public async Task<Vendedor> Obter(Guid codigo)
        {
            return await _vendedorRepository.Obter(codigo);
        }

        public async Task Deletar(Guid codigo)
        {
            var vendedorBanco = await _vendedorRepository.Obter(codigo);
            if (vendedorBanco == null) throw new EntidadeNaoEncontradaException("Vendedor não encontrado");
            _vendedorRepository.Deletar(vendedorBanco);
        }

        public async Task<ICollection<Vendedor>> ObterTodos()
        {
            return await _vendedorRepository.ObterTodos();
        }
        public async Task<Pagination<Vendedor>> ObterTodos(Pagination<Vendedor> pagination)
        {
            pagination.Data = await _vendedorRepository.ObterTodos(pagination);
            pagination.Total = await _vendedorRepository.ObterQuantidade();

            return pagination;
        }
    }
}
