using AutoMapper;
using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.ViewModels.Classes.Views;

namespace Sandwitch.Tier.Mappings.Classes
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Bandera, ViewBandera>();

            CreateMap<Historico, ViewHistorico>();

            CreateMap<Arenal, ViewArenal>();           
        }
    }
}
