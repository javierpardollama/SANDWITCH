using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Sandwitch.Domain.ViewModels.Filters;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Test.Service.Controllers;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class ArenalControllerTest
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

    private static readonly HttpClient Client = new() { BaseAddress = new Uri("https://localhost:7297/api/v1/arenal/") };

    /// <summary>
    ///     Initializes a new Instance of <see cref="ArenalControllerTest" />
    /// </summary>
    public ArenalControllerTest()
    {
        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
            Convert.ToBase64String(Encoding.UTF8.GetBytes("Peach" + ":" + "T/R4J6eyvNG<6ne!")));
    }

    [Test]
    public async Task FindAllarenal()
    {
        var response = await Client.GetAsync("findallarenal");
        response.EnsureSuccessStatusCode();
        var arenales = await response.Content.ReadFromJsonAsync<List<ViewArenal>>();

        Assert.Pass();
    }

    [Test]
    public async Task FindAllHistoricoByArenalId()
    {
        var response = await Client.GetAsync(string.Concat("findallhistoricobyarenalid/", 1));
        response.EnsureSuccessStatusCode();
        var historicos = await response.Content.ReadFromJsonAsync<List<ViewHistorico>>();

        Assert.Pass();
    }

    [Test]
    public async Task FindPaginatedArenal()
    {
        var content = JsonContent.Create(new FilterPage { Index = 0, Size = 20 });

        var response = await Client.PostAsync("findpaginatedarenal", content);
        response.EnsureSuccessStatusCode();
        var arenales = await response.Content.ReadFromJsonAsync<ViewPage<ViewArenal>>();

        Assert.Pass();
    }
}