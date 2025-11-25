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
///     Represents a <see cref="PoblacionManagerTest" /> class. Inherits <see cref="BaseManagerTest" />
/// </summary>
[TestFixture]
public class PoblacionManagerTest : BaseManagerTest
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

        PoblacionManager = new PoblacionManager(Context, Logger);
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
    ///     Instance of <see cref="ILogger{PoblacionManager}" />
    /// </summary>
    private ILogger<PoblacionManager> Logger;

    /// <summary>
    ///     Instance of <see cref="PoblacionManager" />
    /// </summary>
    private PoblacionManager PoblacionManager;


    /// <summary>
    ///     Initializes a new Instance of <see cref="ArenalManagerTest" />
    /// </summary>
    public PoblacionManagerTest()
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

        Logger = loggerFactory.CreateLogger<PoblacionManager>();
    }   

    /// <summary>
    ///     Finds All Poblacion
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindAllPoblacion()
    {
        await PoblacionManager.FindAllPoblacion();

        Assert.Pass();
    }

    /// <summary>
    ///     Finds Paginated Poblacion
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindPaginatedPoblacion()
    {
        await PoblacionManager.FindPaginatedPoblacion(1, 5);

        Assert.Pass();
    }

    /// <summary>
    ///     Finds Poblacion By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindPoblacionById()
    {
        await PoblacionManager.FindPoblacionById(1);

        Assert.Pass();
    }

    /// <summary>
    ///     Finds Provincia By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindProvinciaById()
    {
        await PoblacionManager.FindProvinciaById(1);

        Assert.Pass();
    }

    /// <summary>
    ///     Removes Poblacion By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task RemovePoblacionById()
    {
        await PoblacionManager.RemovePoblacionById(1);

        Assert.Pass();
    }

    /// <summary>
    ///     Updates Poblacion
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task UpdatePoblacion()
    {
        Poblacion entity = new()
        {
            Id = 2,
            ImageUri = "URL/Musques_500px.png",
            Name = "Musques",
            ProvinciaId = 1
        };

        await PoblacionManager.UpdatePoblacion(entity);

        Assert.Pass();
    }

    /// <summary>
    ///     Adds Poblacion
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task AddPoblacion()
    {
        Poblacion entity = new()
        {
            ImageUri = "URL/Sopela_500px.png",
            Name = "Sopela 4",
            ProvinciaId = 1
        };

        await PoblacionManager.AddPoblacion(entity);

        Assert.Pass();
    }

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public void CheckName()
    {
        Poblacion entity = new()
        {           
            Id = 3,
            Name = "Getxo",
            ImageUri = "URL/Getxo_500px.png",        
        };

        var exception = Assert.ThrowsAsync<ServiceException>(async () => await PoblacionManager.CheckName(entity.Name));

        Assert.Pass();
    }

    /// <summary>
    ///     Reloads Poblacion By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task ReloadPoblacionById()
    {
        await PoblacionManager.ReloadPoblacionById(2);

        Assert.Pass();
    }
}