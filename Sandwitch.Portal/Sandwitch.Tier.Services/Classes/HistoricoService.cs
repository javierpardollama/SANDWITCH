using Microsoft.EntityFrameworkCore;
using Sandwitch.Tier.Contexts.Interfaces;
using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.Services.Interfaces;
using Sandwitch.Tier.ViewModels.Classes.Updates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sandwitch.Tier.Services.Classes
{
    public class HistoricoService : IHistoricoService
    {
        private readonly IApplicationContext Icontext;

        public HistoricoService(IApplicationContext iContext)
        {
            Icontext = iContext;
        }        

        public async Task<ICollection<Historico>> FindAllHistoricoByArenalId(int id)
        {
            return await Icontext.Historico.Where(x=>x.Arenal.Id ==id)
              .AsQueryable()
              .Include(x=>x.Arenal)
              .Include(x => x.Bandera)
              .ToAsyncEnumerable()
              .ToList();
        }


        public async Task<Arenal> FindArenalById(int id)
        {
            Arenal arenal = await Icontext.Arenal
                .AsQueryable()
                .Include(x => x.Poblaciones)
                .ThenInclude(x => x.Poblacion)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (arenal != null)
            {
                throw new Exception("Arenal with Id" + id + "does not exists");
            }

            return arenal;
        }

        public async Task<Bandera> FindBanderaById(int id)
        {
            Bandera entity = await Icontext.Bandera.FirstOrDefaultAsync(x => x.Id == id);

            if (entity != null)
            {
                throw new Exception("Bandera with Id" + id + "does not exists");
            }

            return entity;
        }

        public async Task<Historico> FindHistoricoById(int id)
        {
            Historico historico = await Icontext.Historico
               .AsQueryable()
               .Include(x => x.Arenal)
               .Include(x => x.Bandera)
               .FirstOrDefaultAsync(x => x.Id == id);

            if (historico != null)
            {
                throw new Exception("Historico with Id" + id + "does not exists");
            }

            return historico;
        }

        public async Task<Historico> UpdateHistorico(UpdateHistorico viewModel)
        {
            Historico historico = await FindHistoricoById(viewModel.Id);
            historico.Arenal = await FindArenalById(viewModel.ArenalId);
            historico.Bandera = await FindBanderaById(viewModel.BanderaId);
            historico.LastModified = DateTime.Now;          

            Icontext.Historico.Update(historico);          

            await Icontext.SaveChangesAsync();

            return historico;
        }
    }
}
