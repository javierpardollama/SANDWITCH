using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using NUnit.Framework;

using Sandwitch.Tier.Contexts.Classes;
using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.Services.Classes;
using Sandwitch.Tier.ViewModels.Classes.Additions;

namespace Sandwitch.Tier.Services.Tests.Classes
{
    [TestFixture]
    public class TestHistoricoService : TestBaseService
    {
        private ILogger<HistoricoService> Logger;

        public TestHistoricoService()
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

            Logger = loggerFactory.CreateLogger<HistoricoService>();
        }

        private void SetUpContext(ApplicationContext context)
        {
            context.Arenal.Add(new Arenal { Name = "Arenal 1", LastModified = DateTime.Now, Deleted = false });
            context.Poblacion.Add(new Poblacion { Name = "Poblacion 1", LastModified = DateTime.Now, Deleted = false });
            context.Bandera.Add(new Bandera { Name = "Poblacion 1", LastModified = DateTime.Now, Deleted = false });

            context.SaveChanges();
        }

        [Test]
        public async Task FindArenalById()
        {
            using (ApplicationContext context = new ApplicationContext(this.Options))
            {
                SetUpContext(context);

                HistoricoService service = new HistoricoService(context, Mapper, Logger);

                await service.FindArenalById(1);
            };

            Assert.Pass();
        }

        [Test]
        public async Task FindBanderaById()
        {
            using (ApplicationContext context = new ApplicationContext(this.Options))
            {
                SetUpContext(context);

                HistoricoService service = new HistoricoService(context, Mapper, Logger);

                await service.FindBanderaById(1);
            };

            Assert.Pass();
        }

        [Test]
        public async Task AddHistorico()
        {
            AddHistorico historico = new AddHistorico()
            {
                BanderaId = 1,
                AltaMarAlba = DateTime.Now,
                AltaMarOcaso = DateTime.Now,
                ArenalId = 1,
                BajaMarAlba = DateTime.Now,
                BajaMarOcaso = DateTime.Now,
                Temperatura = 20
            };

            using (ApplicationContext context = new ApplicationContext(this.Options))
            {
                SetUpContext(context);

                HistoricoService service = new HistoricoService(context, Mapper, Logger);

                await service.AddHistorico(historico);
            };

            Assert.Pass();
        }
    }
}
