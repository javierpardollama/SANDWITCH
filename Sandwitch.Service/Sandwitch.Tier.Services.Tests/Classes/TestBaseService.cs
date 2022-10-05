using AutoMapper;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using Sandwitch.Tier.Contexts.Classes;
using Sandwitch.Tier.Mappings.Classes;
using Sandwitch.Tier.Settings.Classes;

namespace Sandwitch.Tier.Services.Tests.Classes
{
    /// <summary>
    /// Represents a <see cref="TestBaseService"/> class.
    /// </summary>
    public abstract class TestBaseService
    {
        /// <summary>
        /// Instance of <see cref="IMapper"/>
        /// </summary>
        protected IMapper Mapper;

        /// <summary>
        /// Instance of <see cref="IOptions{ApiSettings}"/>
        /// </summary>
        protected IOptions<ApiSettings> ApiOptions;

        /// <summary>
        /// Instance of <see cref="ApplicationContext"/>
        /// </summary>
        protected ApplicationContext Context;

        /// <summary>
        /// Instance of <see cref="ServiceCollection"/>
        /// </summary>
        protected ServiceCollection Services;

        /// <summary>
        /// Instance of <see cref="DbContextOptions{ApplicationContext}"/>
        /// </summary>
        protected DbContextOptions<ApplicationContext> ContextOptions;

        /// <summary>
        /// Sets Up Services
        /// </summary>
        protected void SetUpServices()
        {
            Services = new ServiceCollection();

            Services
                .AddDbContext<ApplicationContext>(o => o.UseSqlite("Data Source=sandwitch.db"));

            Services.AddLogging();

            Context = new ApplicationContext(ContextOptions);
        }


        /// <summary>
        /// Sets Up Mapper
        /// </summary>
        protected void SetUpMapper()
        {
            MapperConfiguration @config = new(cfg =>
            {
                cfg.AddProfile(new ModelingProfile());
            });

            Mapper = @config.CreateMapper();
        }

        /// <summary>
        /// Sets Up Api Options
        /// </summary>
        protected void SetUpApiOptions() => ApiOptions = Options.Create(new ApiSettings()
        {
           ApiLock = "Pauline",
           ApiKey = "T/R4J6eyvNG<6ne!"
        });

        /// <summary>
        /// Sets Up Context Options
        /// </summary>
        protected void SetUpContextOptions() => ContextOptions = new DbContextOptionsBuilder<ApplicationContext>()
           .UseInMemoryDatabase(databaseName: "Data Source=sandwitch.db")
           .Options;
    }
}
