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

        SetUpData();

        VientoManager = new VientoManager(Context, Logger);
    }

    /// <summary>
    ///     Tears Down
    /// </summary>
    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        Context.SaveChanges();
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
    ///     Sets Up Context
    /// </summary>
    private void SetUpData()
    {
        Context.Viento.Add(new Viento
        {
            Name = "Viento " + Guid.NewGuid(), ImageUri = "Vientos/Viento_1_500.png", LastModified = DateTime.Now,
            Deleted = false
        });
        Context.Viento.Add(new Viento
        {
            Name = "Viento " + Guid.NewGuid(), ImageUri = "Vientos/Viento_2_500.png", LastModified = DateTime.Now,
            Deleted = false
        });
        Context.Viento.Add(new Viento
        {
            Name = "Viento " + Guid.NewGuid(), ImageUri = "Vientos/Viento_3_500.png", LastModified = DateTime.Now,
            Deleted = false
        });

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
        await VientoManager.FindPaginatedViento(new FilterPage { Index = 1, Size = 5 });

        Assert.Pass();
    }

    /// <summary>
    ///     Finds All Historico By Viento Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindAllHistoricoByVientoId()
    {
        await VientoManager.FindAllHistoricoByVientoId(Context.Viento.FirstOrDefault().Id);

        Assert.Pass();
    }

    /// <summary>
    ///     Finds Viento By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindVientoById()
    {
        await VientoManager.FindVientoById(Context.Viento.FirstOrDefault().Id);

        Assert.Pass();
    }

    /// <summary>
    ///     Removes Viento By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task RemoveVientoById()
    {
        await VientoManager.RemoveVientoById(Context.Viento.FirstOrDefault().Id);

        Assert.Pass();
    }

    /// <summary>
    ///     Updates Viento
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task UpdateViento()
    {
        UpdateViento Viento = new()
        {
            Id = Context.Viento.FirstOrDefault().Id,
            ImageUri = "URL/Viento_21_500px.png",
            Name = "Viento 21"
        };

        await VientoManager.UpdateViento(Viento);

        Assert.Pass();
    }

    /// <summary>
    ///     Adds Viento
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task AddViento()
    {
        AddViento Viento = new()
        {
            ImageUri = "URL/Viento_4_500px.png",
            Name = "Viento 4"
        };

        await VientoManager.AddViento(Viento);

        Assert.Pass();
    }

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public void CheckName()
    {
        AddViento Viento = new()
        {
            ImageUri = "URL/Viento_3_500px.png",
            Name = Context.Viento.FirstOrDefault().Name
        };
        var exception = Assert.ThrowsAsync<ServiceException>(async () => await VientoManager.CheckName(Viento));

        Assert.Pass();
    }
}