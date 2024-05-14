using Microsoft.Extensions.Logging;

using NUnit.Framework;

using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.Services.Classes;
using Sandwitch.Tier.ViewModels.Classes.Additions;
using Sandwitch.Tier.ViewModels.Classes.Filters;
using Sandwitch.Tier.ViewModels.Classes.Updates;

using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sandwitch.Tier.Services.Tests.Classes
{
    /// <summary>
    /// Represents a <see cref="TestVientoService"/> class. Inherits <see cref="TestBaseService"/>
    /// </summary>
    [TestFixture]
    public class TestVientoService : TestBaseService
    {
        /// <summary>
        /// Instance of <see cref="ILogger{VientoService}"/>
        /// </summary>
        private ILogger<VientoService> Logger;

        /// <summary>
        /// Instance of <see cref="VientoService"/>
        /// </summary>
        private VientoService VientoService;

        /// <summary>
        /// Initializes a new Instance of <see cref="TestVientoService"/>
        /// </summary>
        public TestVientoService()
        {
        }

        /// <summary>
        /// Sets Up
        /// </summary>
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            SetUpContextOptions();

            SetUpApiOptions();

            SetUpServices();

            SetUpMapper();

            SetUpLogger();

            SetUpContext();

            VientoService = new VientoService(Context, Mapper, Logger);
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

            Logger = @loggerFactory.CreateLogger<VientoService>();
        }

        /// <summary>
        /// Sets Up Context
        /// </summary>
        private void SetUpContext()
        {
            Context.Viento.Add(new Viento { Name = "Viento " + Guid.NewGuid().ToString(), ImageUri = "Vientos/Viento_1_500.png", LastModified = DateTime.Now, Deleted = false });
            Context.Viento.Add(new Viento { Name = "Viento " + Guid.NewGuid().ToString(), ImageUri = "Vientos/Viento_2_500.png", LastModified = DateTime.Now, Deleted = false });
            Context.Viento.Add(new Viento { Name = "Viento " + Guid.NewGuid().ToString(), ImageUri = "Vientos/Viento_3_500.png", LastModified = DateTime.Now, Deleted = false });

            Context.SaveChanges();
        }

        /// <summary>
        /// Tears Down
        /// </summary>
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Context.SaveChanges();
        }

        /// <summary>
        /// Finds All Viento
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindAllViento()
        {
            await VientoService.FindAllViento();

            Assert.Pass();
        }

        /// <summary>
        /// Finds Paginated Viento
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindPaginatedViento()
        {
            await VientoService.FindPaginatedViento(new FilterPage { Index = 1, Size = 5 });

            Assert.Pass();
        }

        /// <summary>
        /// Finds All Historico By Viento Id
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindAllHistoricoByVientoId()
        {
            await VientoService.FindAllHistoricoByVientoId(Context.Viento.FirstOrDefault().Id);

            Assert.Pass();
        }

        /// <summary>
        /// Finds Viento By Id
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindVientoById()
        {
            await VientoService.FindVientoById(Context.Viento.FirstOrDefault().Id);

            Assert.Pass();
        }

        /// <summary>
        /// Removes Viento By Id
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task RemoveVientoById()
        {
            await VientoService.RemoveVientoById(Context.Viento.FirstOrDefault().Id);

            Assert.Pass();
        }

        /// <summary>
        /// Updates Viento
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task UpdateViento()
        {
            UpdateViento @Viento = new()
            {
                Id = Context.Viento.FirstOrDefault().Id,
                ImageUri = "URL/Viento_21_500px.png",
                Name = "Viento 21"
            };

            await VientoService.UpdateViento(@Viento);

            Assert.Pass();
        }

        /// <summary>
        /// Adds Viento
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task AddViento()
        {
            AddViento @Viento = new()
            {
                ImageUri = "URL/Viento_4_500px.png",
                Name = "Viento 4"
            };

            await VientoService.AddViento(@Viento);

            Assert.Pass();
        }

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public void CheckName()
        {
            AddViento @Viento = new()
            {
                ImageUri = "URL/Viento_3_500px.png",
                Name = Context.Viento.FirstOrDefault().Name
            };
            Exception exception = Assert.ThrowsAsync<Exception>(async () => await VientoService.CheckName(@Viento));

            Assert.Pass();
        }
    }
}
