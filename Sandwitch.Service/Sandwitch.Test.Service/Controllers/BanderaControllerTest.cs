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
public class BanderaControllerTest
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

    private static readonly HttpClient Client = new() { BaseAddress = new Uri("https://localhost:7297/api/bandera/") };

    /// <summary>
    ///     Initializes a new Instance of <see cref="BanderaControllerTest" />
    /// </summary>
    public BanderaControllerTest()
    {
        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
            Convert.ToBase64String(Encoding.UTF8.GetBytes("Peach" + ":" + "T/R4J6eyvNG<6ne!")));
    }

    [Test]
    public async Task FindAllBandera()
    {
        var response = await Client.GetAsync("findallbandera");
        response.EnsureSuccessStatusCode();
        var banderas = await response.Content.ReadFromJsonAsync<List<ViewBandera>>();

        Assert.Pass();
    }

    [Test]
    public async Task FindPaginatedBandera()
    {
        var content = JsonContent.Create(new FilterPage { Index = 0, Size = 20 });

        var response = await Client.PostAsync("findpaginatedbandera", content);
        response.EnsureSuccessStatusCode();
        var banderas = await response.Content.ReadFromJsonAsync<ViewPage<ViewBandera>>();

        Assert.Pass();
    }
}