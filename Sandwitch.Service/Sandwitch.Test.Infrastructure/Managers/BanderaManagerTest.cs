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
///     Represents a <see cref="BanderaManagerTest" /> class. Inherits <see cref="BaseManagerTest" />
/// </summary>
[TestFixture]
public class BanderaManagerTest : BaseManagerTest
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

        BanderaManager = new BanderaManager(Context, Logger);
    }

    /// <summary>
    ///     Tears Down
    /// </summary>
    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        Context.Bandera.RemoveRange(Context.Bandera.ToList());

        Context.SaveChanges();
    }

    /// <summary>
    ///     Instance of <see cref="ILogger{BanderaManager}" />
    /// </summary>
    private ILogger<BanderaManager> Logger;

    /// <summary>
    ///     Instance of <see cref="BanderaManager" />
    /// </summary>
    private BanderaManager BanderaManager;

    /// <summary>
    ///     Initializes a new Instance of <see cref="BanderaManagerTest" />
    /// </summary>
    public BanderaManagerTest()
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

        Logger = loggerFactory.CreateLogger<BanderaManager>();
    }

    /// <summary>
    ///     Sets Up Data
    /// </summary>
    private void SetUpData()
    {
        Context.Bandera.Add(new Bandera
        {
            Name = "Bandera " + Guid.NewGuid(), ImageUri = "Banderas/Bandera_1_500.png", LastModified = DateTime.Now,
            Deleted = false
        });
        Context.Bandera.Add(new Bandera
        {
            Name = "Bandera " + Guid.NewGuid(), ImageUri = "Banderas/Bandera_2_500.png", LastModified = DateTime.Now,
            Deleted = false
        });
        Context.Bandera.Add(new Bandera
        {
            Name = "Bandera " + Guid.NewGuid(), ImageUri = "Banderas/Bandera_3_500.png", LastModified = DateTime.Now,
            Deleted = false
        });

        Context.SaveChanges();
    }

    /// <summary>
    ///     Finds All Bandera
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindAllBandera()
    {
        await BanderaManager.FindAllBandera();

        Assert.Pass();
    }

    /// <summary>
    ///     Finds Paginated Bandera
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindPaginatedBandera()
    {
        await BanderaManager.FindPaginatedBandera(new FilterPage { Index = 1, Size = 5 });

        Assert.Pass();
    }

    /// <summary>
    ///     Finds All Historico By Bandera Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindAllHistoricoByBanderaId()
    {
        await BanderaManager.FindAllHistoricoByBanderaId(Context.Bandera.FirstOrDefault().Id);

        Assert.Pass();
    }

    /// <summary>
    ///     Finds Bandera By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindBanderaById()
    {
        await BanderaManager.FindBanderaById(Context.Bandera.FirstOrDefault().Id);

        Assert.Pass();
    }

    /// <summary>
    ///     Removes Bandera By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task RemoveBanderaById()
    {
        await BanderaManager.RemoveBanderaById(Context.Bandera.FirstOrDefault().Id);

        Assert.Pass();
    }

    /// <summary>
    ///     Updates Bandera
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task UpdateBandera()
    {
        UpdateBandera Bandera = new()
        {
            Id = Context.Bandera.FirstOrDefault().Id,
            ImageUri = "URL/Bandera_21_500px.png",
            Name = "Bandera 21"
        };

        await BanderaManager.UpdateBandera(Bandera);

        Assert.Pass();
    }

    /// <summary>
    ///     Adds Bandera
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task AddBandera()
    {
        AddBandera Bandera = new()
        {
            ImageUri = "URL/Bandera_4_500px.png",
            Name = "Bandera 4"
        };

        await BanderaManager.AddBandera(Bandera);

        Assert.Pass();
    }

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public void CheckName()
    {
        AddBandera Bandera = new()
        {
            ImageUri = "URL/Bandera_3_500px.png",
            Name = Context.Bandera.FirstOrDefault().Name
        };
        var exception = Assert.ThrowsAsync<ServiceException>(async () => await BanderaManager.CheckName(Bandera));

        Assert.Pass();
    }
}