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
///     Represents a <see cref="TownManagerTest" /> class. Inherits <see cref="BaseManagerTest" />
/// </summary>
[TestFixture]
public class TownManagerTest : BaseManagerTest
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

        TownManager = new TownManager(Context, Logger);
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
    ///     Instance of <see cref="ILogger{TownManager}" />
    /// </summary>
    private ILogger<TownManager> Logger;

    /// <summary>
    ///     Instance of <see cref="TownManager" />
    /// </summary>
    private TownManager TownManager;


    /// <summary>
    ///     Initializes a new Instance of <see cref="BeachManagerTest" />
    /// </summary>
    public TownManagerTest()
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

        Logger = loggerFactory.CreateLogger<TownManager>();
    }   

    /// <summary>
    ///     Finds All Town
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindAllTown()
    {
        await TownManager.FindAllTown();

        Assert.Pass();
    }

    /// <summary>
    ///     Finds Paginated Town
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindPaginatedTown()
    {
        await TownManager.FindPaginatedTown(1, 5);

        Assert.Pass();
    }

    /// <summary>
    ///     Finds Town By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindTownById()
    {
        await TownManager.FindTownById(1);

        Assert.Pass();
    }

    /// <summary>
    ///     Finds State By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindStateById()
    {
        await TownManager.FindStateById(1);

        Assert.Pass();
    }

    /// <summary>
    ///     Removes Town By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task RemoveTownById()
    {
        await TownManager.RemoveTownById(1);

        Assert.Pass();
    }

    /// <summary>
    ///     Updates Town
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task UpdateTown()
    {
        Town entity = new()
        {
            Id = 2,
            ImageUri = "URL/Musques_500px.png",
            Name = "Musques",
            StateId = 1
        };

        await TownManager.UpdateTown(entity);

        Assert.Pass();
    }

    /// <summary>
    ///     Adds Town
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task AddTown()
    {
        Town entity = new()
        {
            ImageUri = "URL/Sopela_500px.png",
            Name = "Sopela 4",
            StateId = 1
        };

        await TownManager.AddTown(entity);

        Assert.Pass();
    }

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public void CheckName()
    {
        Town entity = new()
        {           
            Id = 3,
            Name = "Getxo",
            ImageUri = "URL/Getxo_500px.png",        
        };

        var exception = Assert.ThrowsAsync<ServiceException>(async () => await TownManager.CheckName(entity.Name));

        Assert.Pass();
    }

    /// <summary>
    ///     Reloads Town By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task ReloadTownById()
    {
        await TownManager.ReloadTownById(2);

        Assert.Pass();
    }
}