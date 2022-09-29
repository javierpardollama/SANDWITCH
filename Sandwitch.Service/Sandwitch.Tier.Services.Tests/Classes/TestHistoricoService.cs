
using Microsoft.Extensions.Logging;

using NUnit.Framework;

using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.Services.Classes;
using Sandwitch.Tier.ViewModels.Classes.Additions;

using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sandwitch.Tier.Services.Tests.Classes
{
    /// <summary>
    /// Represents a <see cref="TestHistoricoService"/> class. Inherits <see cref="TestBaseService"/>
    /// </summary>
    [TestFixture]
    public class TestHistoricoService : TestBaseService
    {
        /// <summary>
        /// Instance of <see cref="ILogger{HistoricoService}"/>
        /// </summary>
        private ILogger<HistoricoService> Logger;

        /// <summary>
        /// Instance of <see cref="HistoricoService"/>
        /// </summary>
        private HistoricoService HistoricoService;

        /// <summary>
        /// Initializes a new Instance of <see cref="TestArenalService"/>
        /// </summary>
        public TestHistoricoService()
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

            HistoricoService = new HistoricoService(Context, Mapper, Logger);
        }

        /// <summary>
        /// Tears Down
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            Context.Arenal.RemoveRange(Context.Arenal.ToList());

            Context.Bandera.RemoveRange(Context.Bandera.ToList());

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

            Logger = @loggerFactory.CreateLogger<HistoricoService>();
        }

        /// <summary>
        /// Sets Up Context
        /// </summary>
        private void SetUpContext()
        {
            Context.Arenal.Add(new Arenal { Name = "Arenal 1", LastModified = DateTime.Now, Deleted = false });
            Context.Poblacion.Add(new Poblacion { Name = "Poblacion 1", ImageUri = "URL/Poblacion_01_500px.png", LastModified = DateTime.Now, Deleted = false });
            Context.Bandera.Add(new Bandera { Name = "Bandera 1", ImageUri = "URL/Bandera_01_500px.png", LastModified = DateTime.Now, Deleted = false });

            Context.SaveChanges();
        }

        /// <summary>
        /// Finds Arenal By Id
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindArenalById()
        {
            await HistoricoService.FindArenalById(Context.Arenal.FirstOrDefault().Id);

            Assert.Pass();
        }

        /// <summary>
        /// Finds Bandera By Id
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindBanderaById()
        {
            await HistoricoService.FindBanderaById(Context.Bandera.FirstOrDefault().Id);

            Assert.Pass();
        }

        /// <summary>
        /// Adds Historico
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task AddHistorico()
        {
            AddHistorico @Historico = new()
            {
                BanderaId = Context.Bandera.FirstOrDefault().Id,
                AltaMarAlba = DateTime.Now.TimeOfDay,
                AltaMarOcaso = DateTime.Now.TimeOfDay,
                ArenalId = Context.Arenal.FirstOrDefault().Id,
                BajaMarAlba = DateTime.Now.TimeOfDay,
                BajaMarOcaso = DateTime.Now.TimeOfDay,
                Temperatura = 20
            };

            await HistoricoService.AddHistorico(@Historico);

            Assert.Pass();
        }
    }
}
