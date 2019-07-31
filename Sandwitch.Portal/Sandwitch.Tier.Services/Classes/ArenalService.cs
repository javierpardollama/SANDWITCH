using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using Sandwitch.Tier.Contexts.Interfaces;
using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.Logging.Classes;
using Sandwitch.Tier.Services.Interfaces;
using Sandwitch.Tier.ViewModels.Classes.Additions;
using Sandwitch.Tier.ViewModels.Classes.Updates;
using Sandwitch.Tier.ViewModels.Classes.Views;

namespace Sandwitch.Tier.Services.Classes
{
    public class ArenalService : BaseService, IArenalService
    {
        public ArenalService(IApplicationContext context,
                             IMapper mapper,
                             ILogger<ArenalService> logger) : base(context,
                                                                    mapper,
                                                                    logger)
        {
        }

        public async Task<ViewArenal> AddArenal(AddArenal viewModel)
        {
            await CheckName(viewModel);

            Arenal arenal = new Arenal
            {
                Name = viewModel.Name
            };

            await Context.Arenal.AddAsync(arenal);

            await AddArenalPoblacion(viewModel, arenal);

            await Context.SaveChangesAsync();

            // Log
            string logData = arenal.GetType().ToString()
                + " with Id "
                + arenal.Id
                + " was added at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteInsertItemLog(logData);

            return Mapper.Map<ViewArenal>(arenal); ;
        }

        public async Task AddArenalPoblacion(AddArenal viewModel,
                                             Arenal entity)
        {
            await viewModel.PoblacionesId.ToAsyncEnumerable().ForEachAsync(async x =>
            {
                Poblacion poblacion = await FindPoblacionById(x);

                ArenalPoblacion arenalPoblacion = new ArenalPoblacion
                {
                    Arenal = entity,
                    Poblacion = poblacion,
                };

                await Context.ArenalPoblacion.AddAsync(arenalPoblacion);
            });
        }

        public async Task<ICollection<ViewArenal>> FindAllArenal()
        {
            ICollection<Arenal> arenales = await Context.Arenal
                .TagWith("FindAllArenal")
                .AsQueryable()
                .Include(x => x.ArenalPoblaciones)
                .ThenInclude(x => x.Poblacion)
                .Include(x => x.Historicos)
                .ToAsyncEnumerable()
                .ToList();

            return Mapper.Map<ICollection<ViewArenal>>(arenales);
        }

        public async Task<ICollection<ViewArenal>> FindAllArenalByPoblacionId(int id)
        {
            ICollection<Arenal> arenales = await Context.ArenalPoblacion
               .TagWith("FindAllArenalByPoblacionId")
               .AsQueryable()
               .AsNoTracking()
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

            return Mapper.Map<ICollection<ViewArenal>>(arenales);
        }

        public async Task<Arenal> FindArenalById(int id)
        {
            Arenal arenal = await Context.Arenal
                .TagWith("FindArenalById")
                .AsQueryable()
                .Include(x => x.ArenalPoblaciones)
                .ThenInclude(x => x.Poblacion)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (arenal == null)
            {
                // Log
                string logData = arenal.GetType().Name
                    + " with Id "
                    + id
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemNotFoundLog(logData);

                throw new Exception(arenal.GetType().Name
                    + " with Id "
                    + id
                    + " does not exist");
            }

            return arenal;
        }

        public async Task<Poblacion> FindPoblacionById(int id)
        {
            Poblacion poblacion = await Context.Poblacion
                 .TagWith("FindPoblacionById")
                 .FirstOrDefaultAsync(x => x.Id == id);

            if (poblacion == null)
            {
                // Log
                string logData = poblacion.GetType().Name
                    + " with Id "
                    + id
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemNotFoundLog(logData);

                throw new Exception(poblacion.GetType().Name
                    + " with Id "
                    + id
                    + " does not exist");
            }

            return poblacion;
        }

        public async Task RemoveArenalById(int id)
        {
            Arenal arenal = await FindArenalById(id);

            Context.Arenal.Remove(arenal);

            await Context.SaveChangesAsync();

            // Log
            string logData = arenal.GetType().Name
                + " with Id"
                + arenal.Id
                + " was removed at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteDeleteItemLog(logData);
        }

        public async Task<ViewArenal> UpdateArenal(UpdateArenal viewModel)
        {
            Arenal arenal = await FindArenalById(viewModel.Id);
            arenal.Name = viewModel.Name;
            arenal.ArenalPoblaciones = new List<ArenalPoblacion>();

            Context.Arenal.Update(arenal);

            await UpdateArenalPoblacion(viewModel, arenal);

            await Context.SaveChangesAsync();

            // Log
            string logData = arenal.GetType().Name
                + " with Id"
                + arenal.Id
                + " was modified at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteUpdateItemLog(logData);

            return Mapper.Map<ViewArenal>(arenal); ;
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

                await Context.ArenalPoblacion.AddAsync(arenalPoblacion);
            });
        }

        public async Task<Arenal> CheckName(AddArenal viewModel)
        {
            Arenal arenal = await Context.Arenal
                 .TagWith("CheckName")
                 .FirstOrDefaultAsync(x => x.Name == viewModel.Name);

            if (arenal != null)
            {
                // Log
                string logData = arenal.GetType().Name
                    + " with Name "
                    + arenal.Name
                    + " was already found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemFoundLog(logData);

                throw new Exception(arenal.GetType().Name
                    + " with Name "
                    + viewModel.Name
                    + " already exists");
            }

            return arenal;
        }
    }
}
