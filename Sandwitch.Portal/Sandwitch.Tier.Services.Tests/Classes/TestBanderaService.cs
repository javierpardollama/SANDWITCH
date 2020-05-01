using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using NUnit.Framework;

using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.Services.Classes;
using Sandwitch.Tier.ViewModels.Classes.Additions;
using Sandwitch.Tier.ViewModels.Classes.Updates;

namespace Sandwitch.Tier.Services.Tests.Classes
{
    /// <summary>
    /// Represents a <see cref="TestBanderaService"/> class. Inherits <see cref="TestBaseService"/>
    /// </summary>
    [TestFixture]
    public class TestBanderaService : TestBaseService
    {
        /// <summary>
        /// Instance of <see cref="ILogger{BanderaService}"/>
        /// </summary>
        private ILogger<BanderaService> Logger;

        /// <summary>
        /// Instance of <see cref="BanderaService"/>
        /// </summary>
        private BanderaService BanderaService;

        /// <summary>
        /// Initializes a new Instance of <see cref="TestBanderaService"/>
        /// </summary>
        public TestBanderaService()
        {
        }

        /// <summary>
        /// Sets Up
        /// </summary>
        [SetUp]
        public void Setup()
        {
            SetUpSettings();

            SetUpConfiguration();

            SetUpOptions();

            SetUpServices();

            SetUpMapper();

            SetUpLogger();

            SetUpContext();

            BanderaService = new BanderaService(Context, Mapper, Logger);
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

            Logger = @loggerFactory.CreateLogger<BanderaService>();
        }

        /// <summary>
        /// Sets Up Context
        /// </summary>
        private void SetUpContext()
        {
            Context.Bandera.Add(new Bandera { Name = "Bandera " + Guid.NewGuid().ToString(), ImageUri = "Banderas/Bandera_1_500.png", LastModified = DateTime.Now, Deleted = false });
            Context.Bandera.Add(new Bandera { Name = "Bandera " + Guid.NewGuid().ToString(), ImageUri = "Banderas/Bandera_2_500.png", LastModified = DateTime.Now, Deleted = false });
            Context.Bandera.Add(new Bandera { Name = "Bandera " + Guid.NewGuid().ToString(), ImageUri = "Banderas/Bandera_3_500.png", LastModified = DateTime.Now, Deleted = false });

            Context.SaveChanges();
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
        /// Finds All Bandera
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindAllBandera()
        {
            await BanderaService.FindAllBandera();

            Assert.Pass();
        }

        /// <summary>
        /// Finds All Historico By Bandera Id
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindAllHistoricoByBanderaId()
        {
            await BanderaService.FindAllHistoricoByBanderaId(Context.Bandera.FirstOrDefault().Id);

            Assert.Pass();
        }

        /// <summary>
        /// Finds Bandera By Id
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindBanderaById()
        {
            await BanderaService.FindBanderaById(Context.Bandera.FirstOrDefault().Id);

            Assert.Pass();
        }

        /// <summary>
        /// Removes Bandera By Id
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task RemoveBanderaById()
        {
            await BanderaService.RemoveBanderaById(Context.Bandera.FirstOrDefault().Id);

            Assert.Pass();
        }

        /// <summary>
        /// Updates Bandera
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task UpdateBandera()
        {
            UpdateBandera bandera = new UpdateBandera()
            {
                Id = Context.Bandera.FirstOrDefault().Id,
                ImageUri = "URL/Bandera_21_500px.png",
                Name = "Bandera 21"
            };

            await BanderaService.UpdateBandera(bandera);

            Assert.Pass();
        }

        /// <summary>
        /// Adds Bandera
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task AddBandera()
        {
            AddBandera @bandera = new AddBandera()
            {
                ImageUri = "URL/Bandera_4_500px.png",
                Name = "Bandera 4"
            };

            await BanderaService.AddBandera(@bandera);

            Assert.Pass();
        }

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public void CheckName()
        {
            AddBandera @bandera = new AddBandera()
            {
                ImageUri = "URL/Bandera_3_500px.png",
                Name = Context.Bandera.FirstOrDefault().Name
            };
            Exception exception = Assert.ThrowsAsync<Exception>(async () => await BanderaService.CheckName(@bandera));

            Assert.Pass();
        }
    }
}
