using BenchmarkDotNet.Attributes;

using Sandwitch.Tier.ViewModels.Classes.Filters;
using Sandwitch.Tier.ViewModels.Classes.Views;

using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace Sandwitch.Tier.Benchmarks.Services
{
    public class ArenalService
    {
        static readonly NetworkCredential Credentials = new("Peach", "T/R4J6eyvNG<6ne!");
        static readonly HttpClientHandler Handler = new () { Credentials = Credentials };
        static readonly HttpClient Client = new(Handler) { BaseAddress = new Uri("https://localhost:7214/api/arenal/")};

        [Benchmark]
        public async Task<IList<ViewArenal>> FindAllarenal()
        {
            HttpResponseMessage @response = await Client.GetAsync("findallarenal");
            @response.EnsureSuccessStatusCode();
            string @responseBody = await @response.Content.ReadAsStringAsync();
            var @arenales = JsonSerializer.Deserialize<List<ViewArenal>>(@responseBody);

            return @arenales;

        }

        [Benchmark]
        public async Task<IList<ViewArenal>> FindAllArenalByPoblacionId()
        {
            HttpResponseMessage @response = await Client.GetAsync(string.Concat("findallarenalbypoblacionid/",1));
            @response.EnsureSuccessStatusCode();
            string @responseBody = await @response.Content.ReadAsStringAsync();
            var @arenales = JsonSerializer.Deserialize<List<ViewArenal>>(@responseBody);

            return @arenales;

        }

        [Benchmark]
        public async Task<IList<ViewHistorico>> FindAllHistoricoByArenalId()
        {
            HttpResponseMessage @response = await Client.GetAsync(string.Concat("findallhistoricobyarenalid/",1));
            @response.EnsureSuccessStatusCode();
            string @responseBody = await @response.Content.ReadAsStringAsync();
            var @historicos = JsonSerializer.Deserialize<List<ViewHistorico>>(@responseBody);

            return @historicos;

        }

        [Benchmark]
        public async Task<ViewPage<ViewArenal>> FindPaginatedArenal()
        {
            var @content = JsonContent.Create(new FilterPage { Index = 0, Size = 20 });

            HttpResponseMessage @response = await Client.PostAsync("findpaginatedarenal", @content);
            @response.EnsureSuccessStatusCode();
            string @responseBody = await @response.Content.ReadAsStringAsync();
            var @arenales = JsonSerializer.Deserialize<ViewPage<ViewArenal>>(@responseBody);

            return @arenales;
        }

    }
}
