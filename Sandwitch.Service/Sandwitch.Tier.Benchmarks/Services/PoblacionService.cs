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
    public class PoblacionService
    {
        static readonly HttpClient Client = new() { BaseAddress = new Uri("https://localhost:7297/api/poblacion/") };

        [Benchmark]
        public async Task<IList<ViewPoblacion>> FindAllPoblacion()
        {
            Client.DefaultRequestHeaders.Authorization = Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes("Peach" + ":" + "T/R4J6eyvNG<6ne!"))); ;

            HttpResponseMessage @response = await Client.GetAsync("findallpoblacion");
            @response.EnsureSuccessStatusCode();
            var @poblaciones = await @response.Content.ReadFromJsonAsync<List<ViewPoblacion>>();

            return @poblaciones;

        }

        [Benchmark]
        public async Task<IList<ViewPoblacion>> FindAllPoblacionByProvinciaId()
        {
            Client.DefaultRequestHeaders.Authorization = Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes("Peach" + ":" + "T/R4J6eyvNG<6ne!"))); ;

            HttpResponseMessage @response = await Client.GetAsync(string.Concat("findallpoblacionbyprovinciaid/", 1));
            @response.EnsureSuccessStatusCode();
            var @poblaciones = await @response.Content.ReadFromJsonAsync<List<ViewPoblacion>>();

            return @poblaciones;

        }

        [Benchmark]
        public async Task<ViewPage<ViewPoblacion>> FindPaginatedPoblacion()
        {
            Client.DefaultRequestHeaders.Authorization = Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes("Peach" + ":" + "T/R4J6eyvNG<6ne!"))); ;

            var @content = JsonContent.Create(new FilterPage { Index = 0, Size = 20 });

            HttpResponseMessage @response = await Client.PostAsync("findpaginatedpoblacion", @content);
            @response.EnsureSuccessStatusCode();
            var @poblaciones = await @response.Content.ReadFromJsonAsync<ViewPage<ViewPoblacion>>();

            return @poblaciones;

        }

    }
}
