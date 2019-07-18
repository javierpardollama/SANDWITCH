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
    public class PoblacionService : BaseService, IPoblacionService
    {
        public PoblacionService(IApplicationContext iContext,
                                IMapper iMapper,
                                ILogger<PoblacionService> iLogger) : base(iContext, iMapper, iLogger)
        {
        }

        public async Task<ViewPoblacion> AddPoblacion(AddPoblacion viewModel)
        {
            await CheckName(viewModel);

            Poblacion poblacion = new Poblacion
            {
                Name = viewModel.Name,
                Provincia = await FindProvinciaById(viewModel.ProvinciaId),
                ImageUri = viewModel.ImageUri
            };

            await IContext.Poblacion.AddAsync(poblacion);

            await IContext.SaveChangesAsync();

            // Log
            string logData = poblacion.GetType().Name
                + " with Id "
                + poblacion.Id
                + " was added at "
                + DateTime.Now.ToShortTimeString();

            ILogger.WriteInsertItemLog(logData);

            return this.IMapper.Map<ViewPoblacion>(poblacion);
        }

        public async Task<ICollection<ViewPoblacion>> FindAllPoblacion()
        {
            ICollection<Poblacion> poblaciones = await IContext.Poblacion
                .AsQueryable()
                .AsNoTracking()
                .Include(x => x.Provincia)
                .ToAsyncEnumerable()
                .ToList();

            return this.IMapper.Map<ICollection<ViewPoblacion>>(poblaciones);
        }

        public async Task<ICollection<ViewPoblacion>> FindAllPoblacionByProvinciaId(int id)
        {
            ICollection<Poblacion> poblaciones = await IContext.Poblacion
              .AsQueryable()
              .AsNoTracking()
              .Include(x => x.Provincia)
              .Where(x => x.Provincia.Id == id)
              .ToAsyncEnumerable()
              .ToList();

            return this.IMapper.Map<ICollection<ViewPoblacion>>(poblaciones);
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

        public async Task<Provincia> FindProvinciaById(int id)
        {
            Provincia provincia = await IContext.Provincia.FirstOrDefaultAsync(x => x.Id == id);

            if (provincia == null)
            {
                // Log
                string logData = provincia.GetType().Name
                    + " with Id "
                    + id
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                ILogger.WriteGetItemNotFoundLog(logData);

                throw new ServiceException(provincia.GetType().Name
                    + " with Id "
                    + id
                    + " does not exist");
            }

            return provincia;
        }

        public async Task RemovePoblacionById(int id)
        {
            Poblacion poblacion = await FindPoblacionById(id);

            IContext.Poblacion.Remove(poblacion);

            await IContext.SaveChangesAsync();

            // Log
            string logData = poblacion.GetType().Name
                + " with Id "
                + poblacion.Id
                + " was removed at "
                + DateTime.Now.ToShortTimeString();

            ILogger.WriteDeleteItemLog(logData);
        }

        public async Task<ViewPoblacion> UpdatePoblacion(UpdatePoblacion viewModel)
        {
            Poblacion poblacion = await FindPoblacionById(viewModel.Id);
            poblacion.Name = viewModel.Name;
            poblacion.Provincia = await FindProvinciaById(viewModel.ProvinciaId);
            poblacion.ImageUri = viewModel.ImageUri;

            IContext.Poblacion.Update(poblacion);

            await IContext.SaveChangesAsync();

            // Log
            string logData = poblacion.GetType().Name
                + " with Id "
                + poblacion.Id
                + " was modified at "
                + DateTime.Now.ToShortTimeString();

            ILogger.WriteUpdateItemLog(logData);

            return this.IMapper.Map<ViewPoblacion>(poblacion);
        }

        public async Task<Poblacion> CheckName(AddPoblacion viewModel)
        {
            Poblacion poblacion = await IContext.Poblacion.FirstOrDefaultAsync(x => x.Name == viewModel.Name);

            if (poblacion != null)
            {
                // Log
                string logData = poblacion.GetType().Name
                    + " with Name "
                    + poblacion.Name
                    + " was already found at "
                    + DateTime.Now.ToShortTimeString();

                ILogger.WriteGetItemFoundLog(logData);

                throw new ServiceException(poblacion.GetType().Name
                    + " with Name "
                    + viewModel.Name
                    + " already exists");
            }

            return poblacion;
        }
    }
}
