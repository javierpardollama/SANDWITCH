﻿using Microsoft.Extensions.Logging;

using NUnit.Framework;

using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.Exceptions.Exceptions;
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
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            SetUpContext();

            SetUpMapper();

            SetUpLogger();

            SetUpData();

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
        /// Sets Up Data
        /// </summary>
        private void SetUpData()
        {
            Context.Provincia.Add(new Provincia { Name = "Provincia " + Guid.NewGuid().ToString(), ImageUri = "URL/Provincia_01_500px.png", LastModified = DateTime.Now, Deleted = false });
            Context.Provincia.Add(new Provincia { Name = "Provincia " + Guid.NewGuid().ToString(), ImageUri = "URL/Provincia_02_500px.png", LastModified = DateTime.Now, Deleted = false });
            Context.Provincia.Add(new Provincia { Name = "Provincia " + Guid.NewGuid().ToString(), ImageUri = "URL/Provincia_03_500px.png", LastModified = DateTime.Now, Deleted = false });

            Context.SaveChanges();
        }

        /// <summary>
        /// Tears Down
        /// </summary>
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Context.Provincia.RemoveRange(Context.Provincia.ToList());

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
        /// Finds Paginated Provincia
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindPaginatedProvincia()
        {
            await ProvinciaService.FindPaginatedProvincia(new FilterPage { Index = 1, Size = 5 });

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
            UpdateProvincia @Provincia = new()
            {
                Id = Context.Provincia.FirstOrDefault().Id,
                ImageUri = "URL/Provincia_21_500px.png",
                Name = "Provincia 21"
            };

            await ProvinciaService.UpdateProvincia(@Provincia);

            Assert.Pass();
        }

        /// <summary>
        /// Adds Provincia
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task AddProvincia()
        {
            AddProvincia @Provincia = new()
            {
                ImageUri = "URL/Provincia_4_500px.png",
                Name = "Provincia 4"
            };

            await ProvinciaService.AddProvincia(@Provincia);

            Assert.Pass();
        }

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public void CheckName()
        {
            AddProvincia @provincia = new()
            {
                ImageUri = "URL/Provincia_4_500px.png",
                Name = Context.Provincia.FirstOrDefault().Name
            };

            ServiceException exception = Assert.ThrowsAsync<ServiceException>(async () => await ProvinciaService.CheckName(@provincia));

            Assert.Pass();
        }
    }
}
