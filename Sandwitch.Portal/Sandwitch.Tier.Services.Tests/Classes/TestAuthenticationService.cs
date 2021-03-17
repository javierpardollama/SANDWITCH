
using Microsoft.Extensions.Logging;

using NUnit.Framework;

using Sandwitch.Tier.Services.Classes;
using Sandwitch.Tier.ViewModels.Classes.Auth;

namespace Sandwitch.Tier.Services.Tests.Classes
{
    /// <summary>
    /// Represents a <see cref="TestAuthenticationService"/> class. Inherits <see cref="TestBaseService"/>
    /// </summary>
    [TestFixture]

    public class TestAuthenticationService : TestBaseService
    {
        /// <summary>
        /// Instance of <see cref="ILogger{BanderaService}"/>
        /// </summary>
        private ILogger<AuthenticationService> Logger;

        /// <summary>
        /// Instance of <see cref="AuthenticationService"/>
        /// </summary>
        private AuthenticationService AuthenticationService;

        /// <summary>
        /// Initializes a new Instance of <see cref="TestAuthenticationService"/>
        /// </summary>
        public TestAuthenticationService()
        {
        }

        /// <summary>
        /// Sets Up
        /// </summary>
        [SetUp]
        public void Setup()
        {
            SetUpContextOptions();

            SetUpApiOptions();

            SetUpServices();

            SetUpMapper();

            SetUpLogger();

            AuthenticationService = new AuthenticationService(Logger, ApiOptions);
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

            Logger = @loggerFactory.CreateLogger<AuthenticationService>();
        }

        /// <summary>
        /// Tears Down
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            Context.SaveChanges();
        }

        /// <summary>
        /// Can Authenticate
        /// </summary>
        [Test]
        public void CanAuthenticate() 
        {
            AuthenticationService.CanAuthenticate(new AuthSignIn() 
            {
                PassWord = "Pauline",
                UserName = "T/R4J6eyvNG<6ne!"
            });

            Assert.Pass();
        }
    }
}
