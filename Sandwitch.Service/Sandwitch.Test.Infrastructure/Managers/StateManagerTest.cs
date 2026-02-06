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
///     Represents a <see cref="StateManagerTest" /> class. Inherits <see cref="BaseManagerTest" />
/// </summary>
[TestFixture]
public class StateManagerTest : BaseManagerTest
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

        StateManager = new StateManager(Context, Logger);
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
    ///     Instance of <see cref="ILogger{StateManager}" />
    /// </summary>
    private ILogger<StateManager> Logger;


    /// <summary>
    ///     Instance of <see cref="StateManager" />
    /// </summary>
    private StateManager StateManager;


    /// <summary>
    ///     Initializes a new Instance of <see cref="BeachManagerTest" />
    /// </summary>
    public StateManagerTest()
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

        Logger = loggerFactory.CreateLogger<StateManager>();
    }

    /// <summary>
    ///     Finds All State
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindAllState()
    {
        await StateManager.FindAllState();

        Assert.Pass();
    }

    /// <summary>
    ///     Finds Paginated State
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindPaginatedState()
    {
        await StateManager.FindPaginatedState(1, 5);

        Assert.Pass();
    }

    /// <summary>
    ///     Finds State By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindStateById()
    {
        await StateManager.FindStateById(1);

        Assert.Pass();
    }

    /// <summary>
    ///     Removes State By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task RemoveStateById()
    {
        await StateManager.RemoveStateById(1);

        Assert.Pass();
    }

    /// <summary>
    ///     Updates State
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task UpdateState()
    {
        State entity = new()
        {
            Id = 2,
            ImageUri = "URL/Guipuzcoa_500px.png",
            Name = "Guipuzcoa"
        };

        await StateManager.UpdateState(entity);

        Assert.Pass();
    }

    /// <summary>
    ///     Adds State
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task AddState()
    {
        State entity = new()
        {
            ImageUri = "URL/Asturias_500px.png",
            Name = "Asturias"
        };

        await StateManager.AddState(entity);

        Assert.Pass();
    }

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public void CheckName()
    {
        State entity = new()
        {
            Id = 3,
            Name = "Cantabria",
            ImageUri = "URL/Cantabria_500px.png",
        };

        var exception = Assert.ThrowsAsync<ServiceException>(async () => await StateManager.CheckName(entity.Name));

        Assert.Pass();
    }

    /// <summary>
    ///     Reloads State By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task ReloadStateById()
    {
        await StateManager.ReloadStateById(2);

        Assert.Pass();
    }
}