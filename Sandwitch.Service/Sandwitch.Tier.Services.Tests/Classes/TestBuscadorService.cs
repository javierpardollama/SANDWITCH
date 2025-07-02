
using Microsoft.Extensions.Logging;

using NUnit.Framework;

using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.Services.Classes;
using Sandwitch.Tier.ViewModels.Classes.Filters;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sandwitch.Tier.Services.Tests.Classes
{
    /// <summary>
    /// Represents a <see cref="TestBuscadorService"/> class. Inherits <see cref="TestBaseService"/>
    /// </summary>
    [TestFixture]
    public class TestBuscadorService : TestBaseService
    {
        /// <summary>
        /// Instance of <see cref="ILogger{BuscadorService}"/>
        /// </summary>
        private ILogger<BuscadorService> Logger;

        /// <summary>
        /// Instance of <see cref="BuscadorService"/>
        /// </summary>
        private BuscadorService BuscadorService;

        /// <summary>
        /// Initializes a new Instance of <see cref="TestBuscadorService"/>
        /// </summary>
        public TestBuscadorService()
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

            BuscadorService = new BuscadorService(Context, Mapper, Logger);
        }

        /// <summary>
        /// Tears Down
        /// </summary>
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Context.Arenal.RemoveRange(Context.Arenal.ToList());
           
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

            Logger = @loggerFactory.CreateLogger<BuscadorService>();
        }

        /// <summary>
        /// Sets Up Data
        /// </summary>
        private void SetUpData()
        {
            Context.Poblacion.Add(new Poblacion { Name = "Poblacion " + Guid.NewGuid().ToString(), ImageUri = "Poblaciones/Poblacion_1_500.png", LastModified = DateTime.Now, Deleted = false });
            Context.Poblacion.Add(new Poblacion { Name = "Poblacion " + Guid.NewGuid().ToString(), ImageUri = "Poblaciones/Poblacion_2_500.png", LastModified = DateTime.Now, Deleted = false });
          
            Context.Arenal.Add(new Arenal { Name = "Arenal " + Guid.NewGuid().ToString(), LastModified = DateTime.Now, Deleted = false });
            Context.Arenal.Add(new Arenal { Name = "Arenal " + Guid.NewGuid().ToString(), LastModified = DateTime.Now, Deleted = false });
           
            Context.SaveChanges();
        }

        
        /// <summary>
        /// Finds All Buscador
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindAllBuscador()
        {
            await BuscadorService.FindAllBuscador();

            Assert.Pass();
        }

        /// <summary>
        /// Finds All Arenal By Buscador Id
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindAllArenalByBuscadorId()
        {
            await BuscadorService.FindAllArenalByBuscadorId(new FilterBuscador() { Id = Context.Poblacion.FirstOrDefault().Id, Type = nameof(Poblacion) });

            Assert.Pass();
        }
    }
}