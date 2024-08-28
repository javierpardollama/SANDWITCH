using BenchmarkDotNet.Attributes;

using Sandwitch.Tier.ViewModels.Classes.Filters;
using Sandwitch.Tier.ViewModels.Classes.Views;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Sandwitch.Tier.Benchmarks.Services
{
    public class ProvinciaService
    {
        static readonly HttpClient Client = new() { BaseAddress = new Uri("https://localhost:7297/api/provincia/")};

        [Benchmark]
        public async Task<IList<ViewProvincia>> FindAllProvincia()
        {
            Client.DefaultRequestHeaders.Authorization = Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes("Peach" + ":" + "T/R4J6eyvNG<6ne!"))); ;

            HttpResponseMessage @response = await Client.GetAsync("findallprovincia");
            @response.EnsureSuccessStatusCode();
            var @provincias = await @response.Content.ReadFromJsonAsync<List<ViewProvincia>>();

            return @provincias;

        }

        [Benchmark]
        public async Task<ViewPage<ViewProvincia>> FindPaginatedProvincia()
        {
            Client.DefaultRequestHeaders.Authorization = Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes("Peach" + ":" + "T/R4J6eyvNG<6ne!"))); ;

            var @content = JsonContent.Create(new FilterPage { Index = 0, Size = 20 });

            HttpResponseMessage @response = await Client.PostAsync("findpaginatedprovincia", @content);
            @response.EnsureSuccessStatusCode();
            var @provincias = await @response.Content.ReadFromJsonAsync<ViewPage<ViewProvincia>>();

            return @provincias;
        }

    }
}
