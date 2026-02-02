using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Sandwitch.Infrastructure.Contexts;
using Sandwitch.Infrastructure.Managers;
using Sandwitch.Test.Infrastructure.Extensions;

namespace Sandwitch.Test.Infrastructure.Managers;

/// <summary>
///     Represents a <see cref="CredentialManagerTest" /> class. Inherits <see cref="BaseManagerTest" />
/// </summary>
[TestFixture]
public class CredentialManagerTest : BaseManagerTest
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

        AuthManager = new CredentialManager(ApiOptions);
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
    ///     Instance of <see cref="ILogger{FlagService}" />
    /// </summary>
    private ILogger<CredentialManager> Logger;

    /// <summary>
    ///     Instance of <see cref="AuthManager" />
    /// </summary>
    private CredentialManager AuthManager;

    /// <summary>
    ///     Initializes a new Instance of <see cref="CredentialManagerTest" />
    /// </summary>
    public CredentialManagerTest()
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

        Logger = loggerFactory.CreateLogger<CredentialManager>();
    }

    /// <summary>
    ///     Can Authenticate
    /// </summary>
    [Test]
    public void CanAuthenticate()
    {
        AuthManager.CanAuthenticate("Pauline", "T/R4J6eyvNG<6ne!");

        Assert.Pass();
    }
}