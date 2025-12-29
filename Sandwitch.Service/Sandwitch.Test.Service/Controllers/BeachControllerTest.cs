using NUnit.Framework;
using Sandwitch.Application.ViewModels.Filters;
using Sandwitch.Application.ViewModels.Views;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Sandwitch.Test.Service.Controllers;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class BeachControllerTest
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

    private static readonly HttpClient Client = new() { BaseAddress = new Uri("https://localhost:7297/api/v1/beach/") };

    /// <summary>
    ///     Initializes a new Instance of <see cref="BeachControllerTest" />
    /// </summary>
    public BeachControllerTest()
    {
        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
            Convert.ToBase64String(Encoding.UTF8.GetBytes("Peach" + ":" + "T/R4J6eyvNG<6ne!")));
    }

    [Test]
    public async Task FindAllBeach()
    {
        var response = await Client.GetAsync("all");
        response.EnsureSuccessStatusCode();
        var Beaches = await response.Content.ReadFromJsonAsync<List<ViewCatalog>>();

        Assert.Pass();
    }

    [Test]
    public async Task FindAllHistoricByBeachId()
    {
        var response = await Client.GetAsync(string.Concat("all/Historic/", 1));
        response.EnsureSuccessStatusCode();
        var Historics = await response.Content.ReadFromJsonAsync<List<ViewHistoric>>();

        Assert.Pass();
    }

    [Test]
    public async Task FindPaginatedBeach()
    {
        var content = JsonContent.Create(new FilterPage { Index = 0, Size = 20 });

        var response = await Client.PostAsync("page", content);
        response.EnsureSuccessStatusCode();
        var Beaches = await response.Content.ReadFromJsonAsync<ViewPage<ViewBeach>>();

        Assert.Pass();
    }
}