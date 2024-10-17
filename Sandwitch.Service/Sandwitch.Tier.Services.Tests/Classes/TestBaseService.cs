using AutoMapper;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using Sandwitch.Tier.Contexts.Classes;
using Sandwitch.Tier.Contexts.Interceptors;
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
        /// Gets or Sets <see cref="IMapper"/>
        /// </summary>
        protected IMapper Mapper { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="IOptions{ApiSettings}"/>
        /// </summary>
        protected IOptions<ApiSettings> ApiOptions { get; set; } = Options.Create(new ApiSettings()
        {
            ApiLock = "Pauline",
            ApiKey = "T/R4J6eyvNG<6ne!"
        });

        /// <summary>
        /// Gets or Sets <see cref="ApplicationContext"/>
        /// </summary>
        protected ApplicationContext Context { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="DbContextOptionsBuilder{ApplicationContext}"/>
        /// </summary>
        protected DbContextOptionsBuilder<ApplicationContext> ContextOptionsBuilder { get; set; } = new DbContextOptionsBuilder<ApplicationContext>()
           .UseInMemoryDatabase("sandwitch.db")
           .AddInterceptors(new SoftDeleteInterceptor());

        /// <summary>
        /// Sets Up Context
        /// </summary>
        protected void SetUpContext()
        {
            Context = new ApplicationContext(ContextOptionsBuilder.Options);
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
    }
}
