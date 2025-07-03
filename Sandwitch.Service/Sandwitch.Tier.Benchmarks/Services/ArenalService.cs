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
    public class ArenalService
    {
        static readonly HttpClient Client = new() { BaseAddress = new Uri("https://localhost:7297/api/arenal/") };

        [Benchmark]
        public async Task<IList<ViewArenal>> FindAllarenal()
        {
            Client.DefaultRequestHeaders.Authorization = Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes("Peach" + ":" + "T/R4J6eyvNG<6ne!")));

            HttpResponseMessage @response = await Client.GetAsync("findallarenal");
            @response.EnsureSuccessStatusCode();
            var @arenales = await @response.Content.ReadFromJsonAsync<List<ViewArenal>>();

            return @arenales;

        }

        [Benchmark]
        public async Task<IList<ViewHistorico>> FindAllHistoricoByArenalId()
        {
            Client.DefaultRequestHeaders.Authorization = Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes("Peach" + ":" + "T/R4J6eyvNG<6ne!")));

            HttpResponseMessage @response = await Client.GetAsync(string.Concat("findallhistoricobyarenalid/", 1));
            @response.EnsureSuccessStatusCode();
            var @historicos = await @response.Content.ReadFromJsonAsync<List<ViewHistorico>>();

            return @historicos;

        }

        [Benchmark]
        public async Task<ViewPage<ViewArenal>> FindPaginatedArenal()
        {
            Client.DefaultRequestHeaders.Authorization = Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes("Peach" + ":" + "T/R4J6eyvNG<6ne!")));

            var @content = JsonContent.Create(new FilterPage { Index = 0, Size = 20 });

            HttpResponseMessage @response = await Client.PostAsync("findpaginatedarenal", @content);
            @response.EnsureSuccessStatusCode();
            var @arenales = await @response.Content.ReadFromJsonAsync<ViewPage<ViewArenal>>();

            return @arenales;
        }

    }
}
