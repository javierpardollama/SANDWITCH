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
    public class ProvinciaService : IProvinciaService
    {
        private readonly IApplicationContext Icontext;

        public ProvinciaService(IApplicationContext iContext)
        {
            Icontext = iContext;
        }

        public async Task<Provincia> AddProvincia(AddProvincia viewModel)
        {
            await CheckName(viewModel);

            Provincia entity = new Provincia
            {
                LastModified = DateTime.Now,
                Name = viewModel.Name
            };

            await Icontext.Provincia.AddAsync(entity);

            await Icontext.SaveChangesAsync();

            return entity;
        }

        public async Task<ICollection<Provincia>> FindAllProvincia()
        {
            return await Icontext.Provincia
                .AsQueryable()
                .ToAsyncEnumerable()
                .ToList();
        }

        public async Task<Provincia> FindProvinciaById(int id)
        {
            Provincia entity = await Icontext.Provincia
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity != null)
            {
                throw new Exception("Provincia with Id" + id + "does not exists");
            }

            return entity;
        }

        public async Task RemoveProvinciaById(int id)
        {
            Provincia entity = await FindProvinciaById(id);

            Icontext.Provincia.Remove(entity);

            await Icontext.SaveChangesAsync();
        }

        public async Task<Provincia> UpdateProvincia(UpdateProvincia viewModel)
        {
            Provincia entity = await FindProvinciaById(viewModel.Id);
            entity.Name = viewModel.Name;
            entity.LastModified = DateTime.Now;

            Icontext.Provincia.Update(entity);

            await Icontext.SaveChangesAsync();

            return entity;
        }

        public async Task<Provincia> CheckName(AddProvincia viewModel)
        {
            Provincia entity = await Icontext.Provincia.FirstOrDefaultAsync(x => x.Name == viewModel.Name);

            if (entity != null)
            {
                throw new Exception("Provincia with Name" + viewModel.Name + " already exists");
            }

            return entity;
        }
    }
}
