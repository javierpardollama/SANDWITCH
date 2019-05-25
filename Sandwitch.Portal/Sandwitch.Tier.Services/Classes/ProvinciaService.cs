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
    public class ProvinciaService : BaseService, IProvinciaService
    {      
        public ProvinciaService(IApplicationContext iContext, IMapper iMapper, ILogger<ProvinciaService> iLogger) : base(iContext, iMapper, iLogger)
        {
        }

        public async Task<ViewProvincia> AddProvincia(AddProvincia viewModel)
        {
            await CheckName(viewModel);

            Provincia provincia = new Provincia
            {               
                Name = viewModel.Name,
                ImageUri = viewModel.ImageUri
            };

            await Icontext.Provincia.AddAsync(provincia);

            await Icontext.SaveChangesAsync();

            // Log
            string logData = provincia.GetType().Name + " with Id " + provincia.Id + " was added on " + DateTime.Now.ToShortDateString();

            ILogger.WriteInsertItemLog(logData);

            return this.Imapper.Map<ViewProvincia>(provincia);
        }

        public async Task<ICollection<ViewProvincia>> FindAllProvincia()
        {
            ICollection<Provincia> provincias = await Icontext.Provincia
                .AsQueryable()
                .Include(x=>x.Poblaciones)
                .ToAsyncEnumerable()
                .ToList();

            return this.Imapper.Map<ICollection<ViewProvincia>>(provincias);
        }

        public async Task<Provincia> FindProvinciaById(int id)
        {
            Provincia provincia = await Icontext.Provincia
                .FirstOrDefaultAsync(x => x.Id == id);

            if (provincia == null)
            {
                // Log
                string logData = provincia.GetType().Name + " with Id " + id + " was not found on " + DateTime.Now.ToShortDateString();

                ILogger.WriteGetItemNotFoundLog(logData);

                throw new Exception(provincia.GetType().Name + " with Id " + id + " does not exist");
            }

            return provincia;
        }

        public async Task RemoveProvinciaById(int id)
        {
            Provincia provincia = await FindProvinciaById(id);

            Icontext.Provincia.Remove(provincia);

            await Icontext.SaveChangesAsync();

            // Log
            string logData = provincia.GetType().Name + " with Id " + provincia.Id + " was removed on " + DateTime.Now.ToShortDateString();

            ILogger.WriteDeleteItemLog(logData);
        }

        public async Task<ViewProvincia> UpdateProvincia(UpdateProvincia viewModel)
        {
            Provincia provincia = await FindProvinciaById(viewModel.Id);
            provincia.Name = viewModel.Name;
            provincia.ImageUri = viewModel.ImageUri;

            Icontext.Provincia.Update(provincia);

            await Icontext.SaveChangesAsync();

            // Log
            string logData = provincia.GetType().Name + " with Id " + provincia.Id + " was modified on " + DateTime.Now.ToShortDateString();

            ILogger.WriteUpdateItemLog(logData);

            return this.Imapper.Map<ViewProvincia>(provincia);
        }

        public async Task<Provincia> CheckName(AddProvincia viewModel)
        {
            Provincia provincia = await Icontext.Provincia.FirstOrDefaultAsync(x => x.Name == viewModel.Name);

            if (provincia != null)
            {
                // Log
                string logData = provincia.GetType().Name + " with Name " + provincia.Name + " was already found on " + DateTime.Now.ToShortDateString();

                ILogger.WriteGetItemFoundLog(logData);

                throw new Exception(provincia.GetType().Name + " with Name " + viewModel.Name + " already exists");
            }

            return provincia;
        }       
    }
}
