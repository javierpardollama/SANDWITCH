using AutoMapper;

using Microsoft.EntityFrameworkCore;

using Sandwitch.Tier.Contexts.Classes;
using Sandwitch.Tier.Mappings.Classes;

namespace Sandwitch.Tier.Services.Tests.Classes
{
    public class TestBaseService
    {
        public DbContextOptions<ApplicationContext> Options;

        public IMapper Mapper;

        public void SetUpMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ModelingProfile());
            });

            Mapper = config.CreateMapper();
        }

        public void SetUpOptions()
        {
            Options = new DbContextOptionsBuilder<ApplicationContext>()
           .UseInMemoryDatabase(databaseName: "Data Source=sandwitch.db")
           .Options;
        }
    }
}
