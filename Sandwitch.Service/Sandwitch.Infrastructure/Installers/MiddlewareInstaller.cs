using Microsoft.AspNetCore.Builder;
using Sandwitch.Infrastructure.Middlewares;

namespace Sandwitch.Infrastructure.Installers;

/// <summary>
///     Represents a <see cref="MiddlewareInstaller" /> class.
/// </summary>
public static class MiddlewareInstaller
{
    /// <summary>
    ///     Uses Middlewares
    /// </summary>
    /// <param name="this">Injected <see cref="WebApplication" /></param>
    public static void UseMiddlewares(this WebApplication @this)
    {
        @this.UseMiddleware<HeaderMiddleware>();

        // Add other services here
    }
}