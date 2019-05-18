using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sandwitch.Tier.Contexts.Interfaces;
using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.Logging.Extensions;
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
    public class ArenalService : BaseService, IArenalService
    {        
        public ArenalService(IApplicationContext iContext, IMapper iMapper, ILogger<ArenalService> iLogger) : base (iContext, iMapper, iLogger)
        {          
        }

        public async Task<ViewArenal> AddArenal(AddArenal viewModel)
        {
            await CheckName(viewModel);

            Arenal arenal = new Arenal
            {
                Name = viewModel.Name
            };

            await Icontext.Arenal.AddAsync(arenal);

            await AddArenalPoblacion(viewModel, arenal);

            await Icontext.SaveChangesAsync();

            // Log
            string logData = arenal.GetType().ToString() + " with Id " + arenal.Id + " was Added on " + DateTime.Now.ToShortDateString();

            ILogger.WriteInsertItemLog(logData);

            return this.Imapper.Map<ViewArenal>(arenal); ;
        }

        public async Task AddArenalPoblacion(AddArenal viewModel, Arenal entity)
        {
            await viewModel.PoblacionesId.ToAsyncEnumerable().ForEachAsync(async x =>
            {
                Poblacion poblacion = await FindPoblacionById(x);

                ArenalPoblacion arenalPoblacion = new ArenalPoblacion
                {
                    Arenal = entity,
                    Poblacion = poblacion,
                };

                await Icontext.ArenalPoblacion.AddAsync(arenalPoblacion);
            });
        }

        public async Task<ICollection<ViewArenal>> FindAllArenal()
        {
            ICollection<Arenal> arenales = await Icontext.Arenal.AsQueryable()
                .Include(x => x.Poblaciones)
                .ThenInclude(x => x.Poblacion)
                .Include(x => x.Historicos)
                .ToAsyncEnumerable().ToList();

            return this.Imapper.Map<ICollection<ViewArenal>>(arenales);
        }

        public async Task<ICollection<ViewArenal>> FindAllArenalByPoblacionId(int id)
        {
            ICollection<Arenal> arenales = await Icontext.ArenalPoblacion.AsQueryable()
               .Include(x => x.Poblacion)
               .Include(x => x.Arenal)
               .ThenInclude(x => x.Historicos)
               .ThenInclude(x => x.Bandera)
               .Where(x => x.Poblacion.Id == id)
               .Select(x => x.Arenal)
               .AsQueryable()
               .Include(x => x.Historicos)
               .ThenInclude(x => x.Bandera)
               .ToAsyncEnumerable()
               .ToList();

            return this.Imapper.Map<ICollection<ViewArenal>>(arenales);
        }

        public async Task<Arenal> FindArenalById(int id)
        {
            Arenal arenal = await Icontext.Arenal
                .AsQueryable()
                .Include(x => x.Poblaciones)
                .ThenInclude(x => x.Poblacion)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (arenal == null)
            {
                // Log
                string logData = arenal.GetType().ToString() + " with Id " + id + " was not Found on " + DateTime.Now.ToShortDateString();

                ILogger.WriteGetItemNotFoundLog(logData);

                throw new Exception("Arenal with Id " + id + " does not exist");
            }

            return arenal;
        }

        public async Task<Poblacion> FindPoblacionById(int id)
        {
            Poblacion poblacion = await Icontext.Poblacion.FirstOrDefaultAsync(x => x.Id == id);

            if (poblacion == null)
            {
                // Log
                string logData = "Poblacion with Id " + id + " was not Found on " + DateTime.Now.ToShortDateString();

                ILogger.WriteGetItemNotFoundLog(logData);

                throw new Exception("Poblacion with Id " + id + " does not exist");
            }

            return poblacion;
        }

        public async Task RemoveArenalById(int id)
        {
            Arenal arenal = await FindArenalById(id);

            Icontext.Arenal.Remove(arenal);

            await Icontext.SaveChangesAsync();

            // Log
            string logData = "Arenal with Id" + arenal.Id + " was Removed on " + DateTime.Now.ToShortDateString();

            ILogger.WriteDeleteItemLog(logData);
        }

        public async Task<ViewArenal> UpdateArenal(UpdateArenal viewModel)
        {
            Arenal arenal = await FindArenalById(viewModel.Id);
            arenal.Name = viewModel.Name;
            arenal.Poblaciones = new List<ArenalPoblacion>();

            Icontext.Arenal.Update(arenal);

            await UpdateArenalPoblacion(viewModel, arenal);

            await Icontext.SaveChangesAsync();

            // Log
            string logData = "Arenal with Id" + arenal.Id + " was Modified on " + DateTime.Now.ToShortDateString();

            ILogger.WriteUpdateItemLog(logData);

            return this.Imapper.Map<ViewArenal>(arenal); ;
        }

        public async Task UpdateArenalPoblacion(UpdateArenal viewModel, Arenal entity)
        {
            await viewModel.PoblacionesId.ToAsyncEnumerable().ForEachAsync(async x =>
            {
                Poblacion poblacion = await FindPoblacionById(x);

                ArenalPoblacion arenalPoblacion = new ArenalPoblacion
                {
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
                // Log
                string logData = "Arenal with Name " + arenal.Name + " was already Found on " + DateTime.Now.ToShortDateString();

                ILogger.WriteInsertItemAlreadyFoundLog(logData);

                throw new Exception("Arenal with Name " + viewModel.Name + " already exists");
            }

            return arenal;
        }        
    }
}
