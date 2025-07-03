using NUnit.Framework;
using Sandwitch.Tier.ViewModels.Classes.Views;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Sandwitch.Tier.ViewModels.Classes.Finders;

namespace Sandwitch.Tier.Controllers.Tests.Classes
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class TestBuscadorController
    {
        static readonly HttpClient Client = new() { BaseAddress = new Uri("https://localhost:7297/api/buscador/") };

        /// <summary>
        /// Initializes a new Instance of <see cref="TestBuscadorController"/>
        /// </summary>
        public TestBuscadorController() => Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes("Peach" + ":" + "T/R4J6eyvNG<6ne!")));

        /// <summary>
        /// Sets Up
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Tears Down
        /// </summary>
        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public async Task FindAllBuscador()
        {
            HttpResponseMessage @response = await Client.GetAsync("findallbuscador");
            @response.EnsureSuccessStatusCode();
            var @buscadores = await @response.Content.ReadFromJsonAsync<List<ViewBuscador>>();

            Assert.Pass();
        }

        [Test]
        public async Task FindAllArenalByBuscadorId()
        {
            var @content = JsonContent.Create(new FinderArenal { Id = 1, Type = "Poblacion"});

            HttpResponseMessage @response = await Client.PostAsync("findallarenalbybuscadorid", @content);
            @response.EnsureSuccessStatusCode();
            var @arenales = await @response.Content.ReadFromJsonAsync<List<ViewArenal>>();

            Assert.Pass();
        }
    }
}
