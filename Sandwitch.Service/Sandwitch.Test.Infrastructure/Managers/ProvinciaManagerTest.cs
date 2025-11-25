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
///     Represents a <see cref="ProvinciaManagerTest" /> class. Inherits <see cref="BaseManagerTest" />
/// </summary>
[TestFixture]
public class ProvinciaManagerTest : BaseManagerTest
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

        ProvinciaManager = new ProvinciaManager(Context, Logger);
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
    ///     Instance of <see cref="ILogger{ProvinciaManager}" />
    /// </summary>
    private ILogger<ProvinciaManager> Logger;


    /// <summary>
    ///     Instance of <see cref="ProvinciaManager" />
    /// </summary>
    private ProvinciaManager ProvinciaManager;


    /// <summary>
    ///     Initializes a new Instance of <see cref="ArenalManagerTest" />
    /// </summary>
    public ProvinciaManagerTest()
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

        Logger = loggerFactory.CreateLogger<ProvinciaManager>();
    }   

    /// <summary>
    ///     Finds All Provincia
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindAllProvincia()
    {
        await ProvinciaManager.FindAllProvincia();

        Assert.Pass();
    }

    /// <summary>
    ///     Finds Paginated Provincia
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindPaginatedProvincia()
    {
        await ProvinciaManager.FindPaginatedProvincia(1,  5);

        Assert.Pass();
    }

    /// <summary>
    ///     Finds Provincia By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindProvinciaById()
    {
        await ProvinciaManager.FindProvinciaById(1);

        Assert.Pass();
    }

    /// <summary>
    ///     Removes Provincia By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task RemoveProvinciaById()
    {
        await ProvinciaManager.RemoveProvinciaById(1);

        Assert.Pass();
    }

    /// <summary>
    ///     Updates Provincia
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task UpdateProvincia()
    {
        Provincia entity = new()
        {
            Id = 2,
            ImageUri = "URL/Guipuzcoa_500px.png",
            Name = "Guipuzcoa"
        };

        await ProvinciaManager.UpdateProvincia(entity);

        Assert.Pass();
    }

    /// <summary>
    ///     Adds Provincia
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task AddProvincia()
    {
        Provincia entity = new()
        {          
            ImageUri = "URL/Asturias_500px.png",
            Name = "Asturias"
        };

        await ProvinciaManager.AddProvincia(entity);

        Assert.Pass();
    }

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public void CheckName()
    {
        Provincia entity = new()
        {
            Id = 3,
            Name = "Cantabria",
            ImageUri = "URL/Cantabria_500px.png",           
        };

        var exception = Assert.ThrowsAsync<ServiceException>(async () => await ProvinciaManager.CheckName(entity.Name));

        Assert.Pass();
    }

    /// <summary>
    ///     Reloads Provincia By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task ReloadProvinciaById()
    {
        await ProvinciaManager.ReloadProvinciaById(2);

        Assert.Pass();
    }
}