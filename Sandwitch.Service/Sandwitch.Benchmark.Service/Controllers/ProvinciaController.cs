using BenchmarkDotNet.Attributes;
using Sandwitch.Application.ViewModels.Filters;
using Sandwitch.Application.ViewModels.Views;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Sandwitch.Benchmark.Service.Controllers;

public class ProvinciaController
{
    private static readonly HttpClient Client = new()
        { BaseAddress = new Uri("https://localhost:7297/api/v1/provincia/") };

    [Benchmark]
    public async Task<IList<ViewCatalog>> FindAllProvincia()
    {
        Client.DefaultRequestHeaders.Authorization = Client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.UTF8.GetBytes("Peach" + ":" + "T/R4J6eyvNG<6ne!")));

        var response = await Client.GetAsync("all");
        response.EnsureSuccessStatusCode();
        var provincias = await response.Content.ReadFromJsonAsync<List<ViewCatalog>>();

        return provincias;
    }

    [Benchmark]
    public async Task<ViewPage<ViewProvincia>> FindPaginatedProvincia()
    {
        Client.DefaultRequestHeaders.Authorization = Client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.UTF8.GetBytes("Peach" + ":" + "T/R4J6eyvNG<6ne!")));

        var content = JsonContent.Create(new FilterPage { Index = 0, Size = 20 });

        var response = await Client.PostAsync("page", content);
        response.EnsureSuccessStatusCode();
        var provincias = await response.Content.ReadFromJsonAsync<ViewPage<ViewProvincia>>();

        return provincias;
    }
}