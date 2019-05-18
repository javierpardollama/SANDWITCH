using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sandwitch.Tier.Contexts.Interfaces;
using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.Logging.Extensions;
using Sandwitch.Tier.Services.Interfaces;
using Sandwitch.Tier.ViewModels.Classes.Additions;
using Sandwitch.Tier.ViewModels.Classes.Views;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sandwitch.Tier.Services.Classes
{
    public class HistoricoService : BaseService, IHistoricoService
    {
        public HistoricoService(IApplicationContext iContext, IMapper iMapper, ILogger<HistoricoService> iLogger) : base(iContext, iMapper, iLogger)
        {
        }

        public async Task<Arenal> FindArenalById(int id)
        {
            Arenal arenal = await Icontext.Arenal
                .AsQueryable()
                .Include(x => x.Poblaciones)
                .ThenInclude(x => x.Poblacion)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (arenal == null)
            {
                // Log
                string logData = "Arenal with Id " + id + " was not Found on " + DateTime.Now.ToShortDateString();

                ILogger.WriteGetItemNotFoundLog(logData);

                throw new Exception("Arenal with Id " + id + " does not exist");
            }

            return arenal;
        }

        public async Task<Bandera> FindBanderaById(int id)
        {
            Bandera bandera = await Icontext.Bandera.FirstOrDefaultAsync(x => x.Id == id);

            if (bandera == null)
            {
                // Log
                string logData = "Bandera with Id " + id + " was not Found on " + DateTime.Now.ToShortDateString();

                ILogger.WriteGetItemNotFoundLog(logData);

                throw new Exception("Bandera with Id " + id + " does not exist");
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

            Icontext.Historico.Add(historico);

            await Icontext.SaveChangesAsync();

            // Log
            string logData = "Historico with Id " + historico.Id + " was Added on " + DateTime.Now.ToShortDateString();

            ILogger.WriteInsertItemLog(logData);

            return this.Imapper.Map<ViewHistorico>(historico);
        }       
    }
}
