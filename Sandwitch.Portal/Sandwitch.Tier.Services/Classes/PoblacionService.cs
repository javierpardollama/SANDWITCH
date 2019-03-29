using Microsoft.EntityFrameworkCore;
using Sandwitch.Tier.Contexts.Interfaces;
using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.Services.Interfaces;
using Sandwitch.Tier.ViewModels.Classes.Additions;
using Sandwitch.Tier.ViewModels.Classes.Updates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sandwitch.Tier.Services.Classes
{
    public class PoblacionService : IPoblacionService
    {
        private readonly IApplicationContext Icontext;

        public PoblacionService(IApplicationContext iContext)
        {
            Icontext = iContext;
        }

        public async Task<Poblacion> AddPoblacion(AddPoblacion viewModel)
        {
            await CheckName(viewModel);

            Poblacion entity = new Poblacion
            {
                LastModified = DateTime.Now,
                Name = viewModel.Name,
                Provincia = await FindProvinciaById(viewModel.ProvinciaId),
                ImageUri = viewModel.ImageUri
            };

            await Icontext.Poblacion.AddAsync(entity);

            await Icontext.SaveChangesAsync();

            return entity;
        }

        public async Task<ICollection<Poblacion>> FindAllPoblacion()
        {
            return await Icontext.Poblacion
                .AsQueryable()
                .Include(x => x.Provincia)
                .ToAsyncEnumerable()
                .ToList();
        }

        public async Task<ICollection<Poblacion>> FindAllPoblacionByProvinciaId(int id)
        {
            return await Icontext.Poblacion
              .AsQueryable()
              .Include(x => x.Provincia)
              .Where(x => x.Provincia.Id == id)
              .ToAsyncEnumerable()
              .ToList();
        }

        public async Task<Poblacion> FindPoblacionById(int id)
        {
            Poblacion entity = await Icontext.Poblacion.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception("Poblacion with Id" + id + "does not exist");
            }

            return entity;
        }

        public async Task<Provincia> FindProvinciaById(int id)
        {
            Provincia entity = await Icontext.Provincia.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception("Provincia with Id" + id + "does not exist");
            }

            return entity;
        }

        public async Task RemovePoblacionById(int id)
        {
            Poblacion entity = await FindPoblacionById(id);

            Icontext.Poblacion.Remove(entity);

            await Icontext.SaveChangesAsync();
        }

        public async Task<Poblacion> UpdatePoblacion(UpdatePoblacion viewModel)
        {
            Poblacion entity = await FindPoblacionById(viewModel.Id);
            entity.Name = viewModel.Name;
            entity.Provincia = await FindProvinciaById(viewModel.ProvinciaId);
            entity.ImageUri = viewModel.ImageUri;
            entity.LastModified = DateTime.Now;

            Icontext.Poblacion.Update(entity);

            await Icontext.SaveChangesAsync();

            return entity;
        }

        public async Task<Poblacion> CheckName(AddPoblacion viewModel)
        {
            Poblacion entity = await Icontext.Poblacion.FirstOrDefaultAsync(x => x.Name == viewModel.Name);

            if (entity != null)
            {
                throw new Exception("Poblacion " + viewModel.Name + "already exists");
            }

            return entity;
        }
    }
}
