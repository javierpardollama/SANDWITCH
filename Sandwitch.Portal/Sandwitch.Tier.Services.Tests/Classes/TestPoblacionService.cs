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
    [TestFixture]
    public class TestPoblacionService : TestBaseService
    {
        private ILogger<PoblacionService> Logger;

        public TestPoblacionService()
        {
            
        }

        [SetUp]
        public void Setup()
        {
            SetUpMapper();

            SetUpOptions();

            SetUpLogger();            
        }

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

        private void SetUpContext(ApplicationContext context)
        {
            context.Provincia.Add(new Provincia { Name = "Provincia 1", LastModified = DateTime.Now, Deleted = false });

            context.Poblacion.Add(new Poblacion { Name = "Poblacion 1", LastModified = DateTime.Now, Deleted = false });
            context.Poblacion.Add(new Poblacion { Name = "Poblacion 2", LastModified = DateTime.Now, Deleted = false });
            context.Poblacion.Add(new Poblacion { Name = "Poblacion 3", LastModified = DateTime.Now, Deleted = false });

            context.SaveChanges();
        }

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
