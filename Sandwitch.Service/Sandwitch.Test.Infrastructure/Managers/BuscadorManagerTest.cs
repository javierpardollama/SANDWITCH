using NUnit.Framework;
using Sandwitch.Domain.Entities;
using Sandwitch.Infrastructure.Contexts;
using Sandwitch.Infrastructure.Managers;
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
        Context = new ApplicationContext(ContextOptionsBuilder.Options);

        Context.Seed();

        BuscadorManager = new BuscadorManager(Context);
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