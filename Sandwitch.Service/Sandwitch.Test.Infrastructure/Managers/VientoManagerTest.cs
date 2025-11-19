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
///     Represents a <see cref="VientoManagerTest" /> class. Inherits <see cref="BaseManagerTest" />
/// </summary>
[TestFixture]
public class VientoManagerTest : BaseManagerTest
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

        VientoManager = new VientoManager(Context, Logger);
    }

    /// <summary>
    ///     Instance of <see cref="ILogger{VientoManager}" />
    /// </summary>
    private ILogger<VientoManager> Logger;

    /// <summary>
    ///     Instance of <see cref="VientoManager" />
    /// </summary>
    private VientoManager VientoManager;

    /// <summary>
    ///     Initializes a new Instance of <see cref="VientoManagerTest" />
    /// </summary>
    public VientoManagerTest()
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

        Logger = loggerFactory.CreateLogger<VientoManager>();
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
            Context.Viento.Add(new Viento
            {
                Id = 2,
                Name = "Noroeste",
                ImageUri = "URL/Noroeste_500.png",
                LastModified = DateTime.Now,
                Deleted = false
            });
            Context.Viento.Add(new Viento
            {
                Id = 3,
                Name = "Oeste",
                ImageUri = "URL/Oeste_500.png",
                LastModified = DateTime.Now,
                Deleted = false
            });
        }
        Context.SaveChanges();
    }

    /// <summary>
    ///     Finds All Viento
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindAllViento()
    {
        await VientoManager.FindAllViento();

        Assert.Pass();
    }

    /// <summary>
    ///     Finds Paginated Viento
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindPaginatedViento()
    {
        await VientoManager.FindPaginatedViento(1, 5);

        Assert.Pass();
    }

    /// <summary>
    ///     Finds All Historico By Viento Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindAllHistoricoByVientoId()
    {
        await VientoManager.FindAllHistoricoByVientoId(1);

        Assert.Pass();
    }

    /// <summary>
    ///     Finds Viento By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindVientoById()
    {
        await VientoManager.FindVientoById(1);

        Assert.Pass();
    }

    /// <summary>
    ///     Removes Viento By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task RemoveVientoById()
    {
        await VientoManager.RemoveVientoById(1);

        Assert.Pass();
    }

    /// <summary>
    ///     Updates Viento
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task UpdateViento()
    {
        Viento entity = new()
        {
            Id = 2,
            ImageUri = "URL/North_West_500px.png",
            Name = "North West"
        };

        await VientoManager.UpdateViento(entity);

        Assert.Pass();
    }

    /// <summary>
    ///     Adds Viento
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task AddViento()
    {
        Viento entity = new()
        {
            ImageUri = "URL/Sudoeste_500px.png",
            Name = "Sudoeste"
        };

        await VientoManager.AddViento(entity);

        Assert.Pass();
    }

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public void CheckNameAsync()
    {
        Bandera @entity = new()
        {
            Id = 3,
            ImageUri = "URL/Oeste_500px.png",
            Name = "Oeste"
        };
        var exception = Assert.ThrowsAsync<ServiceException>(async () => await VientoManager.CheckName(@entity.Name));

        Assert.Pass();
    }

    /// <summary>
    ///     Reloads Bandera By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task ReloadBanderaById()
    {
        await VientoManager.ReloadVientoById(2);

        Assert.Pass();
    }
}