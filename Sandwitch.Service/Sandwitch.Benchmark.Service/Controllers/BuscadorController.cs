using BenchmarkDotNet.Attributes;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.ViewModels.Finders;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Sandwitch.Benchmark.Service.Controllers;

public class BuscadorController
{
    private static readonly HttpClient Client = new() { BaseAddress = new Uri("https://localhost:7297/api/v2/buscador/") };

    [Benchmark]
    public async Task<IList<ViewBuscador>> FindAllBuscador()
    {
        Client.DefaultRequestHeaders.Authorization = Client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.UTF8.GetBytes("Peach" + ":" + "T/R4J6eyvNG<6ne!")));

        var response = await Client.GetAsync("all");
        response.EnsureSuccessStatusCode();
        var buscadores = await response.Content.ReadFromJsonAsync<List<ViewBuscador>>();
        return buscadores;
    }

    [Benchmark]
    public async Task<List<ViewArenal>> FindAllArenalByBuscadorId()
    {
        Client.DefaultRequestHeaders.Authorization = Client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.UTF8.GetBytes("Peach" + ":" + "T/R4J6eyvNG<6ne!")));

        var content = JsonContent.Create(new FinderArenal { Id = 1, Type = "Poblacion" });


        var response = await Client.PostAsync("all/arenal", content);
        response.EnsureSuccessStatusCode();
        var arenales = await response.Content.ReadFromJsonAsync<List<ViewArenal>>();

        return arenales;
    }
}