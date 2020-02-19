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
    public class TestArenalService
    {
        private ArenalService ArenalService;

        private Mock<IApplicationContext> Context;

        private Mock<IMapper> Mapper;

        private Mock<ILogger<ArenalService>> Logger;

        [SetUp]
        public void Setup()
        {
            this.Context = new Mock<IApplicationContext>();

            this.Mapper = new Mock<IMapper>();

            this.Logger = new Mock<ILogger<ArenalService>>();

            this.ArenalService = new ArenalService(Context.Object, Mapper.Object, Logger.Object);
        }

        [Test]
        public async Task FindAllArenal()
        {
            await this.ArenalService.FindAllArenal();

            Assert.Pass();
        }

        [Test]
        public async Task FindAllArenalByPoblacionId()
        {
            Assert.Pass();
        }

        [Test]
        public async Task FindArenalById()
        {
            Assert.Pass();
        }

        [Test]
        public async Task FindPoblacionById()
        {
            Assert.Pass();
        }

        [Test]
        public async Task FindBanderaById()
        {
            Assert.Pass();
        }

        [Test]
        public async Task RemoveArenalById()
        {
            Assert.Pass();
        }

        [Test]
        public async Task UpdateArenal()
        {
            Assert.Pass();
        }

        [Test]
        public async Task AddArenal()
        {
            Assert.Pass();
        }

        [Test]
        public async Task AddArenalPoblacion()
        {
            Assert.Pass();
        }

        [Test]
        public async Task AddHistorico()
        {
            Assert.Pass();
        }

        [Test]
        public async Task UpdateArenalPoblacion()
        {
            Assert.Pass();
        }

        [Test]
        public async Task UpdateHistorico()
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