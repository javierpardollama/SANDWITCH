using System.Threading.Tasks;

using AutoMapper;

using Microsoft.Extensions.Logging;

using Moq;

using NUnit.Framework;

using Sandwitch.Tier.Contexts.Interfaces;
using Sandwitch.Tier.Services.Classes;

namespace Sandwitch.Tier.Services.Tests.Classes
{
    [TestFixture]
    public class TestHistoricoService
    {
        private HistoricoService HistoricoService;

        private Mock<IApplicationContext> Context;

        private Mock<IMapper> Mapper;

        private Mock<ILogger<HistoricoService>> Logger;

        [SetUp]
        public void Setup()
        {
            this.Context = new Mock<IApplicationContext>();

            this.Mapper = new Mock<IMapper>();

            this.Logger = new Mock<ILogger<HistoricoService>>();

            this.HistoricoService = new HistoricoService(Context.Object, Mapper.Object, Logger.Object);
        }

        [Test]
        public async Task FindArenalById()
        {
            Assert.Pass();
        }

        [Test]
        public async Task FindBanderaById()
        {
            Assert.Pass();
        }

        [Test]
        public async Task AddHistorico()
        {
            Assert.Pass();
        }
    }
}