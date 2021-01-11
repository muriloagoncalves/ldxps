
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
    public class ClienteApiTests
    {
        private readonly IntegrationTestsFixture<StartupApiTests> _testsFixture;

        public ClienteApiTests(IntegrationTestsFixture<StartupApiTests> testsFixture)
        {
            _testsFixture = testsFixture;
        }

        private const string _codigo = "181ed528-e0e4-47e0-bd5d-97385bce218f";

        [Fact(DisplayName = "Adicionar Cliente Valido"), TestPriority(6)]
        public async Task AdicionarCliente_Valido_DeveRetornarSucesso()
        {
            var clienteView = new ClienteBuilder().Valido(_codigo).Build();

            var postResponse = await _testsFixture.Client.PostAsJsonAsync("api/cliente", clienteView);

            postResponse.EnsureSuccessStatusCode();
            Assert.True(postResponse.StatusCode == HttpStatusCode.Created);
        }
        [Fact(DisplayName = "Atualizar Cliente Valido"), TestPriority(7)]
        public async Task AtualizarCliente_Valido_DeveRetornarSucesso()
        {
            var clienteView = new ClienteBuilder().Valido(_codigo).Build();

            var putResponse = await _testsFixture.Client.PutAsJsonAsync($"api/cliente/{clienteView.Codigo}", clienteView);

            putResponse.EnsureSuccessStatusCode();
            Assert.True(putResponse.StatusCode == HttpStatusCode.NoContent);
        }

        [Fact(DisplayName = "Excluir Cliente Valido"), TestPriority(8)]
        public async Task RemoverCliente_DeveRetornarSucesso()
        {
            var codigo = new Guid(_codigo);
            
            var deleteResponse = await _testsFixture.Client.DeleteAsync($"api/cliente/{codigo}");
            
            deleteResponse.EnsureSuccessStatusCode();
        }
        [Fact(DisplayName = "Adicionar Cliente Invalido"), TestPriority(9)]
        public async Task AdicionarCliente_Invalido_NaoDeveRetornarSucesso()
        {
            var clienteView = new ClienteBuilder().Invalido().Build();


            var postResponse = await _testsFixture.Client.PostAsJsonAsync("api/cliente", clienteView);

            Assert.True(postResponse.StatusCode != HttpStatusCode.Created);
        }

        [Fact(DisplayName = "Atualizar Cliente Invalido"), TestPriority(10)]
        public async Task AtualizarCliente_Invalido_NaoDeveRetornarSucesso()
        {
            var clienteView = new VendedorBuilder().Invalido().Build();


            var putResponse = await _testsFixture.Client.PutAsJsonAsync("api/cliente", clienteView);

            Assert.True(putResponse.StatusCode != HttpStatusCode.NoContent);
        }
    }
}
