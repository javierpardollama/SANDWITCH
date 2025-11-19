using NUnit.Framework;
using Sandwitch.Domain.Entities;
using Sandwitch.Infrastructure.Managers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sandwitch.Test.Infrastructure.Managers;

/// <summary>
///     Represents a <see cref="BuscadorManagerTest" /> class. Inherits <see cref="BaseManagerTest" />
/// </summary>
[TestFixture]
public class BuscadorManagerTest : BaseManagerTest
{
    /// <summary>
    ///     Sets Up
    /// </summary>
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        SetUpContext();

        Seed();

        BuscadorManager = new BuscadorManager(Context);
    }   

    /// <summary>
    ///     Instance of <see cref="BuscadorManager" />
    /// </summary>
    private BuscadorManager BuscadorManager;

    /// <summary>
    ///     Initializes a new Instance of <see cref="BuscadorManagerTest" />
    /// </summary>
    public BuscadorManagerTest()
    {
    }

    /// <summary>
    ///     Seeds
    /// </summary>
    private void Seed()
    {
        Context.Viento.Add(new Viento
        {
            Id = 1,
            Name = "Norte",
            ImageUri = "URL/Norte_500.png",
            LastModified = DateTime.Now,
            Deleted = false
        });

        Context.Bandera.Add(new Bandera
        {
            Id = 1,
            Name = "Amarilla ",
            ImageUri = "URL/Amarilla_500.png",
            LastModified = DateTime.Now,
            Deleted = false
        });

        Context.Provincia.Add(new Provincia
        {
            Id = 1,
            Name = "Bizkaia",
            ImageUri = "URL/Bizkaia_500px.png",
            LastModified = DateTime.Now,
            Deleted = false
        });

        Context.Poblacion.Add(new Poblacion
        {
            Id = 1,
            Name = "Muskiz",
            ImageUri = "URL/Muskiz_500px.png",
            LastModified = DateTime.Now,
            Deleted = false
        });

        Context.Arenal.Add(new Arenal
        {
            Id = 1,
            Name = "La Arena",
            LastModified = DateTime.Now,
            Deleted = false,
            ArenalPoblaciones = [
                new()
                {
                    ArenalId = 1,
                    PoblacionId = 1,
                }
                ]
        });

        Context.Historico.Add(new Historico()
        {
            Id = 1,
            LastModified = DateTime.Now,
            Deleted = false,
            BajaMarAlba = DateTime.Now.TimeOfDay,
            BajaMarOcaso = DateTime.Now.TimeOfDay,
            AltaMarAlba = DateTime.Now.TimeOfDay,
            AltaMarOcaso = DateTime.Now.TimeOfDay,
            Temperatura = 20,
            Velocidad = 0,
            ArenalId = 1,
            VientoId = 1,
            BanderaId = 1,
        });
    }


    /// <summary>
    ///     Finds All Buscador
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindAllBuscador()
    {
        await BuscadorManager.FindAllBuscador();

        Assert.Pass();
    }

    /// <summary>
    ///     Finds All Arenal By Buscador Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindAllArenalByBuscadorId()
    {
        await BuscadorManager.FindAllArenalByBuscadorId(1, nameof(Poblacion));

        Assert.Pass();
    }
}