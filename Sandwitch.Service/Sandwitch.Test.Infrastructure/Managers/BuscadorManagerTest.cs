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

        SetUpData();

        BuscadorManager = new BuscadorManager(Context);
    }

    /// <summary>
    ///     Tears Down
    /// </summary>
    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        Context.Arenal.RemoveRange(Context.Arenal.ToList());

        Context.Poblacion.RemoveRange(Context.Poblacion.ToList());

        Context.SaveChanges();
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
    ///     Sets Up Data
    /// </summary>
    private void SetUpData()
    {
        Context.Poblacion.Add(new Poblacion
        {
            Name = "Poblacion " + Guid.NewGuid(), ImageUri = "Poblaciones/Poblacion_1_500.png",
            LastModified = DateTime.Now, Deleted = false
        });
        Context.Poblacion.Add(new Poblacion
        {
            Name = "Poblacion " + Guid.NewGuid(), ImageUri = "Poblaciones/Poblacion_2_500.png",
            LastModified = DateTime.Now, Deleted = false
        });

        Context.Arenal.Add(new Arenal
            { Name = "Arenal " + Guid.NewGuid(), LastModified = DateTime.Now, Deleted = false });
        Context.Arenal.Add(new Arenal
            { Name = "Arenal " + Guid.NewGuid(), LastModified = DateTime.Now, Deleted = false });

        Context.SaveChanges();
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
        await BuscadorManager.FindAllArenalByBuscadorId(new FinderArenal
            { Id = Context.Poblacion.FirstOrDefault().Id, Type = nameof(Poblacion) });

        Assert.Pass();
    }
}