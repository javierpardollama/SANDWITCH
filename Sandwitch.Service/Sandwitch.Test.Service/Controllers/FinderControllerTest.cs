using NUnit.Framework;
using Sandwitch.Application.ViewModels.Finders;
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
public class FinderControllerTest
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

    private static readonly HttpClient Client = new() { BaseAddress = new Uri("https://localhost:7297/api/v2/finder/") };

    /// <summary>
    ///     Initializes a new Instance of <see cref="FinderControllerTest" />
    /// </summary>
    public FinderControllerTest()
    {
        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
            Convert.ToBase64String(Encoding.UTF8.GetBytes("Peach" + ":" + "T/R4J6eyvNG<6ne!")));
    }

    [Test]
    public async Task FindAllFinder()
    {
        var response = await Client.GetAsync("all");
        response.EnsureSuccessStatusCode();
        var Finderes = await response.Content.ReadFromJsonAsync<List<ViewFinder>>();

        Assert.Pass();
    }

    [Test]
    public async Task FindAllBeachByFinderId()
    {
        var content = JsonContent.Create(new FinderBeach { Id = 1, Group = "Town" });

        var response = await Client.PostAsync("all/beach/", content);
        response.EnsureSuccessStatusCode();
        var Beaches = await response.Content.ReadFromJsonAsync<List<ViewBeach>>();

        Assert.Pass();
    }
}