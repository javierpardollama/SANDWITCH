using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
    public class PoblacionService : BaseService, IPoblacionService
    {
        public PoblacionService(IApplicationContext iContext, IMapper iMapper, ILogger<PoblacionService> iLogger) : base(iContext, iMapper, iLogger)
        {
        }

        public async Task<ViewPoblacion> AddPoblacion(AddPoblacion viewModel)
        {
            await CheckName(viewModel);

            Poblacion entity = new Poblacion
            {              
                Name = viewModel.Name,
                Provincia = await FindProvinciaById(viewModel.ProvinciaId),
                ImageUri = viewModel.ImageUri
            };

            await Icontext.Poblacion.AddAsync(entity);

            await Icontext.SaveChangesAsync();

            // Log
            string logData = entity.GetType().ToString() + " with Id " + entity.Id + " was Added on " + DateTime.Now.ToShortDateString();

            WriteLog(logData);

            return this.Imapper.Map<ViewPoblacion>(entity);
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
            Poblacion entity = await Icontext.Poblacion.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                // Log
                string logData = entity.GetType().ToString() + " with Id " + id + " was not Found on " + DateTime.Now.ToShortDateString();

                WriteLog(logData);

                throw new Exception("Poblacion with Id " + id + " does not exist");
            }

            return entity;
        }

        public async Task<Provincia> FindProvinciaById(int id)
        {
            Provincia entity = await Icontext.Provincia.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                // Log
                string logData = entity.GetType().ToString() + " with Id " + id + " was not Found on " + DateTime.Now.ToShortDateString();

                WriteLog(logData);

                throw new Exception("Provincia with Id " + id + " does not exist");
            }

            return entity;
        }

        public async Task RemovePoblacionById(int id)
        {
            Poblacion entity = await FindPoblacionById(id);

            Icontext.Poblacion.Remove(entity);

            await Icontext.SaveChangesAsync();

            // Log
            string logData = entity.GetType().ToString() + " with Id " + entity.Id + " was Removed on " + DateTime.Now.ToShortDateString();

            WriteLog(logData);
        }

        public async Task<ViewPoblacion> UpdatePoblacion(UpdatePoblacion viewModel)
        {
            Poblacion entity = await FindPoblacionById(viewModel.Id);
            entity.Name = viewModel.Name;
            entity.Provincia = await FindProvinciaById(viewModel.ProvinciaId);
            entity.ImageUri = viewModel.ImageUri;          

            Icontext.Poblacion.Update(entity);

            await Icontext.SaveChangesAsync();

            // Log
            string logData = entity.GetType().ToString() + " with Id " + entity.Id + " was Modified on " + DateTime.Now.ToShortDateString();

            WriteLog(logData);

            return this.Imapper.Map<ViewPoblacion>(entity);
        }

        public async Task<Poblacion> CheckName(AddPoblacion viewModel)
        {
            Poblacion entity = await Icontext.Poblacion.FirstOrDefaultAsync(x => x.Name == viewModel.Name);

            if (entity != null)
            {
                // Log
                string logData = entity.GetType().ToString() + " with Name " + entity.Name + " was already Found on " + DateTime.Now.ToShortDateString();

                WriteLog(logData);

                throw new Exception("Poblacion with Name " + viewModel.Name + " already exists");
            }

            return entity;
        }       
    }
}
