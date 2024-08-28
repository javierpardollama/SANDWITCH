using NUnit.Framework;
using NUnit.Framework.Internal;

using Sandwitch.Tier.ViewModels.Classes.Filters;
using Sandwitch.Tier.ViewModels.Classes.Views;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Sandwitch.Tier.Controllers.Tests.Classes
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class TestArenalController
    {
        static readonly HttpClient Client = new() { BaseAddress = new Uri("https://localhost:7297/api/arenal/") };

        /// <summary>
        /// Initializes a new Instance of <see cref="TestArenalController"/>
        /// </summary>
        public TestArenalController() => Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes("Peach" + ":" + "T/R4J6eyvNG<6ne!")));

        /// <summary>
        /// Sets Up
        /// </summary>
        [SetUp]
        public void Setup() { 
        }

        /// <summary>
        /// Tears Down
        /// </summary>
        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public async Task FindAllarenal()
        {
            HttpResponseMessage @response = await Client.GetAsync("findallarenal");
            @response.EnsureSuccessStatusCode();
            var @arenales = await @response.Content.ReadFromJsonAsync<List<ViewArenal>>();           

            Assert.Pass();
        }

        [Test]
        public async Task FindAllArenalByPoblacionId()
        {
            HttpResponseMessage @response = await Client.GetAsync(string.Concat("findallarenalbypoblacionid/", 1));
            @response.EnsureSuccessStatusCode();
            var @arenales = await @response.Content.ReadFromJsonAsync<List<ViewArenal>>();

            Assert.Pass();
        }

        [Test]
        public async Task FindAllHistoricoByArenalId()
        {
            HttpResponseMessage @response = await Client.GetAsync(string.Concat("findallhistoricobyarenalid/", 1));
            @response.EnsureSuccessStatusCode();
            var @historicos = await @response.Content.ReadFromJsonAsync<List<ViewHistorico>>();

            Assert.Pass();
        }

        [Test]
        public async Task FindPaginatedArenal()
        {
            var @content = JsonContent.Create(new FilterPage { Index = 0, Size = 20 });

            HttpResponseMessage @response = await Client.PostAsync("findpaginatedarenal", @content);
            @response.EnsureSuccessStatusCode();
            var @arenales = await @response.Content.ReadFromJsonAsync<ViewPage<ViewArenal>>();

            Assert.Pass();
        }
    }
}
