using Microsoft.Extensions.DependencyInjection;
using Sandwitch.Application.Handlers.Arenal;
using Sandwitch.Application.Handlers.Bandera;
using Sandwitch.Application.Handlers.Buscador;
using Sandwitch.Application.Handlers.Historico;
using Sandwitch.Application.Handlers.Poblacion;
using Sandwitch.Application.Handlers.Provincia;
using Sandwitch.Application.Handlers.Viento;

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
            cfg.RegisterServicesFromAssemblyContaining<AddArenalHandler>();
            cfg.RegisterServicesFromAssemblyContaining<FindAllArenalHandler>();
            cfg.RegisterServicesFromAssemblyContaining<FindAllHistoricoByArenalIdHandler>();
            cfg.RegisterServicesFromAssemblyContaining<FindPaginatedArenalHandler>();
            cfg.RegisterServicesFromAssemblyContaining<RemoveArenalByIdHandler>();
            cfg.RegisterServicesFromAssemblyContaining<UpdateArenalHandler>();

            cfg.RegisterServicesFromAssemblyContaining<AddBanderaHandler>();
            cfg.RegisterServicesFromAssemblyContaining<FindAllBanderaHandler>();
            cfg.RegisterServicesFromAssemblyContaining<FindAllHistoricoByBanderaIdHandler>();
            cfg.RegisterServicesFromAssemblyContaining<FindPaginatedBanderaHandler>();
            cfg.RegisterServicesFromAssemblyContaining<RemoveBanderaByIdHandler>();
            cfg.RegisterServicesFromAssemblyContaining<UpdateBanderaHandler>();

            cfg.RegisterServicesFromAssemblyContaining<FindAllArenalByBuscadorIdHandler>();
            cfg.RegisterServicesFromAssemblyContaining<FindAllBuscadorHandler>();

            cfg.RegisterServicesFromAssemblyContaining<AddPoblacionHandler>();
            cfg.RegisterServicesFromAssemblyContaining<FindAllPoblacionHandler>();
            cfg.RegisterServicesFromAssemblyContaining<FindPaginatedPoblacionHandler>();
            cfg.RegisterServicesFromAssemblyContaining<RemovePoblacionByIdHandler>();
            cfg.RegisterServicesFromAssemblyContaining<UpdatePoblacionHandler>();

            cfg.RegisterServicesFromAssemblyContaining<AddProvinciaHandler>();
            cfg.RegisterServicesFromAssemblyContaining<FindAllProvinciaHandler>();
            cfg.RegisterServicesFromAssemblyContaining<FindPaginatedProvinciaHandler>();
            cfg.RegisterServicesFromAssemblyContaining<RemoveProvinciaByIdHandler>();
            cfg.RegisterServicesFromAssemblyContaining<UpdateProvinciaHandler>();

            cfg.RegisterServicesFromAssemblyContaining<AddVientoHandler>();
            cfg.RegisterServicesFromAssemblyContaining<FindAllVientoHandler>();
            cfg.RegisterServicesFromAssemblyContaining<FindAllHistoricoByVientoIdHandler>();
            cfg.RegisterServicesFromAssemblyContaining<FindPaginatedVientoHandler>();
            cfg.RegisterServicesFromAssemblyContaining<RemoveVientoByIdHandler>();
            cfg.RegisterServicesFromAssemblyContaining<UpdateVientoHandler>();

            cfg.RegisterServicesFromAssemblyContaining<AddHistoricoHandler>();
        });
    }
}