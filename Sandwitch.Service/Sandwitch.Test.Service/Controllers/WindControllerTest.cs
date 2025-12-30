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
public class WindControllerTest
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

    private static readonly HttpClient Client = new() { BaseAddress = new Uri("https://localhost:7297/api/v2/wind/") };

    /// <summary>
    ///     Initializes a new Instance of <see cref="WindControllerTest" />
    /// </summary>
    public WindControllerTest()
    {
        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
            Convert.ToBase64String(Encoding.UTF8.GetBytes("Peach" + ":" + "T/R4J6eyvNG<6ne!")));
    }

    [Test]
    public async Task FindAllWind()
    {
        var response = await Client.GetAsync("all");
        response.EnsureSuccessStatusCode();
        var Winds = await response.Content.ReadFromJsonAsync<List<ViewCatalog>>();

        Assert.Pass();
    }

    [Test]
    public async Task FindPaginatedWind()
    {
        var content = JsonContent.Create(new FilterPage { Index = 0, Size = 20 });

        var response = await Client.PostAsync("page", content);
        response.EnsureSuccessStatusCode();
        var Winds = await response.Content.ReadFromJsonAsync<ViewPage<ViewWind>>();

        Assert.Pass();
    }
}