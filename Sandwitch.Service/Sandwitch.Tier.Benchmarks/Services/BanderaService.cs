using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

using BenchmarkDotNet.Attributes;

using Sandwitch.Tier.ViewModels.Classes.Filters;
using Sandwitch.Tier.ViewModels.Classes.Views;

namespace Sandwitch.Tier.Benchmarks.Services
{
    public class BanderaService
    {
        static readonly HttpClient Client = new() { BaseAddress = new Uri("https://localhost:7297/api/bandera/") };

        [Benchmark]
        public async Task<IList<ViewBandera>> FindAllBandera()
        {
            Client.DefaultRequestHeaders.Authorization = new BasicAuthenticationHeaderValue("Peach", "T/R4J6eyvNG<6ne!");

            HttpResponseMessage @response = await Client.GetAsync("findallbandera");
            @response.EnsureSuccessStatusCode();
            string @responseBody = await @response.Content.ReadAsStringAsync();
            var @banderas = JsonSerializer.Deserialize<List<ViewBandera>>(@responseBody);

            return @banderas;

        }

        [Benchmark]
        public async Task<ViewPage<ViewBandera>> FindPaginatedBandera()
        {
            Client.DefaultRequestHeaders.Authorization = new BasicAuthenticationHeaderValue("Peach", "T/R4J6eyvNG<6ne!");

            var @content = JsonContent.Create(new FilterPage { Index = 0, Size = 20 });

            HttpResponseMessage @response = await Client.PostAsync("findpaginatedbandera", @content);
            @response.EnsureSuccessStatusCode();
            string @responseBody = await @response.Content.ReadAsStringAsync();
            var @banderas = JsonSerializer.Deserialize<ViewPage<ViewBandera>>(@responseBody);

            return @banderas;
        }

    }
}
