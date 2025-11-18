using BenchmarkDotNet.Attributes;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.ViewModels.Filters;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Sandwitch.Benchmark.Service.Controllers;

public class VientoController
{
    private static readonly HttpClient Client = new() { BaseAddress = new Uri("https://localhost:7297/api/v2/viento/") };

    [Benchmark]
    public async Task<IList<ViewCatalog>> FindAllViento()
    {
        Client.DefaultRequestHeaders.Authorization = Client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.UTF8.GetBytes("Peach" + ":" + "T/R4J6eyvNG<6ne!")));

        var response = await Client.GetAsync("all");
        response.EnsureSuccessStatusCode();
        var vientos = await response.Content.ReadFromJsonAsync<List<ViewCatalog>>();

        return vientos;
    }

    [Benchmark]
    public async Task<ViewPage<ViewViento>> FindPaginatedViento()
    {
        Client.DefaultRequestHeaders.Authorization = Client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.UTF8.GetBytes("Peach" + ":" + "T/R4J6eyvNG<6ne!")));

        var content = JsonContent.Create(new FilterPage { Index = 0, Size = 20 });

        var response = await Client.PostAsync("page", content);
        response.EnsureSuccessStatusCode();
        var vientos = await response.Content.ReadFromJsonAsync<ViewPage<ViewViento>>();

        return vientos;
    }
}