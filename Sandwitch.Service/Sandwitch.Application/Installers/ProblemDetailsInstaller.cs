using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Sandwitch.Application.Handlers;

namespace Sandwitch.Application.Installers;

/// <summary>
///     Represents a <see cref="ProblemDetailsInstaller" /> class.
/// </summary>
public static class ProblemDetailsInstaller
{
    /// <summary>
    ///     Installs Problem Details
    /// </summary>
    /// <param name="this">Injected <see cref="IServiceCollection" /></param>
    public static void InstallProblemDetails(this IServiceCollection @this)
    {
        // Return the Problem Details format for non-successful responses
        @this.AddProblemDetails();
        @this.AddExceptionHandler<ProblemDetailsExceptionHandler>();
    }

    /// <summary>
    ///     Installs Problem Details
    /// </summary>
    /// <param name="this">Injected <see cref="WebApplication" /></param>
    public static void UseProblemDetails(this IApplicationBuilder @this)
    {
        @this.UseExceptionHandler();
        @this.UseStatusCodePages();
    }
}