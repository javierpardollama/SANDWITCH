using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Sandwitch.Domain.Entities;
using Sandwitch.Domain.Exceptions;
using Sandwitch.Infrastructure.Managers;
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

        Context.Seed();

        BanderaManager = new BanderaManager(Context, Logger);
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
        await BanderaManager.FindPaginatedBandera(1, 5);

        Assert.Pass();
    }

    /// <summary>
    ///     Finds All Historico By Bandera Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindAllHistoricoByBanderaId()
    {
        await BanderaManager.FindAllHistoricoByBanderaId(1);

        Assert.Pass();
    }

    /// <summary>
    ///     Finds Bandera By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindBanderaById()
    {
        await BanderaManager.FindBanderaById(1);

        Assert.Pass();
    }

    /// <summary>
    ///     Removes Bandera By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task RemoveBanderaById()
    {
        await BanderaManager.RemoveBanderaById(1);

        Assert.Pass();
    }

    /// <summary>
    ///     Updates Bandera
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task UpdateBandera()
    {
        Bandera entity = new()
        {
            Id = 2,
            ImageUri = "URL/Black_500px.png",
            Name = "Black"
        };

        await BanderaManager.UpdateBandera(entity);

        Assert.Pass();
    }

    /// <summary>
    ///     Adds Bandera
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task AddBandera()
    {
        Bandera Bandera = new()
        {            
            ImageUri = "URL/Verde_500px.png",
            Name = "Verde"
        };

        await BanderaManager.AddBandera(Bandera);

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
            ImageUri = "URL/Roja_500px.png",
            Name = "Roja"
        };
        var exception = Assert.ThrowsAsync<ServiceException>(async () => await BanderaManager.CheckName(@entity.Name));

        Assert.Pass();
    }

    /// <summary>
    ///     Reloads Bandera By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task ReloadBanderaById()
    {      
        await BanderaManager.ReloadBanderaById(2);

        Assert.Pass();
    }
}