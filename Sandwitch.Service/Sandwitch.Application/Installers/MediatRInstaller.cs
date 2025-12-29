using Microsoft.Extensions.DependencyInjection;
using Sandwitch.Application.Handlers.Beach;
using Sandwitch.Application.Handlers.Flag;
using Sandwitch.Application.Handlers.Finder;
using Sandwitch.Application.Handlers.Historic;
using Sandwitch.Application.Handlers.Town;
using Sandwitch.Application.Handlers.State;
using Sandwitch.Application.Handlers.Wind;

namespace Sandwitch.Application.Installers;

/// <summary>
///     Represents a <see cref="InstallMediatR" /> class.
/// </summary>
public static class MediatRInstaller
{
    /// <summary>
    ///     Installs MediatR
    /// </summary>
    /// <param name="this">Injected <see cref="IServiceCollection" /></param>
    public static void InstallMediatR(this IServiceCollection @this)
    {
        @this.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<AddBeachHandler>();
            cfg.RegisterServicesFromAssemblyContaining<FindAllBeachHandler>();
            cfg.RegisterServicesFromAssemblyContaining<FindAllHistoricByBeachIdHandler>();
            cfg.RegisterServicesFromAssemblyContaining<FindPaginatedBeachHandler>();
            cfg.RegisterServicesFromAssemblyContaining<RemoveBeachByIdHandler>();
            cfg.RegisterServicesFromAssemblyContaining<UpdateBeachHandler>();

            cfg.RegisterServicesFromAssemblyContaining<AddFlagHandler>();
            cfg.RegisterServicesFromAssemblyContaining<FindAllFlagHandler>();
            cfg.RegisterServicesFromAssemblyContaining<FindAllHistoricByFlagIdHandler>();
            cfg.RegisterServicesFromAssemblyContaining<FindPaginatedFlagHandler>();
            cfg.RegisterServicesFromAssemblyContaining<RemoveFlagByIdHandler>();
            cfg.RegisterServicesFromAssemblyContaining<UpdateFlagHandler>();

            cfg.RegisterServicesFromAssemblyContaining<FindAllBeachByFinderIdHandler>();
            cfg.RegisterServicesFromAssemblyContaining<FindAllFinderHandler>();

            cfg.RegisterServicesFromAssemblyContaining<AddTownHandler>();
            cfg.RegisterServicesFromAssemblyContaining<FindAllTownHandler>();
            cfg.RegisterServicesFromAssemblyContaining<FindPaginatedTownHandler>();
            cfg.RegisterServicesFromAssemblyContaining<RemoveTownByIdHandler>();
            cfg.RegisterServicesFromAssemblyContaining<UpdateTownHandler>();

            cfg.RegisterServicesFromAssemblyContaining<AddStateHandler>();
            cfg.RegisterServicesFromAssemblyContaining<FindAllStateHandler>();
            cfg.RegisterServicesFromAssemblyContaining<FindPaginatedStateHandler>();
            cfg.RegisterServicesFromAssemblyContaining<RemoveStateByIdHandler>();
            cfg.RegisterServicesFromAssemblyContaining<UpdateStateHandler>();

            cfg.RegisterServicesFromAssemblyContaining<AddWindHandler>();
            cfg.RegisterServicesFromAssemblyContaining<FindAllWindHandler>();
            cfg.RegisterServicesFromAssemblyContaining<FindAllHistoricByWindIdHandler>();
            cfg.RegisterServicesFromAssemblyContaining<FindPaginatedWindHandler>();
            cfg.RegisterServicesFromAssemblyContaining<RemoveWindByIdHandler>();
            cfg.RegisterServicesFromAssemblyContaining<UpdateWindHandler>();

            cfg.RegisterServicesFromAssemblyContaining<AddHistoricHandler>();
        });
    }
}