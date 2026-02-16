using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Sandwitch.Domain.Entities;
using Sandwitch.Infrastructure.Contexts;
using Sandwitch.Infrastructure.Managers;
using Sandwitch.Test.Infrastructure.Extensions;
using System;
using System.Threading.Tasks;

namespace Sandwitch.Test.Infrastructure.Managers;

/// <summary>
///     Represents a <see cref="HistoricManagerTest" /> class. Inherits <see cref="BaseManagerTest" />
/// </summary>
[TestFixture]
public class HistoricManagerTest : BaseManagerTest
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

        HistoricManager = new HistoricManager(Context, Logger);
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
    ///     Instance of <see cref="ILogger{HistoricManager}" />
    /// </summary>
    private ILogger<HistoricManager> Logger;

    /// <summary>
    ///     Instance of <see cref="HistoricManager" />
    /// </summary>
    private HistoricManager HistoricManager;

    /// <summary>
    ///     Initializes a new Instance of <see cref="BeachManagerTest" />
    /// </summary>
    public HistoricManagerTest()
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

        Logger = loggerFactory.CreateLogger<HistoricManager>();
    }

    /// <summary>
    ///     Finds Beach By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindBeachById()
    {
        await HistoricManager.FindBeachById(1);

        Assert.Pass();
    }

    /// <summary>
    ///     Finds Flag By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindFlagById()
    {
        await HistoricManager.FindFlagById(1);

        Assert.Pass();
    }

    /// <summary>
    ///     Finds Wind By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindWindById()
    {
        await HistoricManager.FindWindById(1);

        Assert.Pass();
    }

    /// <summary>
    ///     Adds Historic
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task AddHistoric()
    {
        Historic entity = new()
        {
            FlagId = 1,
            WindId = 1,
            HighSeaDawn = DateTime.Now,
            HighSeaSunset = DateTime.Now,
            BeachId = 1,
            LowSeaDawn = DateTime.Now,
            LowSeaSunset = DateTime.Now,
            Temperature = 20,
            Speed = 10
        };

        await HistoricManager.AddHistoric(entity);

        Assert.Pass();
    }
}