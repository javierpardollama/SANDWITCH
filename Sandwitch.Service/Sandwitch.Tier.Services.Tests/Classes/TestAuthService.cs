using Microsoft.Extensions.Logging;

using NUnit.Framework;

using Sandwitch.Tier.Services.Classes;
using Sandwitch.Tier.ViewModels.Classes.Auth;

namespace Sandwitch.Tier.Services.Tests.Classes
{
    /// <summary>
    /// Represents a <see cref="TestAuthService"/> class. Inherits <see cref="TestBaseService"/>
    /// </summary>
    [TestFixture]
    public class TestAuthService : TestBaseService
    {
        /// <summary>
        /// Instance of <see cref="ILogger{BanderaService}"/>
        /// </summary>
        private ILogger<AuthService> Logger;

        /// <summary>
        /// Instance of <see cref="AuthenticationService"/>
        /// </summary>
        private AuthService AuthService;

        /// <summary>
        /// Initializes a new Instance of <see cref="TestAuthService"/>
        /// </summary>
        public TestAuthService()
        {
        }

        /// <summary>
        /// Sets Up
        /// </summary>
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            SetUpLogger();

            AuthService = new AuthService(Logger, ApiOptions);
        }

        /// <summary>
        /// Sets Up Logger
        /// </summary>
        private void SetUpLogger()
        {
            ILoggerFactory @loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddConsole();
            });

            Logger = @loggerFactory.CreateLogger<AuthService>();
        }

        /// <summary>
        /// Can Authenticate
        /// </summary>
        [Test]
        public void CanAuthenticate()
        {
            AuthService.CanAuthenticate(new AuthSignIn()
            {
                PassWord = "Pauline",
                UserName = "T/R4J6eyvNG<6ne!"
            });

            Assert.Pass();
        }
    }
}
