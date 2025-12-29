using NUnit.Framework;
using Sandwitch.Domain.Entities;
using Sandwitch.Infrastructure.Contexts;
using Sandwitch.Infrastructure.Managers;
using Sandwitch.Test.Infrastructure.Extensions;
using System.Threading.Tasks;

namespace Sandwitch.Test.Infrastructure.Managers;

/// <summary>
///     Represents a <see cref="FinderManagerTest" /> class. Inherits <see cref="BaseManagerTest" />
/// </summary>
[TestFixture]
public class FinderManagerTest : BaseManagerTest
{
    /// <summary>
    ///     Sets Up
    /// </summary>
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        Context = new ApplicationContext(ContextOptionsBuilder.Options);

        Context.Seed();

        FinderManager = new FinderManager(Context);
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
    ///     Instance of <see cref="FinderManager" />
    /// </summary>
    private FinderManager FinderManager;

    /// <summary>
    ///     Initializes a new Instance of <see cref="FinderManagerTest" />
    /// </summary>
    public FinderManagerTest()
    {
    }

    /// <summary>
    ///     Finds All Finder
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindAllFinder()
    {
        await FinderManager.FindAllFinder();

        Assert.Pass();
    }

    /// <summary>
    ///     Finds All Beach By Finder Id
    /// </summary>
    /// <returns>Instance of <see cref="Task" /></returns>
    [Test]
    public async Task FindAllBeachByFinderId()
    {
        await FinderManager.FindAllBeachByFinderId(1, nameof(Town));

        Assert.Pass();
    }
}