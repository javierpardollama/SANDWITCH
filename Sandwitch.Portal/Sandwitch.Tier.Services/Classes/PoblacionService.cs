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
    public class PoblacionService : BaseService, IPoblacionService
    {
        public PoblacionService(IApplicationContext context,
                                IMapper mapper,
                                ILogger<PoblacionService> logger) : base(context,
                                                                          mapper,
                                                                          logger)
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

            await Context.Poblacion.AddAsync(poblacion);

            await Context.SaveChangesAsync();

            // Log
            string logData = poblacion.GetType().Name
                + " with Id "
                + poblacion.Id
                + " was added at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteInsertItemLog(logData);

            return Mapper.Map<ViewPoblacion>(poblacion);
        }

        public async Task<IList<ViewPoblacion>> FindAllPoblacion()
        {
            IList<Poblacion> poblaciones = await Context.Poblacion
                .TagWith("FindAllPoblacion")
                .AsQueryable()
                .AsNoTracking()
                .Include(x => x.Provincia)
                .ToListAsync();

            return Mapper.Map<IList<ViewPoblacion>>(poblaciones);
        }

        public async Task<IList<ViewPoblacion>> FindAllPoblacionByProvinciaId(int id)
        {
            IList<Poblacion> poblaciones = await Context.Poblacion
              .TagWith("FindAllPoblacionByProvinciaId")
              .AsQueryable()
              .AsNoTracking()
              .Include(x => x.Provincia)
              .Where(x => x.Provincia.Id == id)
              .ToListAsync();

            return Mapper.Map<IList<ViewPoblacion>>(poblaciones);
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

        public async Task<Provincia> FindProvinciaById(int id)
        {
            Provincia provincia = await Context.Provincia
                 .TagWith("FindProvinciaById")
                 .FirstOrDefaultAsync(x => x.Id == id);

            if (provincia == null)
            {
                // Log
                string logData = provincia.GetType().Name
                    + " with Id "
                    + id
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemNotFoundLog(logData);

                throw new Exception(provincia.GetType().Name
                    + " with Id "
                    + id
                    + " does not exist");
            }

            return provincia;
        }

        public async Task RemovePoblacionById(int id)
        {
            Poblacion poblacion = await FindPoblacionById(id);

            Context.Poblacion.Remove(poblacion);

            await Context.SaveChangesAsync();

            // Log
            string logData = poblacion.GetType().Name
                + " with Id "
                + poblacion.Id
                + " was removed at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteDeleteItemLog(logData);
        }

        public async Task<ViewPoblacion> UpdatePoblacion(UpdatePoblacion viewModel)
        {
            await CheckName(viewModel);

            Poblacion poblacion = await FindPoblacionById(viewModel.Id);
            poblacion.Name = viewModel.Name;
            poblacion.Provincia = await FindProvinciaById(viewModel.ProvinciaId);
            poblacion.ImageUri = viewModel.ImageUri;

            Context.Poblacion.Update(poblacion);

            await Context.SaveChangesAsync();

            // Log
            string logData = poblacion.GetType().Name
                + " with Id "
                + poblacion.Id
                + " was modified at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteUpdateItemLog(logData);

            return Mapper.Map<ViewPoblacion>(poblacion);
        }

        public async Task<Poblacion> CheckName(AddPoblacion viewModel)
        {
            Poblacion poblacion = await Context.Poblacion
                 .AsNoTracking()
                 .TagWith("CheckName")
                 .FirstOrDefaultAsync(x => x.Name == viewModel.Name);

            if (poblacion != null)
            {
                // Log
                string logData = poblacion.GetType().Name
                    + " with Name "
                    + poblacion.Name
                    + " was already found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemFoundLog(logData);

                throw new Exception(poblacion.GetType().Name
                    + " with Name "
                    + viewModel.Name
                    + " already exists");
            }

            return poblacion;
        }

        public async Task<Poblacion> CheckName(UpdatePoblacion viewModel)
        {
            Poblacion poblacion = await Context.Poblacion
                 .AsNoTracking()
                 .TagWith("CheckName")
                 .FirstOrDefaultAsync(x => x.Name == viewModel.Name & x.Id != viewModel.Id);

            if (poblacion != null)
            {
                // Log
                string logData = poblacion.GetType().Name
                    + " with Name "
                    + poblacion.Name
                    + " was already found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemFoundLog(logData);

                throw new Exception(poblacion.GetType().Name
                    + " with Name "
                    + viewModel.Name
                    + " already exists");
            }

            return poblacion;
        }
    }
}
