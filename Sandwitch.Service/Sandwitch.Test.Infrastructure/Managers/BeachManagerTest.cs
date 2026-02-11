using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Sandwitch.Domain.Entities;
using Sandwitch.Domain.Exceptions;
using Sandwitch.Infrastructure.Contexts;
using Sandwitch.Infrastructure.Managers;
using Sandwitch.Test.Infrastructure.Extensions;
using System.Threading.Tasks;

namespace Sandwitch.Test.Infrastructure.Managers;

/// <summary>
///     Represents a <see cref="BeachManagerTest" /> class. Inherits <see cref="BaseManagerTest" />
/// </summary>
[TestFixture]
public class BeachManagerTest : BaseManagerTest
{
    /// <summary>
    ///     Sets Up
    /// </summary>
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        Context = new ApplicationContext(ContextOptionsBuilder.Options);

        SetUpLogger();

        Context.Seed();

        BeachManager = new BeachManager(Context, Logger);
    }

    /// <summary>
    ///     Tears Downs
    /// </summary>
    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        Context.Dispose();
    }

    /// <summary>
    ///     Instance of <see cref="ILogger{BeachManager}" />
    /// </summary>
    private ILogger<BeachManager> Logger;

    /// <summary>
    ///     Instance of <see cref="BeachManager" />
    /// </summary>
    private BeachManager BeachManager;

    /// <summary>
    ///     Initializes a new Instance of <see cref="BeachManagerTest" />
    /// </summary>
    public BeachManagerTest()
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
                .AddFilter("Default", LogLevel.Information)
                .AddFilter("Microsoft", LogLevel.Warning)
                .AddFilter("System", LogLevel.Warning);
        });

        Logger = loggerFactory.CreateLogger<BeachManager>();
    }

    /// <summary>
    ///     Finds All Beach
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindAllBeach()
    {
        await BeachManager.FindAllBeach();

        Assert.Pass();
    }

    /// <summary>
    ///     Finds Paginated Beach
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindPaginatedBeach()
    {
        await BeachManager.FindPaginatedBeach(1, 5);

        Assert.Pass();
    }

    /// <summary>
    ///     Finds All Historic By Beach Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindAllHistoricByBeachId()
    {
        await BeachManager.FindAllHistoricByBeachId(1);

        Assert.Pass();
    }

    /// <summary>
    ///     Finds Beach By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindBeachById()
    {
        await BeachManager.FindBeachById(1);

        Assert.Pass();
    }

    /// <summary>
    ///     Finds Town By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindTownById()
    {
        await BeachManager.FindTownById(1);

        Assert.Pass();
    }

    /// <summary>
    ///     Finds Flag By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindFlagById()
    {
        await BeachManager.FindFlagById(1);

        Assert.Pass();
    }

    /// <summary>
    ///     Finds Wind By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindWindById()
    {
        await BeachManager.FindWindById(1);

        Assert.Pass();
    }

    /// <summary>
    ///     Removes Beach By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task RemoveBeachById()
    {
        await BeachManager.RemoveBeachById(1);

        Assert.Pass();
    }

    /// <summary>
    ///     Updates Beach
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task UpdateBeach()
    {
        Beach @entity = new()
        {
            Id = 2,
            Name = "Las Arenas",
        };

        await BeachManager.UpdateBeach(@entity);

        Assert.Pass();
    }

    /// <summary>
    ///     Adds Beach
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task AddBeach()
    {
        Beach @entity = new()
        {
            Id = 3,
            Name = "Ereaga"
        };

        await BeachManager.AddBeach(entity);

        Assert.Pass();
    }

    /// <summary>
    ///    Adds Historic
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task AddHistoric()
    {
        Beach @entity = new()
        {
            Id = 4,
            Name = "Gorrondatxe",
        };

        await BeachManager.AddHistoric(entity);

        Assert.Pass();
    }

    /// <summary>
    ///    Finds All Town By Ids
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindAllTownByIds()
    {
        await BeachManager.FindAllTownByIds([1, 2]);

        Assert.Pass();
    }

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public void CheckName()
    {
        Beach @entity = new()
        {
            Id = 2,
            Name = "La Arena",
        };

        var exception = Assert.ThrowsAsync<ServiceException>(async () => await BeachManager.CheckName(@entity.Name));

        Assert.Pass();
    }

    /// <summary>
    ///     Reloads Beach By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task ReloadBeachById()
    {
        await BeachManager.ReloadBeachById(2);

        Assert.Pass();
    }
}