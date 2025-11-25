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
///     Represents a <see cref="HistoricoManagerTest" /> class. Inherits <see cref="BaseManagerTest" />
/// </summary>
[TestFixture]
public class HistoricoManagerTest : BaseManagerTest
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

        HistoricoManager = new HistoricoManager(Context, Logger);
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
    ///     Instance of <see cref="ILogger{HistoricoManager}" />
    /// </summary>
    private ILogger<HistoricoManager> Logger;

    /// <summary>
    ///     Instance of <see cref="HistoricoManager" />
    /// </summary>
    private HistoricoManager HistoricoManager;

    /// <summary>
    ///     Initializes a new Instance of <see cref="ArenalManagerTest" />
    /// </summary>
    public HistoricoManagerTest()
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

        Logger = loggerFactory.CreateLogger<HistoricoManager>();
    }

    /// <summary>
    ///     Finds Arenal By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindArenalById()
    {
        await HistoricoManager.FindArenalById(1);

        Assert.Pass();
    }

    /// <summary>
    ///     Finds Bandera By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindBanderaById()
    {
        await HistoricoManager.FindBanderaById(1);

        Assert.Pass();
    }

    /// <summary>
    ///     Finds Viento By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindVientoById()
    {
        await HistoricoManager.FindVientoById(1);

        Assert.Pass();
    }

    /// <summary>
    ///     Adds Historico
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task AddHistorico()
    {
        Historico entity = new()
        {
            BanderaId = 1,
            VientoId = 1,
            AltaMarAlba = DateTime.Now.TimeOfDay,
            AltaMarOcaso = DateTime.Now.TimeOfDay,
            ArenalId = 1,
            BajaMarAlba = DateTime.Now.TimeOfDay,
            BajaMarOcaso = DateTime.Now.TimeOfDay,
            Temperatura = 20,
            Velocidad = 10
        };

        await HistoricoManager.AddHistorico(entity);

        Assert.Pass();
    }
}