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
            cfg.RegisterServicesFromAssemblyContaining(typeof(AddArenalHandler));
            cfg.RegisterServicesFromAssemblyContaining(typeof(FindAllArenalHandler));
            cfg.RegisterServicesFromAssemblyContaining(typeof(FindAllHistoricoByArenalIdHandler));
            cfg.RegisterServicesFromAssemblyContaining(typeof(FindPaginatedArenalHandler));
            cfg.RegisterServicesFromAssemblyContaining(typeof(RemoveArenalByIdHandler));
            cfg.RegisterServicesFromAssemblyContaining(typeof(UpdateArenalHandler));

            cfg.RegisterServicesFromAssemblyContaining(typeof(AddBanderaHandler));
            cfg.RegisterServicesFromAssemblyContaining(typeof(FindAllBanderaHandler));
            cfg.RegisterServicesFromAssemblyContaining(typeof(FindAllHistoricoByBanderaIdHandler));
            cfg.RegisterServicesFromAssemblyContaining(typeof(FindPaginatedBanderaHandler));
            cfg.RegisterServicesFromAssemblyContaining(typeof(RemoveBanderaByIdHandler));
            cfg.RegisterServicesFromAssemblyContaining(typeof(UpdateBanderaHandler));

            cfg.RegisterServicesFromAssemblyContaining(typeof(FindAllArenalByBuscadorIdHandler));
            cfg.RegisterServicesFromAssemblyContaining(typeof(FindAllBuscadorHandler));

            cfg.RegisterServicesFromAssemblyContaining(typeof(AddPoblacionHandler));
            cfg.RegisterServicesFromAssemblyContaining(typeof(FindAllPoblacionHandler));
            cfg.RegisterServicesFromAssemblyContaining(typeof(FindPaginatedPoblacionHandler));
            cfg.RegisterServicesFromAssemblyContaining(typeof(RemovePoblacionByIdHandler));
            cfg.RegisterServicesFromAssemblyContaining(typeof(UpdatePoblacionHandler));

            cfg.RegisterServicesFromAssemblyContaining(typeof(AddProvinciaHandler));
            cfg.RegisterServicesFromAssemblyContaining(typeof(FindAllProvinciaHandler));
            cfg.RegisterServicesFromAssemblyContaining(typeof(FindPaginatedProvinciaHandler));
            cfg.RegisterServicesFromAssemblyContaining(typeof(RemoveProvinciaByIdHandler));
            cfg.RegisterServicesFromAssemblyContaining(typeof(UpdateProvinciaHandler));

            cfg.RegisterServicesFromAssemblyContaining(typeof(AddVientoHandler));
            cfg.RegisterServicesFromAssemblyContaining(typeof(FindAllVientoHandler));
            cfg.RegisterServicesFromAssemblyContaining(typeof(FindAllHistoricoByVientoIdHandler));
            cfg.RegisterServicesFromAssemblyContaining(typeof(FindPaginatedVientoHandler));
            cfg.RegisterServicesFromAssemblyContaining(typeof(RemoveVientoByIdHandler));
            cfg.RegisterServicesFromAssemblyContaining(typeof(UpdateVientoHandler));

            cfg.RegisterServicesFromAssemblyContaining(typeof(AddHistoricoHandler));
        });
    }
}