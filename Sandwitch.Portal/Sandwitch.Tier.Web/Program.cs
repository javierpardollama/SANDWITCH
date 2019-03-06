using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sandwitch.Tier.Contexts.Classes;
using System;

namespace Sandwitch.Tier.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost webHost = CreateWebHostBuilder(args);

            try
            {
                ApplyWebHostMigrations(webHost.Services);
            }
            catch (Exception ex)
            {      
                
            }
        }

        public static IWebHost CreateWebHostBuilder(string[] args) =>
           WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .Build();

        public static void ApplyWebHostMigrations(IServiceProvider serviceProvider)
        {
            using (IServiceScope serviceScope = serviceProvider.CreateScope())
            {
                IServiceProvider scopeServiceProvider = serviceScope.ServiceProvider;

                ApplicationContext applicationContext = scopeServiceProvider.GetService<ApplicationContext>();

                applicationContext.Database.Migrate();
            }
        }       
    }
}
