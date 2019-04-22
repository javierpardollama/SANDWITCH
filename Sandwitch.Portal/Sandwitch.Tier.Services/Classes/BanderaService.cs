using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sandwitch.Tier.Contexts.Interfaces;
using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.Services.Interfaces;
using Sandwitch.Tier.ViewModels.Classes.Additions;
using Sandwitch.Tier.ViewModels.Classes.Updates;
using Sandwitch.Tier.ViewModels.Classes.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sandwitch.Tier.Services.Classes
{
    public class BanderaService : IBanderaService
    {
        private readonly IApplicationContext Icontext;

        private readonly IMapper Imapper;

        public BanderaService(IApplicationContext iContext, IMapper iMapper)
        {
            Icontext = iContext;
            Imapper = iMapper;
        }

        public async Task<ViewBandera> AddBandera(AddBandera viewModel)
        {
            await CheckName(viewModel);

            Bandera entity = new Bandera
            {
                LastModified = DateTime.Now,
                Name = viewModel.Name,
                ImageUri = viewModel.ImageUri
            };

            await Icontext.Bandera.AddAsync(entity);

            await Icontext.SaveChangesAsync();

            return this.Imapper.Map<ViewBandera>(entity);
        }

        public async Task<ICollection<ViewBandera>> FindAllBandera()
        {
            ICollection<Bandera> banderas = await Icontext.Bandera
                .AsQueryable()
                .ToAsyncEnumerable()
                .ToList();

            return this.Imapper.Map<ICollection<ViewBandera>>(banderas);
        }

        public async Task<Bandera> FindBanderaById(int id)
        {
            Bandera entity = await Icontext.Bandera.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception("Bandera with Id " + id + " does not exist");
            }

            return entity;
        }

        public async Task RemoveBanderaById(int id)
        {
            Bandera entity = await FindBanderaById(id);

            Icontext.Bandera.Remove(entity);

            await Icontext.SaveChangesAsync();
        }

        public async Task<ViewBandera> UpdateBandera(UpdateBandera viewModel)
        {
            Bandera entity = await FindBanderaById(viewModel.Id);
            entity.Name = viewModel.Name;
            entity.ImageUri = viewModel.ImageUri;
            entity.LastModified = DateTime.Now;

            Icontext.Bandera.Update(entity);

            await Icontext.SaveChangesAsync();

            return this.Imapper.Map<ViewBandera>(entity);
        }

        public async Task<Bandera> CheckName(AddBandera viewModel)
        {
            Bandera entity = await Icontext.Bandera.FirstOrDefaultAsync(x => x.Name == viewModel.Name);

            if (entity != null)
            {
                throw new Exception("Bandera with Name " + viewModel.Name + " already exists");
            }

            return entity;
        }
    }
}
