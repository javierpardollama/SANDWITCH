using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using NUnit.Framework;

using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.Services.Classes;
using Sandwitch.Tier.ViewModels.Classes.Additions;
using Sandwitch.Tier.ViewModels.Classes.Filters;
using Sandwitch.Tier.ViewModels.Classes.Updates;

namespace Sandwitch.Tier.Services.Tests.Classes
{
    /// <summary>
    /// Represents a <see cref="TestArenalService"/> class. Inherits <see cref="TestBaseService"/>
    /// </summary>
    [TestFixture]
    public class TestArenalService : TestBaseService
    {
        /// <summary>
        /// Instance of <see cref="ILogger{ProvinciaService}"/>
        /// </summary>
        private ILogger<ArenalService> Logger;

        /// <summary>
        /// Instance of <see cref="ArenalService"/>
        /// </summary>
        private ArenalService ArenalService;

        /// <summary>
        /// Initializes a new Instance of <see cref="TestArenalService"/>
        /// </summary>
        public TestArenalService()
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

            SetUpContext();

            ArenalService = new ArenalService(Context, Mapper, Logger);
        }

        /// <summary>
        /// Tears Down
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            Context.Arenal.RemoveRange(Context.Arenal.ToList());

            //Context.Bandera.RemoveRange(Context.Bandera.ToList());

            Context.Poblacion.RemoveRange(Context.Poblacion.ToList());

            Context.SaveChanges();
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

            Logger = @loggerFactory.CreateLogger<ArenalService>();
        }

        /// <summary>
        /// Sets Up Context
        /// </summary>
        private void SetUpContext()
        {
            Context.Poblacion.Add(new Poblacion { Name = "Poblacion " + Guid.NewGuid().ToString(), ImageUri = "Poblaciones/Poblacion_1_500.png", LastModified = DateTime.Now, Deleted = false });
            Context.Poblacion.Add(new Poblacion { Name = "Poblacion " + Guid.NewGuid().ToString(), ImageUri = "Poblaciones/Poblacion_2_500.png", LastModified = DateTime.Now, Deleted = false });

            Context.Bandera.Add(new Bandera { Name = "Bandera " + Guid.NewGuid().ToString(), ImageUri = "Banderas/Bandera_1_500.png", LastModified = DateTime.Now, Deleted = false });

            Context.Arenal.Add(new Arenal { Name = "Arenal " + Guid.NewGuid().ToString(), LastModified = DateTime.Now, Deleted = false });
            Context.Arenal.Add(new Arenal { Name = "Arenal " + Guid.NewGuid().ToString(), LastModified = DateTime.Now, Deleted = false });
            Context.Arenal.Add(new Arenal { Name = "Arenal " + Guid.NewGuid().ToString(), LastModified = DateTime.Now, Deleted = false });

            Context.SaveChanges();
        }

        /// <summary>
        /// Finds All Arenal
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindAllArenal()
        {
            await ArenalService.FindAllArenal();

            Assert.Pass();
        }

        /// <summary>
        /// Finds Paginated Arenal
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindPaginatedArenal()
        {
            await ArenalService.FindPaginatedArenal(new FilterPage { Index = 1, Size = 5 });

            Assert.Pass();
        }

        /// <summary>
        /// Finds All Arenal By Poblacion Id
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindAllArenalByPoblacionId()
        {
            await ArenalService.FindAllArenalByPoblacionId(1);

            Assert.Pass();
        }

        /// <summary>
        /// Finds All Historico By Arenal Id
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindAllHistoricoByArenalId()
        {
            await ArenalService.FindAllHistoricoByArenalId(Context.Arenal.FirstOrDefault().Id);

            Assert.Pass();
        }

        /// <summary>
        /// Finds Arenal By Id
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindArenalById()
        {
            await ArenalService.FindArenalById(Context.Arenal.FirstOrDefault().Id);

            Assert.Pass();
        }

        /// <summary>
        /// Finds Poblacion By Id
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindPoblacionById()
        {
            await ArenalService.FindPoblacionById(Context.Poblacion.FirstOrDefault().Id);

            Assert.Pass();
        }

        /// <summary>
        /// Finds Bandera By Id
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindBanderaById()
        {
            await ArenalService.FindBanderaById(Context.Bandera.FirstOrDefault().Id);

            Assert.Pass();
        }

        /// <summary>
        /// Removes Arenal By Id
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task RemoveArenalById()
        {
            await ArenalService.RemoveArenalById(Context.Arenal.FirstOrDefault().Id);

            Assert.Pass();
        }

        /// <summary>
        /// Updates Arenal
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task UpdateArenal()
        {
            UpdateArenal @Provincia = new()
            {
                Id = Context.Arenal.FirstOrDefault().Id,
                Name = "Arenal 21",
                PoblacionesId = new List<int>() { Context.Poblacion.FirstOrDefault().Id }
            };

            await ArenalService.UpdateArenal(@Provincia);

            Assert.Pass();
        }

        /// <summary>
        /// Adds Arenal
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task AddArenal()
        {
            AddArenal @Provincia = new()
            {
                Name = "Arenal 4",
                PoblacionesId = new List<int>() { 1, 2 },
            };

            await ArenalService.AddArenal(@Provincia);

            Assert.Pass();
        }

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public void CheckName()
        {
            AddArenal @Provincia = new()
            {
                PoblacionesId = new List<int>() { 1, 2 },
                Name = Context.Arenal.FirstOrDefault().Name
            };

            Exception exception = Assert.ThrowsAsync<Exception>(async () => await ArenalService.CheckName(@Provincia));

            Assert.Pass();
        }
    }
}
