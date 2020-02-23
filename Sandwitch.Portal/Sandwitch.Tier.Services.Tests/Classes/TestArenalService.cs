using System;
using System.Collections.Generic;
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
    public class TestArenalService : TestBaseService
    {
        private ILogger<ArenalService> Logger;

        public TestArenalService()
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

            Logger = loggerFactory.CreateLogger<ArenalService>();
        }

        private void SetUpContext(ApplicationContext context)
        {
            context.Poblacion.Add(new Poblacion { Name = "Poblacion 1", LastModified = DateTime.Now, Deleted = false });
            context.Poblacion.Add(new Poblacion { Name = "Poblacion 2", LastModified = DateTime.Now, Deleted = false });

            context.Bandera.Add(new Bandera { Name = "Bandera 1", LastModified = DateTime.Now, Deleted = false });

            context.Arenal.Add(new Arenal { Name = "Arenal 1", LastModified = DateTime.Now, Deleted = false });
            context.Arenal.Add(new Arenal { Name = "Arenal 2", LastModified = DateTime.Now, Deleted = false });
            context.Arenal.Add(new Arenal { Name = "Arenal 3", LastModified = DateTime.Now, Deleted = false });

            context.SaveChanges();
        }

        [Test]
        public async Task FindAllArenal()
        {
            using (ApplicationContext context = new ApplicationContext(this.Options))
            {
                SetUpContext(context);

                ArenalService service = new ArenalService(context, Mapper, Logger);

                await service.FindAllArenal();
            };

            Assert.Pass();
        }

        [Test]
        public async Task FindArenalById()
        {
            using (ApplicationContext context = new ApplicationContext(this.Options))
            {
                SetUpContext(context);

                ArenalService service = new ArenalService(context, Mapper, Logger);

                await service.FindArenalById(context.Arenal.FirstOrDefault().Id);
            };

            Assert.Pass();
        }

        [Test]
        public async Task RemoveArenalById()
        {
            using (ApplicationContext context = new ApplicationContext(this.Options))
            {
                SetUpContext(context);

                ArenalService service = new ArenalService(context, Mapper, Logger);

                await service.RemoveArenalById(context.Arenal.FirstOrDefault().Id);
            };

            Assert.Pass();
        }

        [Test]
        public async Task UpdateArenal()
        {
            UpdateArenal provincia = new UpdateArenal()
            {
                Id = 2,
                Name = "Arenal 21",
                PoblacionesId = new List<int>() { 1,2}
            };

            using (ApplicationContext context = new ApplicationContext(this.Options))
            {
                SetUpContext(context);

                ArenalService service = new ArenalService(context, Mapper, Logger);

                await service.UpdateArenal(provincia);
            };

            Assert.Pass();
        }

        [Test]
        public async Task AddArenal()
        {
            AddArenal provincia = new AddArenal()
            {
                Name = "Arenal 4",
                PoblacionesId = new List<int>() { 1, 2 },
            };

            using (ApplicationContext context = new ApplicationContext(this.Options))
            {
                SetUpContext(context);

                ArenalService service = new ArenalService(context, Mapper, Logger);

                await service.AddArenal(provincia);
            };

            Assert.Pass();
        }

        [Test]
        public void CheckName()
        {
            AddArenal provincia = new AddArenal()
            {
                PoblacionesId = new List<int>() { 1, 2 },
                Name = "Arenal 4"
            };

            using (ApplicationContext context = new ApplicationContext(this.Options))
            {
                SetUpContext(context);

                ArenalService service = new ArenalService(context, Mapper, Logger);

                Exception exception = Assert.ThrowsAsync<Exception>(async () => await service.CheckName(provincia));
            };

            Assert.Pass();
        }
    }
}
