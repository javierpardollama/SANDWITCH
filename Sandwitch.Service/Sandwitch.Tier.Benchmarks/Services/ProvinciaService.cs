using BenchmarkDotNet.Attributes;

using Sandwitch.Tier.ViewModels.Classes.Filters;
using Sandwitch.Tier.ViewModels.Classes.Views;

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sandwitch.Tier.Benchmarks.Services
{
    public class ProvinciaService
    {
        static readonly NetworkCredential Credentials = new("Peach", "T/R4J6eyvNG<6ne!");
        static readonly HttpClientHandler Handler = new() { Credentials = Credentials };
        static readonly HttpClient Client = new(Handler) { BaseAddress = new Uri("https://localhost:7214/api/provincia/") };

        [Benchmark]
        public async Task<IList<ViewProvincia>> FindAllProvincia()
        {
            HttpResponseMessage @response = await Client.GetAsync("findallprovincia");
            @response.EnsureSuccessStatusCode();
            string @responseBody = await @response.Content.ReadAsStringAsync();
            var @provincias = JsonSerializer.Deserialize<List<ViewProvincia>>(@responseBody);

            return @provincias;

        }

        [Benchmark]
        public async Task<ViewPage<ViewProvincia>> FindPaginatedProvincia()
        {
            var @content = JsonContent.Create(new FilterPage { Index = 0, Size = 20 });

            HttpResponseMessage @response = await Client.PostAsync("findpaginatedprovincia", @content);
            @response.EnsureSuccessStatusCode();
            string @responseBody = await @response.Content.ReadAsStringAsync();
            var @provincias = JsonSerializer.Deserialize<ViewPage<ViewProvincia>>(@responseBody);

            return @provincias;
        }

    }
}
