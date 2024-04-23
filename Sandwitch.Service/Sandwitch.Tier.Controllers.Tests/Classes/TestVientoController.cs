using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using NUnit.Framework;
using NUnit.Framework.Internal;

using Sandwitch.Tier.ViewModels.Classes.Filters;
using Sandwitch.Tier.ViewModels.Classes.Views;

namespace Sandwitch.Tier.Controllers.Tests.Classes
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class TestVientoController
    {
        static readonly HttpClient Client = new() { BaseAddress = new Uri("https://localhost:7297/api/viento/") };

        /// <summary>
        /// Initializes a new Instance of <see cref="TestVientoController"/>
        /// </summary>
        public TestVientoController() => Client.DefaultRequestHeaders.Authorization = new BasicAuthenticationHeaderValue("Peach", "T/R4J6eyvNG<6ne!");

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
        public async Task FindAllViento()
        {
            HttpResponseMessage @response = await Client.GetAsync("findallviento");
            @response.EnsureSuccessStatusCode();
            var @vientos = await @response.Content.ReadFromJsonAsync<List<ViewViento>>();           

            Assert.Pass();
        }

        [Test]
        public async Task FindPaginatedViento()
        {
            var @content = JsonContent.Create(new FilterPage { Index = 0, Size = 20 });

            HttpResponseMessage @response = await Client.PostAsync("findpaginatedviento", @content);
            @response.EnsureSuccessStatusCode();
            var @vientos = await @response.Content.ReadFromJsonAsync<ViewPage<ViewViento>>();

            Assert.Pass();
        }
    }
}
