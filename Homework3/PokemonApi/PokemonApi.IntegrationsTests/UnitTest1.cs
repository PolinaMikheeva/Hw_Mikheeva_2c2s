using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NUnit.Framework;
using PokemonApi.Controllers;
using PokemonApi.DataAccess;
using PokemonApi.DataAccess.Entities;
using System.Net;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace PokemonApi.IntegrationsTests
{
    [TestFixture]
    public class UnitTest1
    {
        private WebApplication _app = null!;
        private AppDbContext _context = null!;
        private HttpClient _client = null!;
        private IServiceScope _scope = null!;

        [SetUp]
        public async Task Setup()
        {
            var builder = WebApplication.CreateBuilder();
            _app = builder.Build();
            _app.Urls.Add("http://*:8080");
            await _app.StartAsync();
            _scope = _app.Services.CreateScope();
            _context = _scope.ServiceProvider.GetRequiredService<AppDbContext>();
            _client = new HttpClient { BaseAddress = new Uri("http://localhost:8080") };
        }

        /*
        [Test]
        public async Task GetByFilter_ReturnsCorrectPokemonList()
        {
            // ����������
            string filterName = "pikachu";



            // �����������
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());

            var pokemon = result.First();
            Assert.AreEqual(25, pokemon.Id);
            Assert.AreEqual("pikachu", pokemon.Name);
        }
        */

        [Test]
        public async Task GetByIdOrName_ReturnsCorrectPokemon()
        {
            // ���������� �������
            var response = await _client.GetAsync("api/pokemon/NameOrId?nameOrId=pikachu");

            // �������� ��������� ������
            response.EnsureSuccessStatusCode();

            // �������� ����������� ������
            var content = await response.Content.ReadAsStringAsync();

            // ������������� ������ � ������ ���� Pokemon
            var pokemon = JsonConvert.DeserializeObject<Pokemon>(content);

            Assert.AreEqual("Pikachu", pokemon.Name); // ���������, ��� �������� ��������� �������
        }

        [Test]
        public async Task GetByIdOrName_InvalidInput_ReturnsNotFound()
        {
            // ���������� ������� � ������������ ������ ��� ID
            var response = await _client.GetAsync("api/pokemon/NameOrId?nameOrId=invalid");

            // �������� ������� Not Found
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TearDown]
        public void TearDown()
        {
            // ������������ �������� HttpClient
            _client.Dispose();
        }
    }
}