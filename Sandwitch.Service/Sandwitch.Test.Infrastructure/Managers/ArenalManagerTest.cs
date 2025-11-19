using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Sandwitch.Domain.Entities;
using Sandwitch.Domain.Exceptions;
using Sandwitch.Infrastructure.Managers;
using System;
using System.Linq;
using System.Threading.Tasks;

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

        Seed();

        ArenalManager = new ArenalManager(Context, Logger);
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
    ///     Seeds
    /// </summary>
    private void Seed()
    {
        if (!Context.Viento.Any())
        {
            Context.Viento.Add(new Viento
            {
                Id = 1,
                Name = "Norte",
                ImageUri = "URL/Norte_500.png",
                LastModified = DateTime.Now,
                Deleted = false
            });
        }

        if (!Context.Bandera.Any())
        {
            Context.Bandera.Add(new Bandera
            {
                Id = 1,
                Name = "Amarilla ",
                ImageUri = "URL/Amarilla_500.png",
                LastModified = DateTime.Now,
                Deleted = false
            });
        }

        if (!Context.Provincia.Any())
        {
            Context.Provincia.Add(new Provincia
            {
                Id = 1,
                Name = "Bizkaia",
                ImageUri = "URL/Bizkaia_500px.png",
                LastModified = DateTime.Now,
                Deleted = false
            });
        }

        if (!Context.Poblacion.Any())
        {
            Context.Poblacion.Add(new Poblacion
            {
                Id = 1,
                Name = "Getxo",
                ImageUri = "URL/Getxo_500px.png",
                LastModified = DateTime.Now,
                Deleted = false
            });

            Context.Poblacion.Add(new Poblacion
            {
                Id = 2,
                Name = "Muskiz",
                ImageUri = "URL/Muskiz_500px.png",
                LastModified = DateTime.Now,
                Deleted = false
            });
        }

        if (!Context.Arenal.Any())
        {
            Context.Arenal.Add(new Arenal
            {
                Id = 1,
                Name = "Las Arenas",
                LastModified = DateTime.Now,
                Deleted = false,
                ArenalPoblaciones = [
                new()
                {
                    ArenalId = 1,
                    PoblacionId = 1,
                }
                ]
            });


            Context.Arenal.Add(new Arenal
            {
                Id = 2,
                Name = "La Arena",
                LastModified = DateTime.Now,
                Deleted = false,
                ArenalPoblaciones = [
                  new()
                {
                    ArenalId = 2,
                    PoblacionId = 2,
                }
                  ]
            });
        }
        if (!Context.Historico.Any())
        {
            Context.Historico.Add(new Historico()
            {
                Id = 1,
                LastModified = DateTime.Now,
                Deleted = false,
                BajaMarAlba = DateTime.Now.TimeOfDay,
                BajaMarOcaso = DateTime.Now.TimeOfDay,
                AltaMarAlba = DateTime.Now.TimeOfDay,
                AltaMarOcaso = DateTime.Now.TimeOfDay,
                Temperatura = 20,
                Velocidad = 0,
                ArenalId = 1,
                VientoId = 1,
                BanderaId = 1,
            });
        }
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
        await ArenalManager.FindPaginatedArenal(1, 5);

        Assert.Pass();
    }

    /// <summary>
    ///     Finds All Historico By Arenal Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindAllHistoricoByArenalId()
    {
        await ArenalManager.FindAllHistoricoByArenalId(1);

        Assert.Pass();
    }

    /// <summary>
    ///     Finds Arenal By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindArenalById()
    {
        await ArenalManager.FindArenalById(1);

        Assert.Pass();
    }

    /// <summary>
    ///     Finds Poblacion By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindPoblacionById()
    {
        await ArenalManager.FindPoblacionById(1);

        Assert.Pass();
    }

    /// <summary>
    ///     Finds Bandera By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindBanderaById()
    {
        await ArenalManager.FindBanderaById(1);

        Assert.Pass();
    }

    /// <summary>
    ///     Removes Arenal By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task RemoveArenalById()
    {
        await ArenalManager.RemoveArenalById(1);

        Assert.Pass();
    }

    /// <summary>
    ///     Updates Arenal
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task UpdateArenal()
    {
        Arenal @entity = new()
        {
            Id = 2,
            Name = "Las Arenas",
        };

        await ArenalManager.UpdateArenal(@entity);

        Assert.Pass();
    }

    /// <summary>
    ///     Adds Arenal
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task AddArenal()
    {
        Arenal @entity = new()
        {
            Name = "Ereaga"
        };

        await ArenalManager.AddArenal(entity);

        Assert.Pass();
    }

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public void CheckName()
    {
        Arenal @entity = new()
        {
            Id = 2,
            Name = "La Arena",
        };

        var exception = Assert.ThrowsAsync<ServiceException>(async () => await ArenalManager.CheckName(@entity.Name));

        Assert.Pass();
    }

    /// <summary>
    ///     Reloads Arenal By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task ReloadArenalById()
    {
        await ArenalManager.ReloadArenalById(2);

        Assert.Pass();
    }
}