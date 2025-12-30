using BenchmarkDotNet.Attributes;
using Sandwitch.Application.ViewModels.Finders;
using Sandwitch.Application.ViewModels.Views;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Sandwitch.Benchmark.Service.Controllers;

public class FinderController
{
    private static readonly HttpClient Client = new() { BaseAddress = new Uri("https://localhost:7297/api/v2/finder/") };

    [Benchmark]
    public async Task<IList<ViewFinder>> FindAllFinder()
    {
        Client.DefaultRequestHeaders.Authorization = Client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.UTF8.GetBytes("Peach" + ":" + "T/R4J6eyvNG<6ne!")));

        var response = await Client.GetAsync("all");
        response.EnsureSuccessStatusCode();
        var Finderes = await response.Content.ReadFromJsonAsync<List<ViewFinder>>();
        return Finderes;
    }

    [Benchmark]
    public async Task<List<ViewBeach>> FindAllBeachByFinderId()
    {
        Client.DefaultRequestHeaders.Authorization = Client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.UTF8.GetBytes("Peach" + ":" + "T/R4J6eyvNG<6ne!")));

        var content = JsonContent.Create(new FinderBeach { Id = 1, Group = "Town" });


        var response = await Client.PostAsync("all/Beach", content);
        response.EnsureSuccessStatusCode();
        var Beaches = await response.Content.ReadFromJsonAsync<List<ViewBeach>>();

        return Beaches;
    }
}