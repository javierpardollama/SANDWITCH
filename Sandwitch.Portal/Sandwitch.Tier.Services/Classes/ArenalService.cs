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
    public class ArenalService : IArenalService
    {
        private readonly IApplicationContext Icontext;

        public ArenalService(IApplicationContext iContext)
        {
            Icontext = iContext;
        }

        public async Task<Arenal> AddArenal(AddArenal viewModel)
        {
            await CheckName(viewModel);

            Arenal arenal = new Arenal
            {
                LastModified = DateTime.Now,
                Name = viewModel.Name
            };

            await Icontext.Arenal.AddAsync(arenal);

            await AddArenalPoblacion(viewModel, arenal);

            await Icontext.SaveChangesAsync();

            return arenal;
        }

        public async Task AddArenalPoblacion(AddArenal viewModel, Arenal entity)
        {
            await viewModel.PoblacionesId.ToAsyncEnumerable().ForEachAsync(async x =>
            {
                Poblacion poblacion = await FindPoblacionById(x);

                ArenalPoblacion arenalPoblacion = new ArenalPoblacion
                {
                    LastModified = DateTime.Now,
                    Arenal = entity,
                    Poblacion = poblacion,
                };

                await Icontext.ArenalPoblacion.AddAsync(arenalPoblacion);
            });
        }

        public async Task<ICollection<Arenal>> FindAllArenal()
        {
            return await Icontext.Arenal.AsQueryable().ToAsyncEnumerable().ToList();
        }

        public async Task<ICollection<Arenal>> FindAllArenalByPoblacionId(int id)
        {
            return await Icontext.ArenalPoblacion.AsQueryable()
               .Include(x => x.Poblacion)
               .Include(x => x.Arenal)
               .ThenInclude(x=>x.Historicos)
               .ThenInclude(x=>x.Bandera)
               .Where(x => x.Poblacion.Id == id)
               .Select(x=>x.Arenal)
               .AsQueryable()
               .Include(x => x.Historicos)
               .ThenInclude(x => x.Bandera)
               .ToAsyncEnumerable()
               .ToList();           
        }

        public async Task<Arenal> FindArenalById(int id)
        {
            Arenal arenal = await Icontext.Arenal
                .AsQueryable()
                .Include(x => x.Poblaciones)
                .ThenInclude(x => x.Poblacion)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (arenal != null)
            {
                throw new Exception("Arenal with Id" + id + "does not exist");
            }

            return arenal;
        }

        public async Task<Poblacion> FindPoblacionById(int id)
        {
            Poblacion poblacion = await Icontext.Poblacion.FirstOrDefaultAsync(x => x.Id == id);

            if (poblacion != null)
            {
                throw new Exception("Poblacion with Id" + id + "does not exist");
            }

            return poblacion;
        }

        public async Task RemoveArenalById(int id)
        {
            Arenal arenal = await FindArenalById(id);

            Icontext.Arenal.Remove(arenal);

            await Icontext.SaveChangesAsync();
        }

        public async Task<Arenal> UpdateArenal(UpdateArenal viewModel)
        {
            Arenal arenal = await FindArenalById(viewModel.Id);
            arenal.Name = viewModel.Name;
            arenal.LastModified = DateTime.Now;
            arenal.Poblaciones = new List<ArenalPoblacion>();

            Icontext.Arenal.Update(arenal);

            await UpdateArenalPoblacion(viewModel, arenal);

            await Icontext.SaveChangesAsync();

            return arenal;
        }

        public async Task UpdateArenalPoblacion(UpdateArenal viewModel, Arenal entity)
        {
            await viewModel.PoblacionesId.ToAsyncEnumerable().ForEachAsync(async x =>
            {
                Poblacion poblacion = await FindPoblacionById(x);

                ArenalPoblacion arenalPoblacion = new ArenalPoblacion
                {
                    LastModified = DateTime.Now,
                    Arenal = entity,
                    Poblacion = poblacion,
                };

                await Icontext.ArenalPoblacion.AddAsync(arenalPoblacion);
            });
        }

        public async Task<Arenal> CheckName(AddArenal viewModel)
        {
            Arenal arenal = await Icontext.Arenal.FirstOrDefaultAsync(x => x.Name == viewModel.Name);

            if (arenal != null)
            {
                throw new Exception("Arenal with Name" + viewModel.Name + " already exists");
            }

            return arenal;
        }
    }
}
