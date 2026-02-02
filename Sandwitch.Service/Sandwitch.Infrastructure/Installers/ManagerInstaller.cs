using Microsoft.Extensions.DependencyInjection;
using Sandwitch.Domain.Managers;
using Sandwitch.Infrastructure.Managers;

namespace Sandwitch.Infrastructure.Installers;

/// <summary>
///     Represents a <see cref="ManagerInstaller" /> class.
/// </summary>
public static class ManagerInstaller
{
    /// <summary>
    ///     Installs Managers
    /// </summary>
    /// <param name="this">Injected <see cref="IServiceCollection" /></param>
    public static void InstallManagers(this IServiceCollection @this)
    {
        @this.AddTransient<IStateManager, StateManager>();
        @this.AddTransient<ITownManager, TownManager>();
        @this.AddTransient<IWindManager, WindManager>();
        @this.AddTransient<IFlagManager, FlagManager>();
        @this.AddTransient<IBeachManager, BeachManager>();
        @this.AddTransient<IHistoricManager, HistoricManager>();
        @this.AddTransient<IFinderManager, FinderManager>();

        @this.AddTransient<ICredentialManager, CredentialManager>();
        // Add other services here
    }
}