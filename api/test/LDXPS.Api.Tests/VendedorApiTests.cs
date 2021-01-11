
using System;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using LDXPS.Api.Tests.Builders;
using LDXPS.Api.Tests.Config;
using LDXPS.Api.Tests.Features;
using Xunit;

namespace LDXPS.Api.Tests
{
    [TestCaseOrderer("LDXPS.Api.Tests.Features.PriorityOrderer", "LDXPS.Api.Tests")]
    [Collection(nameof(IntegrationApiTestsFixtureCollection))]
    public class VendedorApiTests
    {
        private readonly IntegrationTestsFixture<StartupApiTests> _testsFixture;

        public VendedorApiTests(IntegrationTestsFixture<StartupApiTests> testsFixture)
        {
            _testsFixture = testsFixture;
        }

        [Fact(DisplayName = "Adicionar Vendedor Valido"), TestPriority(1)]
        public async Task AdicionarVendedor_Valido_DeveRetornarSucesso()
        {
            var vendedorView = new VendedorBuilder().Valido("58b9fbc0-bb23-4901-b065-6a330ff01f64").Build();

            var postResponse = await _testsFixture.Client.PostAsJsonAsync("api/vendedor", vendedorView);

            postResponse.EnsureSuccessStatusCode();
            Assert.True(postResponse.StatusCode == HttpStatusCode.Created);
        }

        [Fact(DisplayName = "Atualizar Vendedor Valido"), TestPriority(2)]
        public async Task AtualizarVendedor_Valido_DeveRetornarSucesso()
        {
            var vendedorView = new VendedorBuilder().Valido("58b9fbc0-bb23-4901-b065-6a330ff01f64").Build();

            var putResponse = await _testsFixture.Client.PutAsJsonAsync($"api/vendedor/{vendedorView.Codigo}", vendedorView);

            putResponse.EnsureSuccessStatusCode();
            Assert.True(putResponse.StatusCode == HttpStatusCode.NoContent);
        }

        [Fact(DisplayName = "Excluir Vendedor Valido"), TestPriority(3)]
        public async Task RemoverVendedor_DeveRetornarSucesso()
        {
            var codigo = new Guid("58b9fbc0-bb23-4901-b065-6a330ff01f64");
            
            var deleteResponse = await _testsFixture.Client.DeleteAsync($"api/vendedor/{codigo}");
            
            deleteResponse.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Adicionar Vendedor Invalido"), TestPriority(4)]
        public async Task AdicionarVendedor_Invalido_NaoDeveRetornarSucesso()
        {
            var vendedorView = new VendedorBuilder().Invalido().Build();


            var postResponse = await _testsFixture.Client.PostAsJsonAsync("api/vendedor", vendedorView);

            Assert.True(postResponse.StatusCode != HttpStatusCode.Created);
        }

        [Fact(DisplayName = "Atualizar Vendedor Invalido"), TestPriority(5)]
        public async Task AtualizarVendedor_Invalido_NaoDeveRetornarSucesso()
        {
            var vendedorView = new VendedorBuilder().Invalido().Build();


            var putResponse = await _testsFixture.Client.PutAsJsonAsync("api/vendedor", vendedorView);

            Assert.True(putResponse.StatusCode != HttpStatusCode.NoContent);
        }
    }
}
