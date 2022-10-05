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
    public class ArenalService
    {
        static readonly HttpClient Client = new() { BaseAddress = new Uri("https://localhost:7297/api/arenal/")};

        [Benchmark]
        public async Task<IList<ViewArenal>> FindAllarenal()
        {
            Client.DefaultRequestHeaders.Authorization = new BasicAuthenticationHeaderValue("Peach", "T/R4J6eyvNG<6ne!");

            HttpResponseMessage @response = await Client.GetAsync("findallarenal");
            @response.EnsureSuccessStatusCode();
            string @responseBody = await @response.Content.ReadAsStringAsync();
            var @arenales = JsonSerializer.Deserialize<List<ViewArenal>>(@responseBody);

            return @arenales;

        }

        [Benchmark]
        public async Task<IList<ViewArenal>> FindAllArenalByPoblacionId()
        {
            Client.DefaultRequestHeaders.Authorization = new BasicAuthenticationHeaderValue("Peach", "T/R4J6eyvNG<6ne!");

            HttpResponseMessage @response = await Client.GetAsync(string.Concat("findallarenalbypoblacionid/",1));
            @response.EnsureSuccessStatusCode();
            string @responseBody = await @response.Content.ReadAsStringAsync();
            var @arenales = JsonSerializer.Deserialize<List<ViewArenal>>(@responseBody);

            return @arenales;

        }

        [Benchmark]
        public async Task<IList<ViewHistorico>> FindAllHistoricoByArenalId()
        {
            Client.DefaultRequestHeaders.Authorization = new BasicAuthenticationHeaderValue("Peach", "T/R4J6eyvNG<6ne!");

            HttpResponseMessage @response = await Client.GetAsync(string.Concat("findallhistoricobyarenalid/",1));
            @response.EnsureSuccessStatusCode();
            string @responseBody = await @response.Content.ReadAsStringAsync();
            var @historicos = JsonSerializer.Deserialize<List<ViewHistorico>>(@responseBody);

            return @historicos;

        }

        [Benchmark]
        public async Task<ViewPage<ViewArenal>> FindPaginatedArenal()
        {
            Client.DefaultRequestHeaders.Authorization = new BasicAuthenticationHeaderValue("Peach", "T/R4J6eyvNG<6ne!");

            var @content = JsonContent.Create(new FilterPage { Index = 0, Size = 20 });

            HttpResponseMessage @response = await Client.PostAsync("findpaginatedarenal", @content);
            @response.EnsureSuccessStatusCode();
            string @responseBody = await @response.Content.ReadAsStringAsync();
            var @arenales = JsonSerializer.Deserialize<ViewPage<ViewArenal>>(@responseBody);

            return @arenales;
        }

    }
}
