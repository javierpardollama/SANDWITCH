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
    public class TestProvinciaService
    {
        private ProvinciaService ProvinciaService;

        private Mock<IApplicationContext> Context;

        private Mock<IMapper> Mapper;

        private Mock<ILogger<ProvinciaService>> Logger;

        [SetUp]
        public void Setup()
        {
            this.Context = new Mock<IApplicationContext>();

            this.Mapper = new Mock<IMapper>();

            this.Logger = new Mock<ILogger<ProvinciaService>>();

            this.ProvinciaService = new ProvinciaService(Context.Object, Mapper.Object, Logger.Object);
        }

        [Test]
        public async Task FindAllProvincia()
        {
            await this.ProvinciaService.FindAllProvincia();

            Assert.Pass();
        }

        [Test]
        public async Task FindProvinciaById()
        {
            Assert.Pass();
        }

        [Test]
        public async Task RemoveProvinciaById()
        {
            Assert.Pass();
        }

        [Test]
        public async Task UpdateProvincia()
        {
            Assert.Pass();
        }

        [Test]
        public async Task AddProvincia()
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
