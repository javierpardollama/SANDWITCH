using System;
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
using Sandwitch.Tier.ViewModels.Classes.Views;

namespace Sandwitch.Tier.Services.Classes
{
    public class HistoricoService : BaseService, IHistoricoService
    {
        public HistoricoService(IApplicationContext context,
                                IMapper mapper,
                                ILogger<HistoricoService> logger) : base(context,
                                                                          mapper,
                                                                          logger)
        {
        }

        public async Task<Arenal> FindArenalById(int id)
        {
            Arenal arenal = await Context.Arenal
                .TagWith("FindArenalById")
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

                Logger.WriteGetItemNotFoundLog(logData);

                throw new Exception(arenal.GetType().Name
                    + " with Id "
                    + id
                    + " does not exist");
            }

            return arenal;
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

        public async Task<ViewHistorico> AddHistorico(AddHistorico viewModel)
        {
            Historico historico = new Historico
            {
                Arenal = await FindArenalById(viewModel.ArenalId),
                Bandera = await FindBanderaById(viewModel.BanderaId),
                BajaMarAlba = viewModel.BajaMarAlba,
                BajaMarOcaso = viewModel.BajaMarOcaso,
                AltaMarAlba = viewModel.AltaMarAlba,
                AltaMarOcaso = viewModel.AltaMarOcaso,
                Temperatura = viewModel.Temperatura,
            };

            Context.Historico.Add(historico);

            await Context.SaveChangesAsync();

            // Log
            string logData = historico.GetType().Name
                + " with Id "
                + historico.Id
                + " was added at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteInsertItemLog(logData);

            return Mapper.Map<ViewHistorico>(historico);
        }
    }
}
