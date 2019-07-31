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
    public class BanderaService : BaseService, IBanderaService
    {
        public BanderaService(IApplicationContext context,
                              IMapper mapper,
                              ILogger<BanderaService> logger) : base(context,
                                                                      mapper,
                                                                      logger)
        {
        }

        public async Task<ViewBandera> AddBandera(AddBandera viewModel)
        {
            await CheckName(viewModel);

            Bandera bandera = new Bandera
            {
                Name = viewModel.Name,
                ImageUri = viewModel.ImageUri
            };

            await Context.Bandera.AddAsync(bandera);

            await Context.SaveChangesAsync();

            // Log
            string logData = bandera.GetType().Name
                + " with Id "
                + bandera.Id
                + " was added at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteInsertItemLog(logData);

            return Mapper.Map<ViewBandera>(bandera);
        }

        public async Task<ICollection<ViewBandera>> FindAllBandera()
        {
            ICollection<Bandera> banderas = await Context.Bandera
                .TagWith("FindAllBandera")
                .AsQueryable()
                .AsNoTracking()
                .ToAsyncEnumerable()
                .ToList();

            return Mapper.Map<ICollection<ViewBandera>>(banderas);
        }

        public async Task<Bandera> FindBanderaById(int id)
        {
            Bandera bandera = await Context.Bandera
                 .TagWith("FindBanderaById")
                 .FirstOrDefaultAsync(x => x.Id == id);

            if (bandera == null)
            {
                // Log
                string logData = bandera.GetType().Name
                    + " with Id "
                    + id
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemNotFoundLog(logData);

                throw new Exception(bandera.GetType().Name
                    + " with Id "
                    + id
                    + " does not exist");
            }

            return bandera;
        }

        public async Task RemoveBanderaById(int id)
        {
            Bandera bandera = await FindBanderaById(id);

            Context.Bandera.Remove(bandera);

            await Context.SaveChangesAsync();

            // Log
            string logData = bandera.GetType().Name
                + " with Id "
                + bandera.Id
                + " was removed at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteDeleteItemLog(logData);
        }

        public async Task<ViewBandera> UpdateBandera(UpdateBandera viewModel)
        {
            await CheckName(viewModel);

            Bandera bandera = await FindBanderaById(viewModel.Id);
            bandera.Name = viewModel.Name;
            bandera.ImageUri = viewModel.ImageUri;

            Context.Bandera.Update(bandera);

            await Context.SaveChangesAsync();

            // Log
            string logData = bandera.GetType().Name
                + " with Id "
                + bandera.Id
                + " was modified at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteUpdateItemLog(logData);

            return Mapper.Map<ViewBandera>(bandera);
        }

        public async Task<Bandera> CheckName(AddBandera viewModel)
        {
            Bandera bandera = await Context.Bandera
                 .TagWith("CheckName")
                 .FirstOrDefaultAsync(x => x.Name == viewModel.Name);

            if (bandera != null)
            {
                // Log
                string logData = bandera.GetType().Name
                    + " with Name "
                    + bandera.Name
                    + " was already found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemFoundLog(logData);

                throw new Exception(bandera.GetType().Name
                    + " with Name "
                    + viewModel.Name
                    + " already exists");
            }

            return bandera;
        }

        public async Task<Bandera> CheckName(UpdateBandera viewModel)
        {
            Bandera bandera = await Context.Bandera
                 .TagWith("CheckName")
                 .FirstOrDefaultAsync(x => x.Name == viewModel.Name && x.Id != viewModel.Id);

            if (bandera != null)
            {
                // Log
                string logData = bandera.GetType().Name
                    + " with Name "
                    + bandera.Name
                    + " was already found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemFoundLog(logData);

                throw new Exception(bandera.GetType().Name
                    + " with Name "
                    + viewModel.Name
                    + " already exists");
            }

            return bandera;
        }
    }
}
