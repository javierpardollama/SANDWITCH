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
        public ProvinciaService(IApplicationContext context,
                                IMapper mapper,
                                ILogger<ProvinciaService> logger) : base(context,
                                                                          mapper,
                                                                          logger)
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

            await Context.Provincia.AddAsync(provincia);

            await Context.SaveChangesAsync();

            // Log
            string logData = provincia.GetType().Name
                + " with Id "
                + provincia.Id
                + " was added at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteInsertItemLog(logData);

            return Mapper.Map<ViewProvincia>(provincia);
        }

        public async Task<IList<ViewProvincia>> FindAllProvincia()
        {
            IList<Provincia> provincias = await Context.Provincia
                .TagWith("FindAllProvincia")
                .AsQueryable()
                .AsNoTracking()
                .Include(x => x.Poblaciones)
                .ToListAsync();

            return Mapper.Map<IList<ViewProvincia>>(provincias);
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

        public async Task RemoveProvinciaById(int id)
        {
            Provincia provincia = await FindProvinciaById(id);

            Context.Provincia.Remove(provincia);

            await Context.SaveChangesAsync();

            // Log
            string logData = provincia.GetType().Name
                + " with Id "
                + provincia.Id
                + " was removed at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteDeleteItemLog(logData);
        }

        public async Task<ViewProvincia> UpdateProvincia(UpdateProvincia viewModel)
        {
            await CheckName(viewModel);

            Provincia provincia = await FindProvinciaById(viewModel.Id);
            provincia.Name = viewModel.Name;
            provincia.ImageUri = viewModel.ImageUri;

            Context.Provincia.Update(provincia);

            await Context.SaveChangesAsync();

            // Log
            string logData = provincia.GetType().Name
                + " with Id "
                + provincia.Id
                + " was modified at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteUpdateItemLog(logData);

            return Mapper.Map<ViewProvincia>(provincia);
        }

        public async Task<Provincia> CheckName(AddProvincia viewModel)
        {
            Provincia provincia = await Context.Provincia
                 .AsNoTracking()
                 .TagWith("CheckName")
                 .FirstOrDefaultAsync(x => x.Name == viewModel.Name);

            if (provincia != null)
            {
                // Log
                string logData = provincia.GetType().Name
                    + " with Name "
                    + provincia.Name
                    + " was already found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemFoundLog(logData);

                throw new Exception(provincia.GetType().Name
                    + " with Name "
                    + viewModel.Name
                    + " already exists");
            }

            return provincia;
        }

        public async Task<Provincia> CheckName(UpdateProvincia viewModel)
        {
            Provincia provincia = await Context.Provincia
                 .AsNoTracking()
                 .TagWith("CheckName")
                 .FirstOrDefaultAsync(x => x.Name == viewModel.Name && x.Id != viewModel.Id);

            if (provincia != null)
            {
                // Log
                string logData = provincia.GetType().Name
                    + " with Name "
                    + provincia.Name
                    + " was already found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemFoundLog(logData);

                throw new Exception(provincia.GetType().Name
                    + " with Name "
                    + viewModel.Name
                    + " already exists");
            }

            return provincia;
        }
    }
}
