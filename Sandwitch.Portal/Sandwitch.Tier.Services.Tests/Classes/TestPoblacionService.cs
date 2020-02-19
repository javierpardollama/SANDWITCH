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
    public class TestPoblacionService
    {
        private PoblacionService PoblacionService;

        private Mock<IApplicationContext> Context;

        private Mock<IMapper> Mapper;

        private Mock<ILogger<PoblacionService>> Logger;

        [SetUp]
        public void Setup()
        {
            this.Context = new Mock<IApplicationContext>();

            this.Mapper = new Mock<IMapper>();

            this.Logger = new Mock<ILogger<PoblacionService>>();

            this.PoblacionService = new PoblacionService(Context.Object, Mapper.Object, Logger.Object);
        }

        [Test]
        public async Task FindAllPoblacion()
        {
            await this.PoblacionService.FindAllPoblacion();

            Assert.Pass();
        }

        [Test]
        public async Task FindAllPoblacionByProvinciaId()
        {
            Assert.Pass();
        }

        [Test]
        public async Task FindPoblacionById()
        {
            Assert.Pass();
        }

        [Test]
        public async Task FindProvinciaById()
        {
            Assert.Pass();
        }

        [Test]
        public async Task RemovePoblacionById()
        {
            Assert.Pass();
        }

        [Test]
        public async Task UpdatePoblacion()
        {
            Assert.Pass();
        }

        [Test]
        public async Task AddPoblacion()
        {
            Assert.Pass();
        }

        [Test]
        public async Task CheckName()
        {
            Assert.Pass();
        }
    }
}
