using Microsoft.Extensions.DependencyInjection;
using Sandwitch.Application.Profiles;

namespace Sandwitch.Application.Installers;

/// <summary>
///     Represents a <see cref="AutoMapperInstaller" /> class.
/// </summary>
public static class AutoMapperInstaller
{
    /// <summary>
    ///     Installs AutoMapper
    /// </summary>
    /// <param name="this">Injected <see cref="IServiceCollection" /></param>
    public static void InstallAutoMapper(this IServiceCollection @this)
    {
        @this.AddAutoMapper(typeof(ModelingProfile).Assembly);
    }
}