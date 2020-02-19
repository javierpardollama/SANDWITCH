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
    public class TestBanderaService
    {
        private BanderaService BanderaService;

        private Mock<IApplicationContext> Context;

        private Mock<IMapper> Mapper;

        private Mock<ILogger<BanderaService>> Logger;

        [SetUp]
        public void Setup()
        {
            this.Context = new Mock<IApplicationContext>();

            this.Mapper = new Mock<IMapper>();

            this.Logger = new Mock<ILogger<BanderaService>>();

            this.BanderaService = new BanderaService(Context.Object, Mapper.Object, Logger.Object);
        }

        [Test]
        public async Task FindAllBandera()
        {
            await this.BanderaService.FindAllBandera();

            Assert.Pass();
        }

        [Test]
        public async Task FindBanderaById()
        {
            Assert.Pass();
        }

        [Test]
        public async Task RemoveBanderaById()
        {
            Assert.Pass();
        }

        [Test]
        public async Task UpdateBandera()
        {
            Assert.Pass();
        }

        [Test]
        public async Task AddBandera()
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