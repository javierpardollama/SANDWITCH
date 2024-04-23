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
    public class TestPoblacionController
    {
        static readonly HttpClient Client = new() { BaseAddress = new Uri("https://localhost:7297/api/poblacion/") };

        /// <summary>
        /// Initializes a new Instance of <see cref="TestPoblacionController"/>
        /// </summary>
        public TestPoblacionController() => Client.DefaultRequestHeaders.Authorization = new BasicAuthenticationHeaderValue("Peach", "T/R4J6eyvNG<6ne!");

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
        public async Task FindAllPoblacion()
        {
            HttpResponseMessage @response = await Client.GetAsync("findallpoblacion");
            @response.EnsureSuccessStatusCode();
            var @poblaciones = await @response.Content.ReadFromJsonAsync<List<ViewPoblacion>>();          

            Assert.Pass();
        }

        [Test]
        public async Task FindAllPoblacionByProvinciaId()
        {
            HttpResponseMessage @response = await Client.GetAsync(string.Concat("findallpoblacionbyprovinciaid/", 1));
            @response.EnsureSuccessStatusCode();
            var @poblaciones = await @response.Content.ReadFromJsonAsync<List<ViewPoblacion>>();         

            Assert.Pass();
        }

        [Test]
        public async Task FindPaginatedPoblacion()
        {
            var @content = JsonContent.Create(new FilterPage { Index = 0, Size = 20 });

            HttpResponseMessage @response = await Client.PostAsync("findpaginatedpoblacion", @content);
            @response.EnsureSuccessStatusCode();
            var @poblaciones = await @response.Content.ReadFromJsonAsync<ViewPage<ViewPoblacion>>();

            Assert.Pass();
        }
    }
}
