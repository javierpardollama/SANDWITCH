using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Sandwitch.Infrastructure.Managers;

namespace Sandwitch.Test.Infrastructure.Managers;

/// <summary>
///     Represents a <see cref="AuthManagerTest" /> class. Inherits <see cref="BaseManagerTest" />
/// </summary>
[TestFixture]
public class AuthManagerTest : BaseManagerTest
{
    /// <summary>
    ///     Sets Up
    /// </summary>
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        SetUpLogger();

        AuthManager = new AuthManager(ApiOptions);
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
    ///     Instance of <see cref="ILogger{BanderaService}" />
    /// </summary>
    private ILogger<AuthManager> Logger;

    /// <summary>
    ///     Instance of <see cref="AuthManager" />
    /// </summary>
    private AuthManager AuthManager;

    /// <summary>
    ///     Initializes a new Instance of <see cref="AuthManagerTest" />
    /// </summary>
    public AuthManagerTest()
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

        Logger = loggerFactory.CreateLogger<AuthManager>();
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