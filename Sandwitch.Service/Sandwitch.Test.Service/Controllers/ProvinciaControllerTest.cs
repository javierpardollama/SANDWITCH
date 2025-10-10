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
public class ProvinciaControllerTest
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

    private static readonly HttpClient Client = new()
        { BaseAddress = new Uri("https://localhost:7297/api/v1/provincia/") };

    /// <summary>
    ///     Initializes a new Instance of <see cref="ProvinciaControllerTest" />
    /// </summary>
    public ProvinciaControllerTest()
    {
        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
            Convert.ToBase64String(Encoding.UTF8.GetBytes("Peach" + ":" + "T/R4J6eyvNG<6ne!")));
    }

    [Test]
    public async Task FindAllProvincia()
    {
        var response = await Client.GetAsync("all");
        response.EnsureSuccessStatusCode();
        var provincias = await response.Content.ReadFromJsonAsync<List<ViewProvincia>>();

        Assert.Pass();
    }

    [Test]
    public async Task FindPaginatedProvincia()
    {
        var content = JsonContent.Create(new FilterPage { Index = 0, Size = 20 });

        var response = await Client.PostAsync("page", content);
        response.EnsureSuccessStatusCode();
        var provincias = await response.Content.ReadFromJsonAsync<ViewPage<ViewProvincia>>();

        Assert.Pass();
    }
}