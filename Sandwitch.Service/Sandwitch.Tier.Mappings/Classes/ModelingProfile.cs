using AutoMapper;

using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.ViewModels.Classes.Views;

namespace Sandwitch.Tier.Mappings.Classes
{
    /// <summary>
    /// Represents a <see cref="ModelingProfile"/> class. Inherits <see cref="Profile"/>
    /// </summary>
    public class ModelingProfile : Profile
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="ModelingProfile"/>
        /// </summary>
        public ModelingProfile()
        {
            CreateMap<Bandera, ViewBandera>();

            CreateMap<Viento, ViewViento>();

            CreateMap<Provincia, ViewProvincia>();

            CreateMap<Poblacion, ViewPoblacion>();

            CreateMap<ArenalPoblacion, ViewArenalPoblacion>();

            CreateMap<Historico, ViewHistorico>();

            CreateMap<Arenal, ViewArenal>();
        }
    }
}
