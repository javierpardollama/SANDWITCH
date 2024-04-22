using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using BenchmarkDotNet.Attributes;

using Sandwitch.Tier.ViewModels.Classes.Filters;
using Sandwitch.Tier.ViewModels.Classes.Views;

namespace Sandwitch.Tier.Benchmarks.Services
{
    public class VientoService
    {
        static readonly HttpClient Client = new() { BaseAddress = new Uri("https://localhost:7297/api/viento/") };

        [Benchmark]
        public async Task<IList<ViewViento>> FindAllViento()
        {
            Client.DefaultRequestHeaders.Authorization = new BasicAuthenticationHeaderValue("Peach", "T/R4J6eyvNG<6ne!");

            HttpResponseMessage @response = await Client.GetAsync("findallviento");
            @response.EnsureSuccessStatusCode();
            var @vientos = await @response.Content.ReadFromJsonAsync<List<ViewViento>>();          

            return @vientos;
        }

        [Benchmark]
        public async Task<ViewPage<ViewViento>> FindPaginatedViento()
        {
            Client.DefaultRequestHeaders.Authorization = new BasicAuthenticationHeaderValue("Peach", "T/R4J6eyvNG<6ne!");

            var @content = JsonContent.Create(new FilterPage { Index = 0, Size = 20 });

            HttpResponseMessage @response = await Client.PostAsync("findpaginatedviento", @content);
            @response.EnsureSuccessStatusCode();
            var @vientos = await @response.Content.ReadFromJsonAsync<ViewPage<ViewViento>>();           

            return @vientos;
        }

    }
}
