﻿using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Sandwitch.Tier.Contexts.Classes;

namespace Sandwitch.Tier.Service.Extensions
{
    /// <summary>
    /// Represents a <see cref="ApplicationExtension"/> class.
    /// </summary>
    public static class ApplicationExtension
    {
        /// <summary>
        /// Seeds Customized Contexts
        /// </summary>
        /// <param name="this">Injected <see cref="WebApplication"/></param>
        public static void UseMigrations(this WebApplication @this)
        {
            using var @scope = @this.Services.CreateScope();

            @scope.ServiceProvider.GetRequiredService<ApplicationContext>().Database.Migrate();

            // Add other services here
        }
    }
}
