
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LDXPS.Common.Entidades;
using LDXPS.Common.Http;

namespace LDXPS.Common
{
    public class Servico : ServicoHttp
    {

        #region Vendedor

        public async Task<ListaRetornoApi<Vendedor>> ObterVendedores()
        {
            var urlParam = new UrlRouteBuilder()
                .ParamString("vendedor")
                .Build();
            var retorno = await GetAsync<ListaRetornoApi<Vendedor>>(urlParam);
            if (retorno.HouveErro || retorno.Dados == null) return null;
            return retorno.Dados;
        }

        public async Task<Vendedor> ObterVendedor(string codigo)
        {
            var urlParam = new UrlRouteBuilder()
                .ParamString("vendedor")
                .ParamString(codigo)
                .Build();
            var retorno = await GetAsync<Vendedor>(urlParam);
            if (retorno.HouveErro) return null;
            return retorno.Dados;
        }

        public async Task<bool> AdicionarVendedor(Vendedor vendedor)
        {
            var urlParam = new UrlRouteBuilder()
                .ParamString("vendedor")
                .Build();
            var retorno = await PostAsync<Vendedor, Vendedor>(urlParam, vendedor);
            return !retorno.HouveErro;
        }
        public async Task<bool> AtualizarVendedor(string codigo, Vendedor vendedor)
        {
            var urlParam = new UrlRouteBuilder()
                .ParamString("vendedor")
                .ParamString(codigo)
                .Build();
            var retorno = await PutAsync<Vendedor, Vendedor>(urlParam, vendedor);
            return !retorno.HouveErro;
        }
        public async Task<bool> DeletarVendedor(string codigo)
        {
            var urlParam = new UrlRouteBuilder()
                .ParamString("vendedor")
                .ParamString(codigo)
                .Build();
            var retorno = await DeleteAsync(urlParam);
            return !retorno.HouveErro;
        }

        #endregion

        #region Cliente

        public async Task<ListaRetornoApi<Cliente>> ObterClientes()
        {
            var urlParam = new UrlRouteBuilder()
                .ParamString("cliente")
                .Build();
            var retorno = await GetAsync<ListaRetornoApi<Cliente>>(urlParam);
            if (retorno.HouveErro || retorno.Dados == null) return null;
            return retorno.Dados;
        }

        public async Task<Cliente> ObterCliente(string codigo)
        {
            var urlParam = new UrlRouteBuilder()
                .ParamString("cliente")
                .ParamString(codigo)
                .Build();
            var retorno = await GetAsync<Cliente>(urlParam);
            if (retorno.HouveErro) return null;
            return retorno.Dados;
        }

        public async Task<bool> AdicionarCliente(Cliente cliente)
        {
            var urlParam = new UrlRouteBuilder()
                .ParamString("cliente")
                .Build();
            var retorno = await PostAsync<Cliente, Cliente>(urlParam, cliente);
            return !retorno.HouveErro;
        }
        public async Task<bool> AtualizarCliente(string codigo, Cliente cliente)
        {
            var urlParam = new UrlRouteBuilder()
                .ParamString("cliente")
                .ParamString(codigo)
                .Build();
            var retorno = await PutAsync<Cliente, Cliente>(urlParam, cliente);
            return !retorno.HouveErro;
        }
        public async Task<bool> DeletarCliente(string codigo)
        {
            var urlParam = new UrlRouteBuilder()
                .ParamString("cliente")
                .ParamString(codigo)
                .Build();
            var retorno = await DeleteAsync(urlParam);
            return !retorno.HouveErro;
        }

        #endregion
        
    }
}
