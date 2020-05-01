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
    /// Represents a <see cref="TestProvinciaService"/> class. Inherits <see cref="TestBaseService"/>
    /// </summary>
    [TestFixture]
    public class TestProvinciaService : TestBaseService
    {
        /// <summary>
        /// Instance of <see cref="ILogger{ProvinciaService}"/>
        /// </summary>
        private ILogger<ProvinciaService> Logger;


        /// <summary>
        /// Instance of <see cref="ProvinciaService"/>
        /// </summary>
        private ProvinciaService ProvinciaService;


        /// <summary>
        /// Initializes a new Instance of <see cref="TestArenalService"/>
        /// </summary>
        public TestProvinciaService()
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

            ProvinciaService = new ProvinciaService(Context, Mapper, Logger);
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

            Logger = @loggerFactory.CreateLogger<ProvinciaService>();
        }

        /// <summary>
        /// Sets Up Context
        /// </summary>
        private void SetUpContext()
        {
            Context.Provincia.Add(new Provincia { Name = "Provincia " + Guid.NewGuid().ToString(), LastModified = DateTime.Now, Deleted = false });
            Context.Provincia.Add(new Provincia { Name = "Provincia " + Guid.NewGuid().ToString(), LastModified = DateTime.Now, Deleted = false });
            Context.Provincia.Add(new Provincia { Name = "Provincia " + Guid.NewGuid().ToString(), LastModified = DateTime.Now, Deleted = false });

            Context.SaveChanges();
        }

        /// <summary>
        /// Finds All Provincia
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindAllProvincia()
        {
            await ProvinciaService.FindAllProvincia();

            Assert.Pass();
        }

        /// <summary>
        /// Finds Provincia By Id
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindProvinciaById()
        {
            await ProvinciaService.FindProvinciaById(Context.Provincia.FirstOrDefault().Id);

            Assert.Pass();
        }

        /// <summary>
        /// Removes Provincia By Id
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task RemoveProvinciaById()
        {
            await ProvinciaService.RemoveProvinciaById(Context.Provincia.FirstOrDefault().Id);

            Assert.Pass();
        }

        /// <summary>
        /// Updates Provincia
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task UpdateProvincia()
        {
            UpdateProvincia @provincia = new UpdateProvincia()
            {
                Id = Context.Provincia.FirstOrDefault().Id,
                ImageUri = "URL/Provincia_21_500px.png",
                Name = "Provincia 21"
            };

            await ProvinciaService.UpdateProvincia(@provincia);

            Assert.Pass();
        }

        /// <summary>
        /// Adds Provincia
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task AddProvincia()
        {
            AddProvincia @provincia = new AddProvincia()
            {
                ImageUri = "URL/Provincia_4_500px.png",
                Name = "Provincia 4"
            };

            await ProvinciaService.AddProvincia(@provincia);

            Assert.Pass();
        }

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public void CheckName()
        {
            AddProvincia @provincia = new AddProvincia()
            {
                ImageUri = "URL/Provincia_4_500px.png",
                Name = Context.Provincia.FirstOrDefault().Name
            };

            Exception exception = Assert.ThrowsAsync<Exception>(async () => await ProvinciaService.CheckName(@provincia));

            Assert.Pass();
        }
    }
}
