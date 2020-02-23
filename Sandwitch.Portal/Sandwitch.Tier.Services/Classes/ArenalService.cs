using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using Sandwitch.Tier.Constants.Enums;
using Sandwitch.Tier.Contexts.Interfaces;
using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.Logging.Classes;
using Sandwitch.Tier.Services.Interfaces;
using Sandwitch.Tier.ViewModels.Classes.Additions;
using Sandwitch.Tier.ViewModels.Classes.Updates;
using Sandwitch.Tier.ViewModels.Classes.Views;

namespace Sandwitch.Tier.Services.Classes
{
    public class ArenalService : BaseService, IArenalService
    {
        public ArenalService(IApplicationContext context,
                             IMapper mapper,
                             ILogger<ArenalService> logger) : base(context,
                                                                    mapper,
                                                                    logger)
        {
        }

        public async Task<ViewArenal> AddArenal(AddArenal viewModel)
        {
            await CheckName(viewModel);

            Arenal arenal = new Arenal
            {
                Name = viewModel.Name,
                ArenalPoblaciones = new List<ArenalPoblacion>(),
                Historicos = new List<Historico>()
            };

            try
            {
                await Context.Arenal.AddAsync(arenal);

                AddArenalPoblacion(viewModel, arenal);

                await AddHistorico(arenal);

                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                await CheckName(viewModel);
            }

            // Log
            string logData = arenal.GetType().ToString()
                + " with Id "
                + arenal.Id
                + " was added at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteInsertItemLog(logData);

            return Mapper.Map<ViewArenal>(arenal); ;
        }

        public void AddArenalPoblacion(AddArenal viewModel,
                                             Arenal entity)
        {
            viewModel.PoblacionesId.AsQueryable().ToList().ForEach(async x =>
            {
                Poblacion poblacion = await FindPoblacionById(x);

                ArenalPoblacion arenalPoblacion = new ArenalPoblacion
                {
                    Arenal = entity,
                    Poblacion = poblacion,
                };

                entity.ArenalPoblaciones.Add(arenalPoblacion);
            });
        }

        public async Task AddHistorico(Arenal entity)
        {
            Historico historico = new Historico
            {
                Arenal = entity,
                Bandera = await FindBanderaById((int)FlagIdentifiers.Amarilla),
                BajaMarAlba = DateTime.Now,
                BajaMarOcaso = DateTime.Now,
                AltaMarAlba = DateTime.Now,
                AltaMarOcaso = DateTime.Now,
                Temperatura = 20,
            };
            entity.Historicos.Add(historico);
        }

        public async Task<IList<ViewArenal>> FindAllArenal()
        {
            ICollection<Arenal> arenales = await Context.Arenal
                .TagWith("FindAllArenal")
                .AsQueryable()
                .AsNoTracking()
                .Include(x => x.ArenalPoblaciones)
                .ThenInclude(x => x.Poblacion)
                .Include(x => x.Historicos)
                .ToListAsync();

            return Mapper.Map<IList<ViewArenal>>(arenales);
        }

        public async Task<IList<ViewArenal>> FindAllArenalByPoblacionId(int id)
        {
            ICollection<Arenal> arenales = await Context.ArenalPoblacion
               .TagWith("FindAllArenalByPoblacionId")
               .AsQueryable()
               .AsNoTracking()
               .Include(x => x.Poblacion)
               .Include(x => x.Arenal)
               .ThenInclude(x => x.Historicos)
               .ThenInclude(x => x.Bandera)
               .Where(x => x.Poblacion.Id == id)
               .Select(x => x.Arenal)
               .ToListAsync();

            return Mapper.Map<IList<ViewArenal>>(arenales);
        }

        public async Task<IList<ViewHistorico>> FindAllHistoricoByArenalId(int id)
        {
            ICollection<Historico> historicos = await Context.Historico
               .TagWith("FindAllHistoricoByArenalId")
               .AsQueryable()
               .AsNoTracking()
               .Include(x => x.Arenal)
               .Include(x => x.Bandera)
               .Where(x => x.Arenal.Id == id)
               .ToListAsync();

            return Mapper.Map<IList<ViewHistorico>>(historicos);
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

        public async Task<Poblacion> FindPoblacionById(int id)
        {
            Poblacion poblacion = await Context.Poblacion
                 .TagWith("FindPoblacionById")
                 .FirstOrDefaultAsync(x => x.Id == id);

            if (poblacion == null)
            {
                // Log
                string logData = poblacion.GetType().Name
                    + " with Id "
                    + id
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemNotFoundLog(logData);

                throw new Exception(poblacion.GetType().Name
                    + " with Id "
                    + id
                    + " does not exist");
            }

            return poblacion;
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

        public async Task RemoveArenalById(int id)
        {
            try
            {
                Arenal arenal = await FindArenalById(id);

                Context.Arenal.Remove(arenal);

                await Context.SaveChangesAsync();

                // Log
                string logData = arenal.GetType().Name
                    + " with Id"
                    + arenal.Id
                    + " was removed at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteDeleteItemLog(logData);
            }
            catch (DbUpdateConcurrencyException)
            {
                await FindArenalById(id);
            }
        }

        public async Task<ViewArenal> UpdateArenal(UpdateArenal viewModel)
        {
            await CheckName(viewModel);

            Arenal arenal = await FindArenalById(viewModel.Id);
            arenal.Name = viewModel.Name;
            arenal.ArenalPoblaciones = new List<ArenalPoblacion>();
            arenal.Historicos = new List<Historico>();

            try
            {
                Context.Arenal.Update(arenal);

                UpdateArenalPoblacion(viewModel, arenal);

                await UpdateHistorico(arenal);

                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                await CheckName(viewModel);
            }

            // Log
            string logData = arenal.GetType().Name
                + " with Id"
                + arenal.Id
                + " was modified at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteUpdateItemLog(logData);

            return Mapper.Map<ViewArenal>(arenal); ;
        }

        public void UpdateArenalPoblacion(UpdateArenal viewModel, Arenal entity)
        {
            viewModel.PoblacionesId.AsQueryable().ToList().ForEach(async x =>
            {
                Poblacion poblacion = await FindPoblacionById(x);

                ArenalPoblacion arenalPoblacion = new ArenalPoblacion
                {
                    Arenal = entity,
                    Poblacion = poblacion,
                };

                entity.ArenalPoblaciones.Add(arenalPoblacion);
            });
        }

        public async Task UpdateHistorico(Arenal entity)
        {
            Historico historico = new Historico
            {
                Arenal = entity,
                Bandera = await FindBanderaById((int)FlagIdentifiers.Amarilla),
                BajaMarAlba = DateTime.Now,
                BajaMarOcaso = DateTime.Now,
                AltaMarAlba = DateTime.Now,
                AltaMarOcaso = DateTime.Now,
                Temperatura = 20,
            };
            entity.Historicos.Add(historico);
        }

        public async Task<Arenal> CheckName(AddArenal viewModel)
        {
            Arenal arenal = await Context.Arenal
                 .AsNoTracking()
                 .TagWith("CheckName")
                 .FirstOrDefaultAsync(x => x.Name == viewModel.Name);

            if (arenal != null)
            {
                // Log
                string logData = arenal.GetType().Name
                    + " with Name "
                    + arenal.Name
                    + " was already found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemFoundLog(logData);

                throw new Exception(arenal.GetType().Name
                    + " with Name "
                    + viewModel.Name
                    + " already exists");
            }

            return arenal;
        }

        public async Task<Arenal> CheckName(UpdateArenal viewModel)
        {
            Arenal arenal = await Context.Arenal
                 .AsNoTracking()
                 .TagWith("CheckName")
                 .FirstOrDefaultAsync(x => x.Name == viewModel.Name && x.Id != viewModel.Id);

            if (arenal != null)
            {
                // Log
                string logData = arenal.GetType().Name
                    + " with Name "
                    + arenal.Name
                    + " was already found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemFoundLog(logData);

                throw new Exception(arenal.GetType().Name
                    + " with Name "
                    + viewModel.Name
                    + " already exists");
            }

            return arenal;
        }
    }
}
