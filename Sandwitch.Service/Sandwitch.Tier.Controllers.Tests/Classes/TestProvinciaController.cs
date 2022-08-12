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
    public class TestProvinciaController
    {
        static readonly HttpClient Client = new() { BaseAddress = new Uri("https://localhost:7297/api/provincia/") };

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
        public async Task FindAllProvincia()
        {
            Client.DefaultRequestHeaders.Authorization = new BasicAuthenticationHeaderValue("Peach", "T/R4J6eyvNG<6ne!");

            HttpResponseMessage @response = await Client.GetAsync("findallprovincia");
            @response.EnsureSuccessStatusCode();
            string @responseBody = await @response.Content.ReadAsStringAsync();
            var @provincias = JsonSerializer.Deserialize<List<ViewProvincia>>(@responseBody);

            Assert.Pass();
        }

        [Test]
        public async Task FindPaginatedProvincia()
        {
            Client.DefaultRequestHeaders.Authorization = new BasicAuthenticationHeaderValue("Peach", "T/R4J6eyvNG<6ne!");

            var @content = JsonContent.Create(new FilterPage { Index = 0, Size = 20 });

            HttpResponseMessage @response = await Client.PostAsync("findpaginatedprovincia", @content);
            @response.EnsureSuccessStatusCode();
            string @responseBody = await @response.Content.ReadAsStringAsync();
            var @provincias = JsonSerializer.Deserialize<ViewPage<ViewProvincia>>(@responseBody);

            Assert.Pass();
        }
    }
}
