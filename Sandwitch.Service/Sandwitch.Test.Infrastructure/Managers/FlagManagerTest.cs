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
///     Represents a <see cref="FlagManagerTest" /> class. Inherits <see cref="BaseManagerTest" />
/// </summary>
[TestFixture]
public class FlagManagerTest : BaseManagerTest
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

        FlagManager = new FlagManager(Context, Logger);
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
    ///     Instance of <see cref="ILogger{FlagManager}" />
    /// </summary>
    private ILogger<FlagManager> Logger;

    /// <summary>
    ///     Instance of <see cref="FlagManager" />
    /// </summary>
    private FlagManager FlagManager;

    /// <summary>
    ///     Initializes a new Instance of <see cref="FlagManagerTest" />
    /// </summary>
    public FlagManagerTest()
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

        Logger = loggerFactory.CreateLogger<FlagManager>();
    }

    /// <summary>
    ///     Finds All Flag
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindAllFlag()
    {
        await FlagManager.FindAllFlag();

        Assert.Pass();
    }

    /// <summary>
    ///     Finds Paginated Flag
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindPaginatedFlag()
    {
        await FlagManager.FindPaginatedFlag(1, 5);

        Assert.Pass();
    }

    /// <summary>
    ///     Finds All Historic By Flag Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindAllHistoricByFlagId()
    {
        await FlagManager.FindAllHistoricByFlagId(1);

        Assert.Pass();
    }

    /// <summary>
    ///     Finds Flag By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindFlagById()
    {
        await FlagManager.FindFlagById(1);

        Assert.Pass();
    }

    /// <summary>
    ///     Removes Flag By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task RemoveFlagById()
    {
        await FlagManager.RemoveFlagById(1);

        Assert.Pass();
    }

    /// <summary>
    ///     Updates Flag
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task UpdateFlag()
    {
        Flag entity = new()
        {
            Id = 2,
            ImageUri = "URL/Black_500px.png",
            Name = "Black"
        };

        await FlagManager.UpdateFlag(entity);

        Assert.Pass();
    }

    /// <summary>
    ///     Adds Flag
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task AddFlag()
    {
        Flag Flag = new()
        {
            ImageUri = "URL/Verde_500px.png",
            Name = "Verde"
        };

        await FlagManager.AddFlag(Flag);

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
            ImageUri = "URL/Roja_500px.png",
            Name = "Roja"
        };
        var exception = Assert.ThrowsAsync<ServiceException>(async () => await FlagManager.CheckName(@entity.Name));

        Assert.Pass();
    }

    /// <summary>
    ///     Reloads Flag By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task ReloadFlagById()
    {
        await FlagManager.ReloadFlagById(2);

        Assert.Pass();
    }
}