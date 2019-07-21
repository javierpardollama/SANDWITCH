using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sandwitch.Tier.Contexts.Interfaces;
using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.Exceptions.Classes;
using Sandwitch.Tier.Logging.Classes;
using Sandwitch.Tier.Services.Interfaces;
using Sandwitch.Tier.ViewModels.Classes.Additions;
using Sandwitch.Tier.ViewModels.Classes.Updates;
using Sandwitch.Tier.ViewModels.Classes.Views;

namespace Sandwitch.Tier.Services.Classes
{
    public class ArenalService : BaseService, IArenalService
    {
        public ArenalService(IApplicationContext iContext,
                             IMapper iMapper,
                             ILogger<ArenalService> iLogger) : base(iContext,
                                                                    iMapper,
                                                                    iLogger)
        {
        }

        public async Task<ViewArenal> AddArenal(AddArenal viewModel)
        {
            await CheckName(viewModel);

            Arenal arenal = new Arenal
            {
                Name = viewModel.Name
            };

            await IContext.Arenal.AddAsync(arenal);

            await AddArenalPoblacion(viewModel, arenal);

            await IContext.SaveChangesAsync();

            // Log
            string logData = arenal.GetType().ToString()
                + " with Id "
                + arenal.Id
                + " was added at "
                + DateTime.Now.ToShortTimeString();

            ILogger.WriteInsertItemLog(logData);

            return this.IMapper.Map<ViewArenal>(arenal); ;
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

                await IContext.ArenalPoblacion.AddAsync(arenalPoblacion);
            });
        }

        public async Task<ICollection<ViewArenal>> FindAllArenal()
        {
            ICollection<Arenal> arenales = await IContext.Arenal.AsQueryable()
                .Include(x => x.ArenalPoblaciones)
                .ThenInclude(x => x.Poblacion)
                .Include(x => x.Historicos)
                .ToAsyncEnumerable()
                .ToList();

            return this.IMapper.Map<ICollection<ViewArenal>>(arenales);
        }

        public async Task<ICollection<ViewArenal>> FindAllArenalByPoblacionId(int id)
        {
            ICollection<Arenal> arenales = await IContext.ArenalPoblacion
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

            return this.IMapper.Map<ICollection<ViewArenal>>(arenales);
        }

        public async Task<Arenal> FindArenalById(int id)
        {
            Arenal arenal = await IContext.Arenal
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

                ILogger.WriteGetItemNotFoundLog(logData);

                throw new ServiceException(arenal.GetType().Name
                    + " with Id "
                    + id
                    + " does not exist");
            }

            return arenal;
        }

        public async Task<Poblacion> FindPoblacionById(int id)
        {
            Poblacion poblacion = await IContext.Poblacion.FirstOrDefaultAsync(x => x.Id == id);

            if (poblacion == null)
            {
                // Log
                string logData = poblacion.GetType().Name
                    + " with Id "
                    + id
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                ILogger.WriteGetItemNotFoundLog(logData);

                throw new ServiceException(poblacion.GetType().Name
                    + " with Id "
                    + id
                    + " does not exist");
            }

            return poblacion;
        }

        public async Task RemoveArenalById(int id)
        {
            Arenal arenal = await FindArenalById(id);

            IContext.Arenal.Remove(arenal);

            await IContext.SaveChangesAsync();

            // Log
            string logData = arenal.GetType().Name
                + " with Id"
                + arenal.Id
                + " was removed at "
                + DateTime.Now.ToShortTimeString();

            ILogger.WriteDeleteItemLog(logData);
        }

        public async Task<ViewArenal> UpdateArenal(UpdateArenal viewModel)
        {
            Arenal arenal = await FindArenalById(viewModel.Id);
            arenal.Name = viewModel.Name;
            arenal.ArenalPoblaciones = new List<ArenalPoblacion>();

            IContext.Arenal.Update(arenal);

            await UpdateArenalPoblacion(viewModel, arenal);

            await IContext.SaveChangesAsync();

            // Log
            string logData = arenal.GetType().Name
                + " with Id"
                + arenal.Id
                + " was modified at "
                + DateTime.Now.ToShortTimeString();

            ILogger.WriteUpdateItemLog(logData);

            return this.IMapper.Map<ViewArenal>(arenal); ;
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

                await IContext.ArenalPoblacion.AddAsync(arenalPoblacion);
            });
        }

        public async Task<Arenal> CheckName(AddArenal viewModel)
        {
            Arenal arenal = await IContext.Arenal.FirstOrDefaultAsync(x => x.Name == viewModel.Name);

            if (arenal != null)
            {
                // Log
                string logData = arenal.GetType().Name
                    + " with Name "
                    + arenal.Name
                    + " was already found at "
                    + DateTime.Now.ToShortTimeString();

                ILogger.WriteGetItemFoundLog(logData);

                throw new ServiceException(arenal.GetType().Name
                    + " with Name "
                    + viewModel.Name
                    + " already exists");
            }

            return arenal;
        }
    }
}
