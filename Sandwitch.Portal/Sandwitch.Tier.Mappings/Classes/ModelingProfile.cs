﻿using AutoMapper;
using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.ViewModels.Classes.Views;

namespace Sandwitch.Tier.Mappings.Classes
{
    public class ModelingProfile : Profile
    {
        public ModelingProfile()
        {
            CreateMap<Bandera, ViewBandera>();

            CreateMap<Provincia, ViewProvincia>();

            CreateMap<Poblacion, ViewPoblacion>();

            CreateMap<ArenalPoblacion, ViewArenalPoblacion>();

            CreateMap<Historico, ViewHistorico>();

            CreateMap<Arenal, ViewArenal>();
        }
    }
}