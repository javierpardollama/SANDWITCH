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

            Logger = @loggerFactory.CreateLogger<ProvinciaService>();
        }

        /// <summary>
        /// Sets Up Context
        /// </summary>
        /// <param name="context">Injected <see cref="ApplicationContext"/></param>
        private void SetUpContext(ApplicationContext @context)
        {
            @context.Provincia.Add(new Provincia { Name = "Provincia 1", LastModified = DateTime.Now, Deleted = false });
            @context.Provincia.Add(new Provincia { Name = "Provincia 2", LastModified = DateTime.Now, Deleted = false });
            @context.Provincia.Add(new Provincia { Name = "Provincia 3", LastModified = DateTime.Now, Deleted = false });

            @context.SaveChanges();
        }

        /// <summary>
        /// Finds All Provincia
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindAllProvincia()
        {
            using (ApplicationContext @context = new ApplicationContext(this.Options))
            {
                SetUpContext(@context);

                ProvinciaService @service = new ProvinciaService(@context, Mapper, Logger);

                await @service.FindAllProvincia();
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
            using (ApplicationContext @context = new ApplicationContext(this.Options))
            {
                SetUpContext(@context);

                ProvinciaService @service = new ProvinciaService(@context, Mapper, Logger);

                await @service.FindProvinciaById(@context.Provincia.FirstOrDefault().Id);
            };

            Assert.Pass();
        }

        /// <summary>
        /// Removes Provincia By Id
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task RemoveProvinciaById()
        {
            using (ApplicationContext @context = new ApplicationContext(this.Options))
            {
                SetUpContext(@context);

                ProvinciaService @service = new ProvinciaService(@context, Mapper, Logger);

                await @service.RemoveProvinciaById(@context.Provincia.FirstOrDefault().Id);
            };

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
                Id = 2,
                ImageUri = "URL/Provincia_21_500px.png",
                Name = "Provincia 21"
            };

            using (ApplicationContext @context = new ApplicationContext(this.Options))
            {
                SetUpContext(@context);

                ProvinciaService @service = new ProvinciaService(@context, Mapper, Logger);

                await @service.UpdateProvincia(@provincia);
            };

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

            using (ApplicationContext @context = new ApplicationContext(this.Options))
            {
                SetUpContext(@context);

                ProvinciaService @service = new ProvinciaService(@context, Mapper, Logger);

                await @service.AddProvincia(@provincia);
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
            AddProvincia @provincia = new AddProvincia()
            {
                ImageUri = "URL/Provincia_4_500px.png",
                Name = "Provincia 4"
            };

            using (ApplicationContext @context = new ApplicationContext(this.Options))
            {
                SetUpContext(@context);

                ProvinciaService @service = new ProvinciaService(@context, Mapper, Logger);

                Exception exception = Assert.ThrowsAsync<Exception>(async () => await @service.CheckName(@provincia));
            };

            Assert.Pass();
        }
    }
}
