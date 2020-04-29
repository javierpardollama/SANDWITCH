using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using NUnit.Framework;

using Sandwitch.Tier.Contexts.Classes;
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
            SetUpMapper();

            SetUpOptions();

            SetUpLogger();
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
        /// <param name="context">Injected <see cref="ApplicationContext"/></param>
        private void SetUpContext(ApplicationContext @context)
        {
            @context.Bandera.Add(new Bandera { Name = "Bandera 1", LastModified = DateTime.Now, Deleted = false });
            @context.Bandera.Add(new Bandera { Name = "Bandera 2", LastModified = DateTime.Now, Deleted = false });
            @context.Bandera.Add(new Bandera { Name = "Bandera 3", LastModified = DateTime.Now, Deleted = false });

            @context.SaveChanges();
        }

        /// <summary>
        /// Finds All Bandera
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindAllBandera()
        {
            using (ApplicationContext @context = new ApplicationContext(this.Options))
            {
                SetUpContext(@context);

                BanderaService @service = new BanderaService(@context, Mapper, Logger);

                await @service.FindAllBandera();
            };

            Assert.Pass();
        }

        /// <summary>
        /// Finds All Historico By Bandera Id
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindAllHistoricoByBanderaId() 
        {
            using (ApplicationContext @context = new ApplicationContext(this.Options))
            {
                SetUpContext(@context);

                BanderaService @service = new BanderaService(@context, Mapper, Logger);

                await @service.FindAllHistoricoByBanderaId(@context.Bandera.FirstOrDefault().Id);
            };

            Assert.Pass();
        }

        /// <summary>
        /// Finds Bandera By Id
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindBanderaById()
        {
            using (ApplicationContext @context = new ApplicationContext(this.Options))
            {
                SetUpContext(@context);

                BanderaService @service = new BanderaService(@context, Mapper, Logger);

                await @service.FindBanderaById(@context.Bandera.FirstOrDefault().Id);
            };

            Assert.Pass();
        }

        /// <summary>
        /// Removes Bandera By Id
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task RemoveBanderaById()
        {
            using (ApplicationContext @context = new ApplicationContext(this.Options))
            {
                SetUpContext(@context);

                BanderaService @service = new BanderaService(@context, Mapper, Logger);

                await @service.RemoveBanderaById(@context.Bandera.FirstOrDefault().Id);
            };

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
                Id = 2,
                ImageUri = "URL/Bandera_21_500px.png",
                Name = "Bandera 21"
            };

            using (ApplicationContext @context = new ApplicationContext(this.Options))
            {
                SetUpContext(@context);

                BanderaService @service = new BanderaService(@context, Mapper, Logger);

                await @service.UpdateBandera(bandera);
            };

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

            using (ApplicationContext @context = new ApplicationContext(this.Options))
            {
                SetUpContext(@context);

                BanderaService @service = new BanderaService(@context, Mapper, Logger);

                await @service.AddBandera(@bandera);
            };

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
                ImageUri = "URL/Bandera_4_500px.png",
                Name = "Bandera 4"
            };

            using (ApplicationContext @context = new ApplicationContext(this.Options))
            {
                SetUpContext(@context);

                BanderaService @service = new BanderaService(@context, Mapper, Logger);

                Exception exception = Assert.ThrowsAsync<Exception>(async () => await @service.CheckName(@bandera));
            };

            Assert.Pass();
        }
    }
}
