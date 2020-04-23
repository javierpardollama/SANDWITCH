
using AutoMapper;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Sandwitch.Tier.Contexts.Classes;
using Sandwitch.Tier.Mappings.Classes;
using Sandwitch.Tier.Web.Extensions;

namespace Sandwitch.Tier.Web
{
    /// <summary>
    /// Represents a <see cref="Startup"/> class.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new Instance of<see cref="Startup"/>
        /// </summary>
        /// <param name="configuration">Injected <see cref="IConfiguration"/></param>
        public Startup(IConfiguration configuration) => Configuration = configuration;

        /// <summary>
        /// Gets <see cref="IConfiguration"/>
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Gets <see cref="MapperConfiguration"/>
        /// </summary>
        public MapperConfiguration MapperConfiguration { get; set; }

        /// <summary>
        /// Gets <see cref="IMapper"/>
        /// </summary>
        public IMapper Mapper { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// Configures Services
        /// </summary>
        /// <param name="services">Injected <see cref="IServiceCollection"/></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Add Entity Framework services to the services container.
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            MapperConfiguration = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ModelingProfile());
            });

            Mapper = MapperConfiguration.CreateMapper();

            // Add Mapping to the services container.
            services.AddSingleton(Mapper);

            // Register the service and implementation for the database context
            services.AddCustomizedContexts();

            // Register the Mvc services to the services container
            services.AddCustomizedServices();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
            .AddNewtonsoftJson(options =>
           {
               options.SerializerSettings.Formatting = Formatting.Indented;
               options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
               options.SerializerSettings.ContractResolver = new DefaultContractResolver();
           });

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// Configures
        /// </summary>
        /// <param name="app">Injected <see cref="IApplicationBuilder"/></param>
        /// <param name="env">Injected <see cref="IWebHostEnvironment"/></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCustomizedExceptionMiddlewares();
            }
            else
            {
                app.UseCustomizedExceptionMiddlewares();

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                }
            });
        }
    }
}
