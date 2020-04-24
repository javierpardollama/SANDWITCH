using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using NUnit.Framework;

using Sandwitch.Tier.Contexts.Classes;
using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.Services.Classes;
using Sandwitch.Tier.ViewModels.Classes.Additions;

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

            Logger = loggerFactory.CreateLogger<HistoricoService>();
        }

        /// <summary>
        /// Sets Up Context
        /// </summary>
        /// <param name="context">Injected <see cref="ApplicationContext"/></param>
        private void SetUpContext(ApplicationContext context)
        {
            context.Arenal.Add(new Arenal { Name = "Arenal 1", LastModified = DateTime.Now, Deleted = false });
            context.Poblacion.Add(new Poblacion { Name = "Poblacion 1", LastModified = DateTime.Now, Deleted = false });
            context.Bandera.Add(new Bandera { Name = "Poblacion 1", LastModified = DateTime.Now, Deleted = false });

            context.SaveChanges();
        }

        /// <summary>
        /// Finds Arenal By Id
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindArenalById()
        {
            using (ApplicationContext context = new ApplicationContext(this.Options))
            {
                SetUpContext(context);

                HistoricoService service = new HistoricoService(context, Mapper, Logger);

                await service.FindArenalById(context.Arenal.FirstOrDefault().Id);
            };

            Assert.Pass();
        }

        /// <summary>
        /// Finds Bandera By Id
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindBanderaById()
        {
            using (ApplicationContext context = new ApplicationContext(this.Options))
            {
                SetUpContext(context);

                HistoricoService service = new HistoricoService(context, Mapper, Logger);

                await service.FindBanderaById(context.Bandera.FirstOrDefault().Id);
            };

            Assert.Pass();
        }

        /// <summary>
        /// Adds Historico
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task AddHistorico()
        {
            using (ApplicationContext context = new ApplicationContext(this.Options))
            {
                SetUpContext(context);

                HistoricoService service = new HistoricoService(context, Mapper, Logger);

                AddHistorico historico = new AddHistorico()
                {
                    BanderaId = context.Bandera.FirstOrDefault().Id,
                    AltaMarAlba = DateTime.Now,
                    AltaMarOcaso = DateTime.Now,
                    ArenalId = context.Arenal.FirstOrDefault().Id,
                    BajaMarAlba = DateTime.Now,
                    BajaMarOcaso = DateTime.Now,
                    Temperatura = 20
                };


                await service.AddHistorico(historico);
            };

            Assert.Pass();
        }
    }
}
