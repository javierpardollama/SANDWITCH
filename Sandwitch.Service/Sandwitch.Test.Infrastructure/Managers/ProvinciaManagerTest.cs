using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Sandwitch.Domain.Entities;
using Sandwitch.Domain.Exceptions;
using Sandwitch.Domain.ViewModels.Additions;
using Sandwitch.Domain.ViewModels.Filters;
using Sandwitch.Domain.ViewModels.Updates;
using Sandwitch.Infrastructure.Managers;

namespace Sandwitch.Test.Infrastructure.Managers;

/// <summary>
///     Represents a <see cref="ProvinciaManagerTest" /> class. Inherits <see cref="BaseManagerTest" />
/// </summary>
[TestFixture]
public class ProvinciaManagerTest : BaseManagerTest
{
    /// <summary>
    ///     Sets Up
    /// </summary>
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        SetUpContext();

        SetUpLogger();

        SetUpData();

        ProvinciaManager = new ProvinciaManager(Context, Logger);
    }

    /// <summary>
    ///     Tears Down
    /// </summary>
    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        Context.Provincia.RemoveRange(Context.Provincia.ToList());

        Context.SaveChanges();
    }

    /// <summary>
    ///     Instance of <see cref="ILogger{ProvinciaManager}" />
    /// </summary>
    private ILogger<ProvinciaManager> Logger;


    /// <summary>
    ///     Instance of <see cref="ProvinciaManager" />
    /// </summary>
    private ProvinciaManager ProvinciaManager;


    /// <summary>
    ///     Initializes a new Instance of <see cref="ArenalManagerTest" />
    /// </summary>
    public ProvinciaManagerTest()
    {
    }

    /// <summary>
    ///     Sets Up Logger
    /// </summary>
    private void SetUpLogger()
    {
        var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder
                .AddFilter("Microsoft", LogLevel.Warning)
                .AddFilter("System", LogLevel.Warning);
        });

        Logger = loggerFactory.CreateLogger<ProvinciaManager>();
    }

    /// <summary>
    ///     Sets Up Data
    /// </summary>
    private void SetUpData()
    {
        Context.Provincia.Add(new Provincia
        {
            Name = "Provincia " + Guid.NewGuid(), ImageUri = "URL/Provincia_01_500px.png", LastModified = DateTime.Now,
            Deleted = false
        });
        Context.Provincia.Add(new Provincia
        {
            Name = "Provincia " + Guid.NewGuid(), ImageUri = "URL/Provincia_02_500px.png", LastModified = DateTime.Now,
            Deleted = false
        });
        Context.Provincia.Add(new Provincia
        {
            Name = "Provincia " + Guid.NewGuid(), ImageUri = "URL/Provincia_03_500px.png", LastModified = DateTime.Now,
            Deleted = false
        });

        Context.SaveChanges();
    }

    /// <summary>
    ///     Finds All Provincia
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindAllProvincia()
    {
        await ProvinciaManager.FindAllProvincia();

        Assert.Pass();
    }

    /// <summary>
    ///     Finds Paginated Provincia
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindPaginatedProvincia()
    {
        await ProvinciaManager.FindPaginatedProvincia(new FilterPage { Index = 1, Size = 5 });

        Assert.Pass();
    }

    /// <summary>
    ///     Finds Provincia By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindProvinciaById()
    {
        await ProvinciaManager.FindProvinciaById(Context.Provincia.FirstOrDefault().Id);

        Assert.Pass();
    }

    /// <summary>
    ///     Removes Provincia By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task RemoveProvinciaById()
    {
        await ProvinciaManager.RemoveProvinciaById(Context.Provincia.FirstOrDefault().Id);

        Assert.Pass();
    }

    /// <summary>
    ///     Updates Provincia
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task UpdateProvincia()
    {
        UpdateProvincia Provincia = new()
        {
            Id = Context.Provincia.FirstOrDefault().Id,
            ImageUri = "URL/Provincia_21_500px.png",
            Name = "Provincia 21"
        };

        await ProvinciaManager.UpdateProvincia(Provincia);

        Assert.Pass();
    }

    /// <summary>
    ///     Adds Provincia
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task AddProvincia()
    {
        AddProvincia Provincia = new()
        {
            ImageUri = "URL/Provincia_4_500px.png",
            Name = "Provincia 4"
        };

        await ProvinciaManager.AddProvincia(Provincia);

        Assert.Pass();
    }

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public void CheckName()
    {
        AddProvincia provincia = new()
        {
            ImageUri = "URL/Provincia_4_500px.png",
            Name = Context.Provincia.FirstOrDefault().Name
        };

        var exception = Assert.ThrowsAsync<ServiceException>(async () => await ProvinciaManager.CheckName(provincia));

        Assert.Pass();
    }
}