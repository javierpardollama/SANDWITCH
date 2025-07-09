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
///     Represents a <see cref="PoblacionManagerTest" /> class. Inherits <see cref="BaseManagerTest" />
/// </summary>
[TestFixture]
public class PoblacionManagerTest : BaseManagerTest
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

        PoblacionManager = new PoblacionManager(Context, Logger);
    }

    /// <summary>
    ///     Tears Down
    /// </summary>
    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        Context.Poblacion.RemoveRange(Context.Poblacion.ToList());

        Context.Provincia.RemoveRange(Context.Provincia.ToList());

        Context.SaveChanges();
    }

    /// <summary>
    ///     Instance of <see cref="ILogger{PoblacionManager}" />
    /// </summary>
    private ILogger<PoblacionManager> Logger;

    /// <summary>
    ///     Instance of <see cref="PoblacionManager" />
    /// </summary>
    private PoblacionManager PoblacionManager;


    /// <summary>
    ///     Initializes a new Instance of <see cref="ArenalManagerTest" />
    /// </summary>
    public PoblacionManagerTest()
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

        Logger = loggerFactory.CreateLogger<PoblacionManager>();
    }

    /// <summary>
    ///     Sets Up Data
    /// </summary>
    private void SetUpData()
    {
        Context.Provincia.Add(new Provincia
        {
            Name = "Provincia " + Guid.NewGuid(), ImageUri = "URL/Provincia_04_500px.png", LastModified = DateTime.Now,
            Deleted = false
        });

        Context.Poblacion.Add(new Poblacion
        {
            Name = "Poblacion " + Guid.NewGuid(), ImageUri = "URL/Poblacion_01_500px.png", LastModified = DateTime.Now,
            Deleted = false
        });
        Context.Poblacion.Add(new Poblacion
        {
            Name = "Poblacion " + Guid.NewGuid(), ImageUri = "URL/Poblacion_02_500px.png", LastModified = DateTime.Now,
            Deleted = false
        });
        Context.Poblacion.Add(new Poblacion
        {
            Name = "Poblacion " + Guid.NewGuid(), ImageUri = "URL/Poblacion_03_500px.png", LastModified = DateTime.Now,
            Deleted = false
        });

        Context.SaveChanges();
    }

    /// <summary>
    ///     Finds All Poblacion
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindAllPoblacion()
    {
        await PoblacionManager.FindAllPoblacion();

        Assert.Pass();
    }

    /// <summary>
    ///     Finds Paginated Poblacion
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindPaginatedPoblacion()
    {
        await PoblacionManager.FindPaginatedPoblacion(new FilterPage { Index = 1, Size = 5 });

        Assert.Pass();
    }

    /// <summary>
    ///     Finds Poblacion By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindPoblacionById()
    {
        await PoblacionManager.FindPoblacionById(Context.Poblacion.FirstOrDefault().Id);

        Assert.Pass();
    }

    /// <summary>
    ///     Finds Provincia By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindProvinciaById()
    {
        await PoblacionManager.FindProvinciaById(Context.Provincia.FirstOrDefault().Id);

        Assert.Pass();
    }

    /// <summary>
    ///     Removes Poblacion By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task RemovePoblacionById()
    {
        await PoblacionManager.RemovePoblacionById(Context.Poblacion.FirstOrDefault().Id);

        Assert.Pass();
    }

    /// <summary>
    ///     Updates Poblacion
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task UpdatePoblacion()
    {
        UpdatePoblacion Poblacion = new()
        {
            Id = Context.Poblacion.FirstOrDefault().Id,
            ImageUri = "URL/Poblacion_21_500px.png",
            Name = "Poblacion 21",
            ProvinciaId = Context.Provincia.FirstOrDefault().Id
        };

        await PoblacionManager.UpdatePoblacion(Poblacion);

        Assert.Pass();
    }

    /// <summary>
    ///     Adds Poblacion
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task AddPoblacion()
    {
        AddPoblacion Poblacion = new()
        {
            ImageUri = "URL/Poblacion_4_500px.png",
            Name = "Poblacion 4",
            ProvinciaId = Context.Provincia.FirstOrDefault().Id
        };

        await PoblacionManager.AddPoblacion(Poblacion);

        Assert.Pass();
    }

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public void CheckName()
    {
        AddPoblacion Poblacion = new()
        {
            ImageUri = "URL/Poblacion_3_500px.png",
            Name = Context.Poblacion.FirstOrDefault().Name,
            ProvinciaId = Context.Provincia.FirstOrDefault().Id
        };

        var exception = Assert.ThrowsAsync<ServiceException>(async () => await PoblacionManager.CheckName(Poblacion));

        Assert.Pass();
    }
}