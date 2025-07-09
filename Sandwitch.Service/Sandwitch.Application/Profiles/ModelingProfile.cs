using AutoMapper;
using Sandwitch.Domain.Entities;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Profiles;

/// <summary>
///     Represents a <see cref="ModelingProfile" /> class. Inherits <see cref="Profile" />
/// </summary>
public class ModelingProfile : Profile
{
    /// <summary>
    ///     Initializes a new Instance of <see cref="ModelingProfile" />
    /// </summary>
    public ModelingProfile()
    {
        CreateMap<Bandera, ViewBandera>();

        CreateMap<Page<Bandera>, ViewPage<ViewBandera>>();

        CreateMap<Viento, ViewViento>();

        CreateMap<Page<Viento>, ViewPage<ViewViento>>();

        CreateMap<Provincia, ViewProvincia>();

        CreateMap<Page<Provincia>, ViewPage<ViewProvincia>>();

        CreateMap<Poblacion, ViewPoblacion>();

        CreateMap<Page<Poblacion>, ViewPage<ViewPoblacion>>();

        CreateMap<ArenalPoblacion, ViewArenalPoblacion>();

        CreateMap<Historico, ViewHistorico>();

        CreateMap<Arenal, ViewArenal>();

        CreateMap<Page<Arenal>, ViewPage<ViewArenal>>();

        CreateMap<Buscador, ViewBuscador>();
    }
}