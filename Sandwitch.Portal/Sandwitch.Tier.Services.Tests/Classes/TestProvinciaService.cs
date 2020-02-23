using System;
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
    public class TestProvinciaService : TestBaseService
    {
        private ILogger<ProvinciaService> Logger;

        public TestProvinciaService()
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

            Logger = loggerFactory.CreateLogger<ProvinciaService>();
        }

        private void SetUpContext(ApplicationContext context)
        {
            context.Provincia.Add(new Provincia { Name = "Provincia 1", LastModified = DateTime.Now, Deleted = false });
            context.Provincia.Add(new Provincia { Name = "Provincia 2", LastModified = DateTime.Now, Deleted = false });
            context.Provincia.Add(new Provincia { Name = "Provincia 3", LastModified = DateTime.Now, Deleted = false });

            context.SaveChanges();
        }

        [Test]
        public async Task FindAllProvincia()
        {
            using (ApplicationContext context = new ApplicationContext(this.Options))
            {
                SetUpContext(context);

                ProvinciaService service = new ProvinciaService(context, Mapper, Logger);

                await service.FindAllProvincia();
            };

            Assert.Pass();
        }

        [Test]
        public async Task FindProvinciaById()
        {
            using (ApplicationContext context = new ApplicationContext(this.Options))
            {
                SetUpContext(context);

                ProvinciaService service = new ProvinciaService(context, Mapper, Logger);

                await service.FindProvinciaById(1);
            };

            Assert.Pass();
        }

        [Test]
        public async Task RemoveProvinciaById()
        {
            using (ApplicationContext context = new ApplicationContext(this.Options))
            {
                SetUpContext(context);

                ProvinciaService service = new ProvinciaService(context, Mapper, Logger);

                await service.RemoveProvinciaById(1);
            };

            Assert.Pass();
        }

        [Test]
        public async Task UpdateProvincia()
        {
            UpdateProvincia provincia = new UpdateProvincia()
            {
                Id = 2,
                ImageUri = "URL/Provincia_21_500px.png",
                Name = "Provincia 21"
            };

            using (ApplicationContext context = new ApplicationContext(this.Options))
            {
                SetUpContext(context);

                ProvinciaService service = new ProvinciaService(context, Mapper, Logger);

                await service.UpdateProvincia(provincia);
            };

            Assert.Pass();
        }

        [Test]
        public async Task AddProvincia()
        {
            AddProvincia provincia = new AddProvincia()
            {
                ImageUri = "URL/Provincia_4_500px.png",
                Name = "Provincia 4"
            };

            using (ApplicationContext context = new ApplicationContext(this.Options))
            {
                SetUpContext(context);

                ProvinciaService service = new ProvinciaService(context, Mapper, Logger);

                await service.AddProvincia(provincia);
            };

            Assert.Pass();
        }

        [Test]
        public void CheckName()
        {
            AddProvincia provincia = new AddProvincia()
            {
                ImageUri = "URL/Provincia_4_500px.png",
                Name = "Provincia 4"
            };

            using (ApplicationContext context = new ApplicationContext(this.Options))
            {
                SetUpContext(context);

                ProvinciaService service = new ProvinciaService(context, Mapper, Logger);

                Exception ex = Assert.ThrowsAsync<Exception>(async () => await service.CheckName(provincia));
            };

            Assert.Pass();
        }
    }
}
