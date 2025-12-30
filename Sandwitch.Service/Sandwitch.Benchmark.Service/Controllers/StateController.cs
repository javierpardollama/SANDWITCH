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

public class StateController
{
    private static readonly HttpClient Client = new()
        { BaseAddress = new Uri("https://localhost:7297/api/v1/state/") };

    [Benchmark]
    public async Task<IList<ViewCatalog>> FindAllState()
    {
        Client.DefaultRequestHeaders.Authorization = Client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.UTF8.GetBytes("Peach" + ":" + "T/R4J6eyvNG<6ne!")));

        var response = await Client.GetAsync("all");
        response.EnsureSuccessStatusCode();
        var States = await response.Content.ReadFromJsonAsync<List<ViewCatalog>>();

        return States;
    }

    [Benchmark]
    public async Task<ViewPage<ViewState>> FindPaginatedState()
    {
        Client.DefaultRequestHeaders.Authorization = Client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.UTF8.GetBytes("Peach" + ":" + "T/R4J6eyvNG<6ne!")));

        var content = JsonContent.Create(new FilterPage { Index = 0, Size = 20 });

        var response = await Client.PostAsync("page", content);
        response.EnsureSuccessStatusCode();
        var States = await response.Content.ReadFromJsonAsync<ViewPage<ViewState>>();

        return States;
    }
}