using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Sandwitch.Domain.ViewModels.Finders;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Test.Service.Controllers;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class BuscadorControllerTest
{
    /// <summary>
    ///     Sets Up
    /// </summary>
    [SetUp]
    public void Setup()
    {
    }

    /// <summary>
    ///     Tears Down
    /// </summary>
    [TearDown]
    public void TearDown()
    {
    }

    private static readonly HttpClient Client = new() { BaseAddress = new Uri("https://localhost:7297/api/v2/buscador/") };

    /// <summary>
    ///     Initializes a new Instance of <see cref="BuscadorControllerTest" />
    /// </summary>
    public BuscadorControllerTest()
    {
        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
            Convert.ToBase64String(Encoding.UTF8.GetBytes("Peach" + ":" + "T/R4J6eyvNG<6ne!")));
    }

    [Test]
    public async Task FindAllBuscador()
    {
        var response = await Client.GetAsync("all");
        response.EnsureSuccessStatusCode();
        var buscadores = await response.Content.ReadFromJsonAsync<List<ViewBuscador>>();

        Assert.Pass();
    }

    [Test]
    public async Task FindAllArenalByBuscadorId()
    {
        var content = JsonContent.Create(new FinderArenal { Id = 1, Type = "Poblacion" });

        var response = await Client.PostAsync("all/arenal/", content);
        response.EnsureSuccessStatusCode();
        var arenales = await response.Content.ReadFromJsonAsync<List<ViewArenal>>();

        Assert.Pass();
    }
}