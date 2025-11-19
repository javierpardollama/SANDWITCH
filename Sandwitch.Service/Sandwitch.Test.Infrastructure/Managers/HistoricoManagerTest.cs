using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Sandwitch.Domain.Entities;
using Sandwitch.Infrastructure.Managers;
using System;
using System.Linq;
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
        SetUpContext();

        SetUpLogger();

        SetUpData();

        HistoricoManager = new HistoricoManager(Context, Logger);
    }

    /// <summary>
    ///     Tears Down
    /// </summary>
    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        Context.Arenal.RemoveRange(Context.Arenal.ToList());

        Context.Bandera.RemoveRange(Context.Bandera.ToList());

        Context.Poblacion.RemoveRange(Context.Poblacion.ToList());

        Context.Viento.RemoveRange(Context.Viento.ToList());

        Context.SaveChanges();
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
    ///     Sets Up Data
    /// </summary>
    private void SetUpData()
    {
        Context.Arenal.Add(new Arenal { Name = "Arenal 1", LastModified = DateTime.Now, Deleted = false });
        Context.Poblacion.Add(new Poblacion
        {
            Name = "Poblacion 1", ImageUri = "URL/Poblacion_01_500px.png", LastModified = DateTime.Now, Deleted = false
        });
        Context.Bandera.Add(new Bandera
        {
            Name = "Bandera 1", ImageUri = "URL/Bandera_01_500px.png", LastModified = DateTime.Now, Deleted = false
        });
        Context.Viento.Add(new Viento
            { Name = "Viento 1", ImageUri = "URL/Viento_01_500px.png", LastModified = DateTime.Now, Deleted = false });

        Context.SaveChanges();
    }

    /// <summary>
    ///     Finds Arenal By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindArenalById()
    {
        await HistoricoManager.FindArenalById(Context.Arenal.FirstOrDefault().Id);

        Assert.Pass();
    }

    /// <summary>
    ///     Finds Bandera By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindBanderaById()
    {
        await HistoricoManager.FindBanderaById(Context.Bandera.FirstOrDefault().Id);

        Assert.Pass();
    }

    /// <summary>
    ///     Finds Viento By Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindVientoById()
    {
        await HistoricoManager.FindVientoById(Context.Viento.FirstOrDefault().Id);

        Assert.Pass();
    }

    /// <summary>
    ///     Adds Historico
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task AddHistorico()
    {
        AddHistorico Historico = new()
        {
            BanderaId = Context.Bandera.FirstOrDefault().Id,
            VientoId = Context.Viento.FirstOrDefault().Id,
            AltaMarAlba = DateTime.Now.TimeOfDay,
            AltaMarOcaso = DateTime.Now.TimeOfDay,
            ArenalId = Context.Arenal.FirstOrDefault().Id,
            BajaMarAlba = DateTime.Now.TimeOfDay,
            BajaMarOcaso = DateTime.Now.TimeOfDay,
            Temperatura = 20,
            Velocidad = 10
        };

        await HistoricoManager.AddHistorico(Historico);

        Assert.Pass();
    }
}