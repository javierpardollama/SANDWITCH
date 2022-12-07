using NUnit.Framework;
using NUnit.Framework.Internal;

using Sandwitch.Tier.ViewModels.Classes.Filters;
using Sandwitch.Tier.ViewModels.Classes.Views;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
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
        public TestArenalController() 
        {
            Client.DefaultRequestHeaders.Authorization = new BasicAuthenticationHeaderValue("Peach", "T/R4J6eyvNG<6ne!");
        }

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
            string @responseBody = await @response.Content.ReadAsStringAsync();
            var @arenales = JsonSerializer.Deserialize<List<ViewArenal>>(@responseBody);

            Assert.Pass();
        }

        [Test]
        public async Task FindAllArenalByPoblacionId()
        {

            HttpResponseMessage @response = await Client.GetAsync(string.Concat("findallarenalbypoblacionid/", 1));
            @response.EnsureSuccessStatusCode();
            string @responseBody = await @response.Content.ReadAsStringAsync();
            var @arenales = JsonSerializer.Deserialize<List<ViewArenal>>(@responseBody);

            Assert.Pass();
        }

        [Test]
        public async Task FindAllHistoricoByArenalId()
        {

            HttpResponseMessage @response = await Client.GetAsync(string.Concat("findallhistoricobyarenalid/", 1));
            @response.EnsureSuccessStatusCode();
            string @responseBody = await @response.Content.ReadAsStringAsync();
            var @historicos = JsonSerializer.Deserialize<List<ViewHistorico>>(@responseBody);

            Assert.Pass();
        }

        [Test]
        public async Task FindPaginatedArenal()
        {

            var @content = JsonContent.Create(new FilterPage { Index = 0, Size = 20 });

            HttpResponseMessage @response = await Client.PostAsync("findpaginatedarenal", @content);
            @response.EnsureSuccessStatusCode();
            string @responseBody = await @response.Content.ReadAsStringAsync();
            var @arenales = JsonSerializer.Deserialize<ViewPage<ViewArenal>>(@responseBody);

            Assert.Pass();
        }
    }
}
