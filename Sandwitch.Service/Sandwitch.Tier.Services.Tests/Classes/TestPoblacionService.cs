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
    /// Represents a <see cref="TestPoblacionService"/> class. Inherits <see cref="TestBaseService"/>
    /// </summary>
    [TestFixture]
    public class TestPoblacionService : TestBaseService
    {
        /// <summary>
        /// Instance of <see cref="ILogger{PoblacionService}"/>
        /// </summary>
        private ILogger<PoblacionService> Logger;

        /// <summary>
        /// Instance of <see cref="PoblacionService"/>
        /// </summary>
        private PoblacionService PoblacionService;


        /// <summary>
        /// Initializes a new Instance of <see cref="TestArenalService"/>
        /// </summary>
        public TestPoblacionService()
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

            PoblacionService = new PoblacionService(Context, Mapper, Logger);
        }

        /// <summary>
        /// Tears Down
        /// </summary>
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Context.Poblacion.RemoveRange(Context.Poblacion.ToList());

            Context.Provincia.RemoveRange(Context.Provincia.ToList());

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

            Logger = @loggerFactory.CreateLogger<PoblacionService>();
        }

        /// <summary>
        /// Sets Up Context
        /// </summary>
        private void SetUpContext()
        {
            Context.Provincia.Add(new Provincia { Name = "Provincia " + Guid.NewGuid().ToString(), ImageUri = "URL/Provincia_04_500px.png", LastModified = DateTime.Now, Deleted = false });

            Context.Poblacion.Add(new Poblacion { Name = "Poblacion " + Guid.NewGuid().ToString(), ImageUri = "URL/Poblacion_01_500px.png", LastModified = DateTime.Now, Deleted = false });
            Context.Poblacion.Add(new Poblacion { Name = "Poblacion " + Guid.NewGuid().ToString(), ImageUri = "URL/Poblacion_02_500px.png", LastModified = DateTime.Now, Deleted = false });
            Context.Poblacion.Add(new Poblacion { Name = "Poblacion " + Guid.NewGuid().ToString(), ImageUri = "URL/Poblacion_03_500px.png", LastModified = DateTime.Now, Deleted = false });

            Context.SaveChanges();
        }

        /// <summary>
        /// Finds All Poblacion
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindAllPoblacion()
        {
            await PoblacionService.FindAllPoblacion();

            Assert.Pass();
        }

        /// <summary>
        /// Finds Paginated Poblacion
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindPaginatedPoblacion()
        {
            await PoblacionService.FindPaginatedPoblacion(new FilterPage { Index = 1, Size = 5 });

            Assert.Pass();
        }

        /// <summary>
        /// Finds All Poblacion By Provincia Id
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindAllPoblacionByProvinciaId()
        {
            await PoblacionService.FindAllPoblacionByProvinciaId(Context.Provincia.FirstOrDefault().Id);

            Assert.Pass();
        }

        /// <summary>
        /// Finds Poblacion By Id
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindPoblacionById()
        {
            await PoblacionService.FindPoblacionById(Context.Poblacion.FirstOrDefault().Id);

            Assert.Pass();
        }

        /// <summary>
        /// Finds Provincia By Id
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindProvinciaById()
        {
            await PoblacionService.FindProvinciaById(Context.Provincia.FirstOrDefault().Id);

            Assert.Pass();
        }

        /// <summary>
        /// Removes Poblacion By Id
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task RemovePoblacionById()
        {
            await PoblacionService.RemovePoblacionById(Context.Poblacion.FirstOrDefault().Id);

            Assert.Pass();
        }

        /// <summary>
        /// Updates Poblacion
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task UpdatePoblacion()
        {
            UpdatePoblacion @Poblacion = new()
            {
                Id = Context.Poblacion.FirstOrDefault().Id,
                ImageUri = "URL/Poblacion_21_500px.png",
                Name = "Poblacion 21",
                ProvinciaId = Context.Provincia.FirstOrDefault().Id
            };

            await PoblacionService.UpdatePoblacion(@Poblacion);

            Assert.Pass();
        }

        /// <summary>
        /// Adds Poblacion
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task AddPoblacion()
        {
            AddPoblacion @Poblacion = new()
            {
                ImageUri = "URL/Poblacion_4_500px.png",
                Name = "Poblacion 4",
                ProvinciaId = Context.Provincia.FirstOrDefault().Id
            };

            await PoblacionService.AddPoblacion(@Poblacion);

            Assert.Pass();
        }

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public void CheckName()
        {
            AddPoblacion @Poblacion = new()
            {
                ImageUri = "URL/Poblacion_3_500px.png",
                Name = Context.Poblacion.FirstOrDefault().Name,
                ProvinciaId = Context.Provincia.FirstOrDefault().Id
            };

            Exception exception = Assert.ThrowsAsync<Exception>(async () => await PoblacionService.CheckName(@Poblacion));

            Assert.Pass();
        }
    }
}
