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
///     Represents a <see cref="WindManagerTest" /> class. Inherits <see cref="BaseManagerTest" />
/// </summary>
[TestFixture]
public class WindManagerTest : BaseManagerTest
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

        WindManager = new WindManager(Context, Logger);
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
    ///     Instance of <see cref="ILogger{WindManager}" />
    /// </summary>
    private ILogger<WindManager> Logger;

    /// <summary>
    ///     Instance of <see cref="WindManager" />
    /// </summary>
    private WindManager WindManager;

    /// <summary>
    ///     Initializes a new Instance of <see cref="WindManagerTest" />
    /// </summary>
    public WindManagerTest()
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

        Logger = loggerFactory.CreateLogger<WindManager>();
    }    

    /// <summary>
    ///     Finds All Wind
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindAllWind()
    {
        await WindManager.FindAllWind();

        Assert.Pass();
    }

    /// <summary>
    ///     Finds Paginated Wind
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindPaginatedWind()
    {
        await WindManager.FindPaginatedWind(1, 5);

        Assert.Pass();
    }

    /// <summary>
    ///     Finds All Historic By Wind Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindAllHistoricByWindId()
    {
        await WindManager.FindAllHistoricByWindId(1);

        Assert.Pass();
    }

    /// <summary>
    ///     Finds Wind By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindWindById()
    {
        await WindManager.FindWindById(1);

        Assert.Pass();
    }

    /// <summary>
    ///     Removes Wind By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task RemoveWindById()
    {
        await WindManager.RemoveWindById(1);

        Assert.Pass();
    }

    /// <summary>
    ///     Updates Wind
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task UpdateWind()
    {
        Wind entity = new()
        {
            Id = 2,
            ImageUri = "URL/North_West_500px.png",
            Name = "North West"
        };

        await WindManager.UpdateWind(entity);

        Assert.Pass();
    }

    /// <summary>
    ///     Adds Wind
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task AddWind()
    {
        Wind entity = new()
        {
            ImageUri = "URL/Sudoeste_500px.png",
            Name = "Sudoeste"
        };

        await WindManager.AddWind(entity);

        Assert.Pass();
    }

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public void CheckNameAsync()
    {
        Flag @entity = new()
        {
            Id = 3,
            ImageUri = "URL/Oeste_500px.png",
            Name = "Oeste"
        };
        var exception = Assert.ThrowsAsync<ServiceException>(async () => await WindManager.CheckName(@entity.Name));

        Assert.Pass();
    }

    /// <summary>
    ///     Reloads Flag By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task ReloadFlagById()
    {
        await WindManager.ReloadWindById(2);

        Assert.Pass();
    }
}