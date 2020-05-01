using System.Collections.Generic;

using AutoMapper;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Sandwitch.Tier.Contexts.Classes;
using Sandwitch.Tier.Contexts.Interfaces;
using Sandwitch.Tier.Mappings.Classes;

namespace Sandwitch.Tier.Services.Tests.Classes
{
    /// <summary>
    /// Represents a <see cref="TestBaseService"/> class.
    /// </summary>
    public class TestBaseService
    {
        /// <summary>
        /// Instance of <see cref="IApplicationContext"/>
        /// </summary>
        public IMapper Mapper;

        /// <summary>
        /// Instance of <see cref="IConfiguration"/>
        /// </summary>
        public IConfiguration Configuration;

        /// <summary>
        /// Instance of <see cref="ApplicationContext"/>
        /// </summary>
        public ApplicationContext Context;      

        /// <summary>
        /// Instance of <see cref="ServiceCollection"/>
        /// </summary>
        private ServiceCollection Services;

        /// <summary>
        /// Instance of <see cref="Dictionary{string, string}"/>
        /// </summary>
        private Dictionary<string, string> Settings;

        /// <summary>
        /// Instance of <see cref="DbContextOptions{ApplicationContext}"/>
        /// </summary>
        private DbContextOptions<ApplicationContext> Options;       

        /// <summary>
        /// Sets Up Services
        /// </summary>
        public void SetUpServices()
        {
            Services = new ServiceCollection();

            Services
                .AddSingleton(Configuration)
                .AddDbContext<ApplicationContext>(o => o.UseSqlite("Data Source=sandwitch.db"));

            Services.AddLogging();

            Context = new ApplicationContext(Options);
        }


        /// <summary>
        /// Sets Up Mapper
        /// </summary>
        public void SetUpMapper()
        {
            MapperConfiguration @config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ModelingProfile());
            });

            Mapper = @config.CreateMapper();
        }      

        /// <summary>
        /// Sets Settings
        /// </summary>
        public void SetUpSettings()
        {
            Settings = new Dictionary<string, string>()
            {
                {"ConnectionStrings:DefaultConnection","Data Source=sandwitch.db" }
            };
        }

        /// <summary>
        /// Sets Up Configuration
        /// </summary>
        public void SetUpConfiguration()
        {
            Configuration = new ConfigurationBuilder().AddInMemoryCollection(Settings).Build();
        }

        /// <summary>
        /// Sets Up Options
        /// </summary>
        public void SetUpOptions()
        {
            Options = new DbContextOptionsBuilder<ApplicationContext>()
           .UseInMemoryDatabase(databaseName: "Data Source=sandwitch.db")
           .Options;
        }
    }
}
