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

public class BanderaController
{
    private static readonly HttpClient Client = new() { BaseAddress = new Uri("https://localhost:7297/api/v1/bandera/") };

    [Benchmark]
    public async Task<IList<ViewBandera>> FindAllBandera()
    {
        Client.DefaultRequestHeaders.Authorization = Client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.UTF8.GetBytes("Peach" + ":" + "T/R4J6eyvNG<6ne!")));

        var response = await Client.GetAsync("findallbandera");
        response.EnsureSuccessStatusCode();
        var banderas = await response.Content.ReadFromJsonAsync<List<ViewBandera>>();

        return banderas;
    }

    [Benchmark]
    public async Task<ViewPage<ViewBandera>> FindPaginatedBandera()
    {
        Client.DefaultRequestHeaders.Authorization = Client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.UTF8.GetBytes("Peach" + ":" + "T/R4J6eyvNG<6ne!")));

        var content = JsonContent.Create(new FilterPage { Index = 0, Size = 20 });

        var response = await Client.PostAsync("findpaginatedbandera", content);
        response.EnsureSuccessStatusCode();
        var banderas = await response.Content.ReadFromJsonAsync<ViewPage<ViewBandera>>();

        return banderas;
    }
}