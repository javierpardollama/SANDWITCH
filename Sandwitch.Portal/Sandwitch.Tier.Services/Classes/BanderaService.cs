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
    public class BanderaService : BaseService, IBanderaService
    {
        public BanderaService(IApplicationContext iContext, IMapper iMapper, ILogger<BanderaService> iLogger) : base(iContext, iMapper, iLogger)
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

            await Icontext.Bandera.AddAsync(bandera);

            await Icontext.SaveChangesAsync();

            // Log
            string logData = bandera.GetType().Name + " with Id " + bandera.Id + " was added on " + DateTime.Now.ToShortDateString();

            ILogger.WriteInsertItemLog(logData);

            return this.Imapper.Map<ViewBandera>(bandera);
        }

        public async Task<ICollection<ViewBandera>> FindAllBandera()
        {
            ICollection<Bandera> banderas = await Icontext.Bandera
                .AsQueryable()
                .ToAsyncEnumerable()
                .ToList();

            return this.Imapper.Map<ICollection<ViewBandera>>(banderas);
        }

        public async Task<Bandera> FindBanderaById(int id)
        {
            Bandera bandera = await Icontext.Bandera.FirstOrDefaultAsync(x => x.Id == id);

            if (bandera == null)
            {
                // Log
                string logData = bandera.GetType().Name + " with Id " + id + " was not found on " + DateTime.Now.ToShortDateString();

                ILogger.WriteGetItemNotFoundLog(logData);

                throw new ServiceException(bandera.GetType().Name + " with Id " + id + " does not exist");
            }

            return bandera;
        }

        public async Task RemoveBanderaById(int id)
        {
            Bandera bandera = await FindBanderaById(id);

            Icontext.Bandera.Remove(bandera);

            await Icontext.SaveChangesAsync();

            // Log
            string logData = bandera.GetType().Name + " with Id " + bandera.Id + " was removed on " + DateTime.Now.ToShortDateString();

            ILogger.WriteDeleteItemLog(logData);
        }

        public async Task<ViewBandera> UpdateBandera(UpdateBandera viewModel)
        {
            Bandera bandera = await FindBanderaById(viewModel.Id);
            bandera.Name = viewModel.Name;
            bandera.ImageUri = viewModel.ImageUri;

            Icontext.Bandera.Update(bandera);

            await Icontext.SaveChangesAsync();

            // Log
            string logData = bandera.GetType().Name + " with Id " + bandera.Id + " was modified on " + DateTime.Now.ToShortDateString();

            ILogger.WriteUpdateItemLog(logData);

            return this.Imapper.Map<ViewBandera>(bandera);
        }

        public async Task<Bandera> CheckName(AddBandera viewModel)
        {
            Bandera bandera = await Icontext.Bandera.FirstOrDefaultAsync(x => x.Name == viewModel.Name);

            if (bandera != null)
            {
                // Log
                string logData = bandera.GetType().Name + " with Name " + bandera.Name + " was already Found on " + DateTime.Now.ToShortDateString();

                ILogger.WriteGetItemFoundLog(logData);

                throw new ServiceException(bandera.GetType().Name + " with Name " + viewModel.Name + " already exists");
            }

            return bandera;
        }
    }
}
