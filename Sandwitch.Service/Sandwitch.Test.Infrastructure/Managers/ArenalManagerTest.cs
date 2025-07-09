using System;
using System.Collections.Generic;
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
///     Represents a <see cref="ArenalManagerTest" /> class. Inherits <see cref="BaseManagerTest" />
/// </summary>
[TestFixture]
public class ArenalManagerTest : BaseManagerTest
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

        ArenalManager = new ArenalManager(Context, Logger);
    }

    /// <summary>
    ///     Tears Down
    /// </summary>
    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        Context.Arenal.RemoveRange(Context.Arenal.ToList());

        Context.Bandera.RemoveRange(Context.Bandera.ToList());

        Context.Poblacion.RemoveRange(Context.Poblacion.ToList());

        Context.SaveChanges();
    }

    /// <summary>
    ///     Instance of <see cref="ILogger{ArenalManager}" />
    /// </summary>
    private ILogger<ArenalManager> Logger;

    /// <summary>
    ///     Instance of <see cref="ArenalManager" />
    /// </summary>
    private ArenalManager ArenalManager;

    /// <summary>
    ///     Initializes a new Instance of <see cref="ArenalManagerTest" />
    /// </summary>
    public ArenalManagerTest()
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

        Logger = loggerFactory.CreateLogger<ArenalManager>();
    }

    /// <summary>
    ///     Sets Up Data
    /// </summary>
    private void SetUpData()
    {
        Context.Poblacion.Add(new Poblacion
        {
            Name = "Poblacion " + Guid.NewGuid(), ImageUri = "Poblaciones/Poblacion_1_500.png",
            LastModified = DateTime.Now, Deleted = false
        });
        Context.Poblacion.Add(new Poblacion
        {
            Name = "Poblacion " + Guid.NewGuid(), ImageUri = "Poblaciones/Poblacion_2_500.png",
            LastModified = DateTime.Now, Deleted = false
        });

        Context.Bandera.Add(new Bandera
        {
            Name = "Bandera " + Guid.NewGuid(), ImageUri = "Banderas/Bandera_1_500.png", LastModified = DateTime.Now,
            Deleted = false
        });

        Context.Viento.Add(new Viento
        {
            Name = "Viento " + Guid.NewGuid(), ImageUri = "Vientos/Viento.png", LastModified = DateTime.Now,
            Deleted = false
        });

        Context.Arenal.Add(new Arenal
            { Name = "Arenal " + Guid.NewGuid(), LastModified = DateTime.Now, Deleted = false });
        Context.Arenal.Add(new Arenal
            { Name = "Arenal " + Guid.NewGuid(), LastModified = DateTime.Now, Deleted = false });
        Context.Arenal.Add(new Arenal
            { Name = "Arenal " + Guid.NewGuid(), LastModified = DateTime.Now, Deleted = false });

        Context.SaveChanges();
    }

    /// <summary>
    ///     Finds All Arenal
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindAllArenal()
    {
        await ArenalManager.FindAllArenal();

        Assert.Pass();
    }

    /// <summary>
    ///     Finds Paginated Arenal
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindPaginatedArenal()
    {
        await ArenalManager.FindPaginatedArenal(new FilterPage { Index = 1, Size = 5 });

        Assert.Pass();
    }

    /// <summary>
    ///     Finds All Historico By Arenal Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindAllHistoricoByArenalId()
    {
        await ArenalManager.FindAllHistoricoByArenalId(Context.Arenal.FirstOrDefault().Id);

        Assert.Pass();
    }

    /// <summary>
    ///     Finds Arenal By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindArenalById()
    {
        await ArenalManager.FindArenalById(Context.Arenal.FirstOrDefault().Id);

        Assert.Pass();
    }

    /// <summary>
    ///     Finds Poblacion By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindPoblacionById()
    {
        await ArenalManager.FindPoblacionById(Context.Poblacion.FirstOrDefault().Id);

        Assert.Pass();
    }

    /// <summary>
    ///     Finds Bandera By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindBanderaById()
    {
        await ArenalManager.FindBanderaById(Context.Bandera.FirstOrDefault().Id);

        Assert.Pass();
    }

    /// <summary>
    ///     Removes Arenal By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task RemoveArenalById()
    {
        await ArenalManager.RemoveArenalById(Context.Arenal.FirstOrDefault().Id);

        Assert.Pass();
    }

    /// <summary>
    ///     Updates Arenal
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task UpdateArenal()
    {
        UpdateArenal Provincia = new()
        {
            Id = Context.Arenal.FirstOrDefault().Id,
            Name = "Arenal 21",
            PoblacionesId = new List<int> { Context.Poblacion.FirstOrDefault().Id }
        };

        await ArenalManager.UpdateArenal(Provincia);

        Assert.Pass();
    }

    /// <summary>
    ///     Adds Arenal
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task AddArenal()
    {
        AddArenal Provincia = new()
        {
            Name = "Arenal 4",
            PoblacionesId = new List<int> { 1, 2 }
        };

        await ArenalManager.AddArenal(Provincia);

        Assert.Pass();
    }

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public void CheckName()
    {
        AddArenal Provincia = new()
        {
            PoblacionesId = new List<int> { 1, 2 },
            Name = Context.Arenal.FirstOrDefault().Name
        };

        var exception = Assert.ThrowsAsync<ServiceException>(async () => await ArenalManager.CheckName(Provincia));

        Assert.Pass();
    }
}