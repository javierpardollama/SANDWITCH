﻿using System;
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
    public class TestProvinciaController
    {
        static readonly HttpClient Client = new() { BaseAddress = new Uri("https://localhost:7297/api/provincia/") };

        /// <summary>
        /// Initializes a new Instance of <see cref="TestProvinciaController"/>
        /// </summary>
        public TestProvinciaController() => Client.DefaultRequestHeaders.Authorization = new BasicAuthenticationHeaderValue("Peach", "T/R4J6eyvNG<6ne!");

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
            HttpResponseMessage @response = await Client.GetAsync("findallprovincia");
            @response.EnsureSuccessStatusCode();
            var @provincias = await @response.Content.ReadFromJsonAsync<List<ViewProvincia>>();          

            Assert.Pass();
        }

        [Test]
        public async Task FindPaginatedProvincia()
        {
            var @content = JsonContent.Create(new FilterPage { Index = 0, Size = 20 });

            HttpResponseMessage @response = await Client.PostAsync("findpaginatedprovincia", @content);
            @response.EnsureSuccessStatusCode();
            var @provincias = await @response.Content.ReadFromJsonAsync<ViewPage<ViewProvincia>>();

            Assert.Pass();
        }
    }
}
