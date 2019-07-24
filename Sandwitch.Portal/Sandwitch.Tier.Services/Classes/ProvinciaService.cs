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
    public class ProvinciaService : BaseService, IProvinciaService
    {
        public ProvinciaService(IApplicationContext iContext,
                                IMapper iMapper,
                                ILogger<ProvinciaService> iLogger) : base(iContext,
                                                                          iMapper,
                                                                          iLogger)
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

            await IContext.Provincia.AddAsync(provincia);

            await IContext.SaveChangesAsync();

            // Log
            string logData = provincia.GetType().Name
                + " with Id "
                + provincia.Id
                + " was added at "
                + DateTime.Now.ToShortTimeString();

            ILogger.WriteInsertItemLog(logData);

            return IMapper.Map<ViewProvincia>(provincia);
        }

        public async Task<ICollection<ViewProvincia>> FindAllProvincia()
        {
            ICollection<Provincia> provincias = await IContext.Provincia
                .AsQueryable()
                .AsNoTracking()
                .Include(x => x.Poblaciones)
                .ToAsyncEnumerable()
                .ToList();

            return IMapper.Map<ICollection<ViewProvincia>>(provincias);
        }

        public async Task<Provincia> FindProvinciaById(int id)
        {
            Provincia provincia = await IContext.Provincia
                .FirstOrDefaultAsync(x => x.Id == id);

            if (provincia == null)
            {
                // Log
                string logData = provincia.GetType().Name
                    + " with Id "
                    + id
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                ILogger.WriteGetItemNotFoundLog(logData);

                throw new Exception(provincia.GetType().Name
                    + " with Id "
                    + id
                    + " does not exist");
            }

            return provincia;
        }

        public async Task RemoveProvinciaById(int id)
        {
            Provincia provincia = await FindProvinciaById(id);

            IContext.Provincia.Remove(provincia);

            await IContext.SaveChangesAsync();

            // Log
            string logData = provincia.GetType().Name
                + " with Id "
                + provincia.Id
                + " was removed at "
                + DateTime.Now.ToShortTimeString();

            ILogger.WriteDeleteItemLog(logData);
        }

        public async Task<ViewProvincia> UpdateProvincia(UpdateProvincia viewModel)
        {
            Provincia provincia = await FindProvinciaById(viewModel.Id);
            provincia.Name = viewModel.Name;
            provincia.ImageUri = viewModel.ImageUri;

            IContext.Provincia.Update(provincia);

            await IContext.SaveChangesAsync();

            // Log
            string logData = provincia.GetType().Name
                + " with Id "
                + provincia.Id
                + " was modified at "
                + DateTime.Now.ToShortTimeString();

            ILogger.WriteUpdateItemLog(logData);

            return IMapper.Map<ViewProvincia>(provincia);
        }

        public async Task<Provincia> CheckName(AddProvincia viewModel)
        {
            Provincia provincia = await IContext.Provincia.FirstOrDefaultAsync(x => x.Name == viewModel.Name);

            if (provincia != null)
            {
                // Log
                string logData = provincia.GetType().Name
                    + " with Name "
                    + provincia.Name
                    + " was already found at "
                    + DateTime.Now.ToShortTimeString();

                ILogger.WriteGetItemFoundLog(logData);

                throw new Exception(provincia.GetType().Name
                    + " with Name "
                    + viewModel.Name
                    + " already exists");
            }

            return provincia;
        }
    }
}
