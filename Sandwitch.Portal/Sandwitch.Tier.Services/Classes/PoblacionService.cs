using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sandwitch.Tier.Contexts.Interfaces;
using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.Exceptions.Classes;
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
    public class PoblacionService : BaseService, IPoblacionService
    {
        public PoblacionService(IApplicationContext iContext, IMapper iMapper, ILogger<PoblacionService> iLogger) : base(iContext, iMapper, iLogger)
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

            await Icontext.Poblacion.AddAsync(poblacion);

            await Icontext.SaveChangesAsync();

            // Log
            string logData = poblacion.GetType().Name + " with Id " + poblacion.Id + " was added on " + DateTime.Now.ToShortDateString();

            ILogger.WriteInsertItemLog(logData);

            return this.Imapper.Map<ViewPoblacion>(poblacion);
        }

        public async Task<ICollection<ViewPoblacion>> FindAllPoblacion()
        {
            ICollection<Poblacion> poblaciones = await Icontext.Poblacion
                .AsQueryable()
                .Include(x => x.Provincia)
                .ToAsyncEnumerable()
                .ToList();

            return this.Imapper.Map<ICollection<ViewPoblacion>>(poblaciones);
        }

        public async Task<ICollection<ViewPoblacion>> FindAllPoblacionByProvinciaId(int id)
        {
            ICollection<Poblacion> poblaciones = await Icontext.Poblacion
              .AsQueryable()
              .Include(x => x.Provincia)
              .Where(x => x.Provincia.Id == id)
              .ToAsyncEnumerable()
              .ToList();

            return this.Imapper.Map<ICollection<ViewPoblacion>>(poblaciones);
        }

        public async Task<Poblacion> FindPoblacionById(int id)
        {
            Poblacion poblacion = await Icontext.Poblacion.FirstOrDefaultAsync(x => x.Id == id);

            if (poblacion == null)
            {
                // Log
                string logData = poblacion.GetType().Name + " with Id " + id + " was not found on " + DateTime.Now.ToShortDateString();

                ILogger.WriteGetItemNotFoundLog(logData);

                throw new ServiceException(poblacion.GetType().Name + " with Id " + id + " does not exist");
            }

            return poblacion;
        }

        public async Task<Provincia> FindProvinciaById(int id)
        {
            Provincia provincia = await Icontext.Provincia.FirstOrDefaultAsync(x => x.Id == id);

            if (provincia == null)
            {
                // Log
                string logData = provincia.GetType().Name + " with Id " + id + " was not found on " + DateTime.Now.ToShortDateString();

                ILogger.WriteGetItemNotFoundLog(logData);

                throw new ServiceException(provincia.GetType().Name + " with Id " + id + " does not exist");
            }

            return provincia;
        }

        public async Task RemovePoblacionById(int id)
        {
            Poblacion poblacion = await FindPoblacionById(id);

            Icontext.Poblacion.Remove(poblacion);

            await Icontext.SaveChangesAsync();

            // Log
            string logData = poblacion.GetType().Name + " with Id " + poblacion.Id + " was removed on " + DateTime.Now.ToShortDateString();

            ILogger.WriteDeleteItemLog(logData);
        }

        public async Task<ViewPoblacion> UpdatePoblacion(UpdatePoblacion viewModel)
        {
            Poblacion poblacion = await FindPoblacionById(viewModel.Id);
            poblacion.Name = viewModel.Name;
            poblacion.Provincia = await FindProvinciaById(viewModel.ProvinciaId);
            poblacion.ImageUri = viewModel.ImageUri;          

            Icontext.Poblacion.Update(poblacion);

            await Icontext.SaveChangesAsync();

            // Log
            string logData = poblacion.GetType().Name + " with Id " + poblacion.Id + " was modified on " + DateTime.Now.ToShortDateString();

            ILogger.WriteUpdateItemLog(logData);

            return this.Imapper.Map<ViewPoblacion>(poblacion);
        }

        public async Task<Poblacion> CheckName(AddPoblacion viewModel)
        {
            Poblacion poblacion = await Icontext.Poblacion.FirstOrDefaultAsync(x => x.Name == viewModel.Name);

            if (poblacion != null)
            {
                // Log
                string logData = poblacion.GetType().Name + " with Name " + poblacion.Name + " was already found on " + DateTime.Now.ToShortDateString();

                ILogger.WriteGetItemFoundLog(logData);

                throw new ServiceException(poblacion.GetType().Name + " with Name " + viewModel.Name + " already exists");
            }

            return poblacion;
        }       
    }
}
