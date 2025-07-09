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
        @this.AddTransient<IProvinciaManager, ProvinciaManager>();
        @this.AddTransient<IPoblacionManager, PoblacionManager>();
        @this.AddTransient<IVientoManager, VientoManager>();
        @this.AddTransient<IBanderaManager, BanderaManager>();
        @this.AddTransient<IArenalManager, ArenalManager>();
        @this.AddTransient<IHistoricoManager, HistoricoManager>();
        @this.AddTransient<IBuscadorManager, BuscadorManager>();

        @this.AddTransient<IAuthManager, AuthManager>();
        // Add other services here
    }
}