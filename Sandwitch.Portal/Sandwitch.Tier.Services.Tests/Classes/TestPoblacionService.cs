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
        /// Initializes a new Instance of <see cref="TestArenalService"/>
        /// </summary>
        public TestPoblacionService()
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
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddConsole();
            });

            Logger = loggerFactory.CreateLogger<PoblacionService>();
        }

        /// <summary>
        /// Sets Up Context
        /// </summary>
        /// <param name="context">Injected <see cref="ApplicationContext"/></param>
        private void SetUpContext(ApplicationContext context)
        {
            context.Provincia.Add(new Provincia { Name = "Provincia 1", LastModified = DateTime.Now, Deleted = false });

            context.Poblacion.Add(new Poblacion { Name = "Poblacion 1", LastModified = DateTime.Now, Deleted = false });
            context.Poblacion.Add(new Poblacion { Name = "Poblacion 2", LastModified = DateTime.Now, Deleted = false });
            context.Poblacion.Add(new Poblacion { Name = "Poblacion 3", LastModified = DateTime.Now, Deleted = false });

            context.SaveChanges();
        }

        /// <summary>
        /// Finds All Poblacion
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindAllPoblacion()
        {
            using (ApplicationContext context = new ApplicationContext(this.Options))
            {
                SetUpContext(context);

                PoblacionService service = new PoblacionService(context, Mapper, Logger);

                await service.FindAllPoblacion();
            };

            Assert.Pass();
        }

        /// <summary>
        /// Finds All Poblacion By Provincia Id
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindAllPoblacionByProvinciaId()
        {
            using (ApplicationContext context = new ApplicationContext(this.Options))
            {
                SetUpContext(context);

                PoblacionService service = new PoblacionService(context, Mapper, Logger);

                await service.FindAllPoblacionByProvinciaId(context.Provincia.FirstOrDefault().Id);
            };

            Assert.Pass();
        }

        /// <summary>
        /// Finds Poblacion By Id
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindPoblacionById()
        {
            using (ApplicationContext context = new ApplicationContext(this.Options))
            {
                SetUpContext(context);

                PoblacionService service = new PoblacionService(context, Mapper, Logger);

                await service.FindPoblacionById(context.Poblacion.FirstOrDefault().Id);
            };

            Assert.Pass();
        }

        /// <summary>
        /// Finds Provincia By Id
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindProvinciaById() 
        {
            using (ApplicationContext context = new ApplicationContext(this.Options))
            {
                SetUpContext(context);

                PoblacionService service = new PoblacionService(context, Mapper, Logger);

                await service.FindProvinciaById(context.Provincia.FirstOrDefault().Id);
            };

            Assert.Pass();

        }

        /// <summary>
        /// Removes Poblacion By Id
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task RemovePoblacionById()
        {
            using (ApplicationContext context = new ApplicationContext(this.Options))
            {
                SetUpContext(context);

                PoblacionService service = new PoblacionService(context, Mapper, Logger);

                await service.RemovePoblacionById(context.Poblacion.FirstOrDefault().Id);
            };

            Assert.Pass();
        }

        /// <summary>
        /// Updates Poblacion
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task UpdatePoblacion()
        {
            UpdatePoblacion poblacion = new UpdatePoblacion()
            {
                Id = 2,
                ImageUri = "URL/Poblacion_21_500px.png",
                Name = "Poblacion 21",
                ProvinciaId = 1
            };

            using (ApplicationContext context = new ApplicationContext(this.Options))
            {
                SetUpContext(context);

                PoblacionService service = new PoblacionService(context, Mapper, Logger);

                await service.UpdatePoblacion(poblacion);
            };

            Assert.Pass();
        }

        /// <summary>
        /// Adds Poblacion
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task AddPoblacion()
        {
            AddPoblacion poblacion = new AddPoblacion()
            {
                ImageUri = "URL/Poblacion_4_500px.png",
                Name = "Poblacion 4",
                ProvinciaId = 1
            };

            using (ApplicationContext context = new ApplicationContext(this.Options))
            {
                SetUpContext(context);

                PoblacionService service = new PoblacionService(context, Mapper, Logger);

                await service.AddPoblacion(poblacion);
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
            AddPoblacion poblacion = new AddPoblacion()
            {
                ImageUri = "URL/Poblacion_4_500px.png",
                Name = "Poblacion 4"
            };

            using (ApplicationContext context = new ApplicationContext(this.Options))
            {
                SetUpContext(context);

                PoblacionService service = new PoblacionService(context, Mapper, Logger);

                Exception exception = Assert.ThrowsAsync<Exception>(async () => await service.CheckName(poblacion));
            };

            Assert.Pass();
        }
    }
}
