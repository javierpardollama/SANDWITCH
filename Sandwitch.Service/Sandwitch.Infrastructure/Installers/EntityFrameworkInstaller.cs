using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sandwitch.Infrastructure.Contexts;
using Sandwitch.Infrastructure.Contexts.Interfaces;
using Sandwitch.Infrastructure.Interceptors;

namespace Sandwitch.Infrastructure.Installers;

/// <summary>
///     Represents a <see cref="EntityFrameworkInstaller" /> class.
/// </summary>
public static class EntityFrameworkInstaller
{
    /// <summary>
    ///     Installs Entity Framework
    /// </summary>
    /// <param name="this">Injected <see cref="IServiceCollection" /></param>
    /// <param name="configuration">Injected <see cref="IConfiguration" />></param>
    public static void InstallEntityFramework(this IServiceCollection @this, IConfiguration @configuration)
    {
        @this.AddDbContext<ApplicationContext>(options =>
        {
            options.AddInterceptors(new SoftDeleteInterceptor());
            options.UseSqlite(@configuration.GetConnectionString("DefaultConnection"));
        });

        @this.AddScoped<IApplicationContext, ApplicationContext>();
    }


    /// <summary>
    ///     Uses Migrations
    /// </summary>
    /// <param name="this">Injected <see cref="WebApplication" /></param>
    public static void UseMigrations(this WebApplication @this)
    {
        using var @scope = @this.Services.CreateScope();

        @scope.ServiceProvider.GetRequiredService<ApplicationContext>().Database.Migrate();

        // Add other services here
    }
}