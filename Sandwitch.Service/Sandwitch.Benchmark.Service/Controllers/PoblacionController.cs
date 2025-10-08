using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using Sandwitch.Domain.ViewModels.Filters;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Benchmark.Service.Controllers;

public class PoblacionController
{
    private static readonly HttpClient Client = new()
        { BaseAddress = new Uri("https://localhost:7297/api/v1/poblacion/") };

    [Benchmark]
    public async Task<IList<ViewPoblacion>> FindAllPoblacion()
    {
        Client.DefaultRequestHeaders.Authorization = Client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.UTF8.GetBytes("Peach" + ":" + "T/R4J6eyvNG<6ne!")));

        var response = await Client.GetAsync("findallpoblacion");
        response.EnsureSuccessStatusCode();
        var poblaciones = await response.Content.ReadFromJsonAsync<List<ViewPoblacion>>();

        return poblaciones;
    }

    [Benchmark]
    public async Task<ViewPage<ViewPoblacion>> FindPaginatedPoblacion()
    {
        Client.DefaultRequestHeaders.Authorization = Client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.UTF8.GetBytes("Peach" + ":" + "T/R4J6eyvNG<6ne!")));

        var content = JsonContent.Create(new FilterPage { Index = 0, Size = 20 });

        var response = await Client.PostAsync("findpaginatedpoblacion", content);
        response.EnsureSuccessStatusCode();
        var poblaciones = await response.Content.ReadFromJsonAsync<ViewPage<ViewPoblacion>>();

        return poblaciones;
    }
}