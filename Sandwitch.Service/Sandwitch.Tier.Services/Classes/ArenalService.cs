using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sandwitch.Tier.Constants.Enums;
using Sandwitch.Tier.Contexts.Interfaces;
using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.Exceptions.Exceptions;
using Sandwitch.Tier.Logging.Classes;
using Sandwitch.Tier.Services.Interfaces;
using Sandwitch.Tier.ViewModels.Classes.Additions;
using Sandwitch.Tier.ViewModels.Classes.Filters;
using Sandwitch.Tier.ViewModels.Classes.Updates;
using Sandwitch.Tier.ViewModels.Classes.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sandwitch.Tier.Services.Classes
{
    /// <summary>
    /// Represents a <see cref="ArenalService"/> class. Inherits <see cref="BaseService"/>. Implements <see cref="IArenalService"/>
    /// </summary>    
    /// <param name="context">Injected <see cref="IApplicationContext"/></param>
    /// <param name="mapper">Injected <see cref="IMapper"/></param>
    /// <param name="logger">Injected <see cref="ILogger"/></param>
    public class ArenalService(IApplicationContext @context,
                               IMapper @mapper,
                               ILogger<ArenalService> @logger) : BaseService(@context,
                                                                @mapper,
                                                                @logger), IArenalService
    {

        /// <summary>
        /// Adds Arenal
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddArenal"/></param>
        /// <returns>Instance of <see cref="Task{ViewArenal}"/></returns>
        public async Task<ViewArenal> AddArenal(AddArenal @viewModel)
        {
            await CheckName(@viewModel);

            Arenal @arenal = new()
            {
                Name = @viewModel.Name.Trim(),
                ArenalPoblaciones = new List<ArenalPoblacion>(),
                Historicos = new List<Historico>()
            };

            try
            {
                await Context.Arenal.AddAsync(@arenal);

                AddArenalPoblacion(@viewModel, @arenal);

                await AddHistorico(@arenal);

                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                await CheckName(@viewModel);
            }

            // Log
            string @logData = nameof(@arenal)
                + " with Id "
                + @arenal.Id
                + " was added at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteInsertItemLog(@logData);

            return Mapper.Map<ViewArenal>(@arenal); ;
        }

        /// <summary>
        /// Adds Arenal Poblacion
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddArenal"/></param>
        /// <param name="entity">Injected <see cref="Arenal"/></param>
        public void AddArenalPoblacion(AddArenal @viewModel,
                                             Arenal @entity)
        {
            @viewModel.PoblacionesId.AsQueryable().ToList().ForEach(async x =>
            {
                Poblacion @poblacion = await FindPoblacionById(x);

                ArenalPoblacion @arenalPoblacion = new()
                {
                    Arenal = @entity,
                    Poblacion = @poblacion,
                };

                @entity.ArenalPoblaciones.Add(@arenalPoblacion);
            });
        }

        /// <summary>
        /// Adds Historico
        /// </summary>
        /// <param name="entity">Injected <see cref="Arenal"/></param>
        /// <returns>Instance of <see cref="Task"/></returns>
        public async Task AddHistorico(Arenal @entity)
        {
            Historico @historico = new()
            {
                Arenal = @entity,
                Bandera = await FindBanderaById((int)FlagIdentifiers.Amarilla),
                Viento = await FindVientoById((int)WindIdentifiers.Norte),
                BajaMarAlba = DateTime.Now.TimeOfDay,
                BajaMarOcaso = DateTime.Now.TimeOfDay,
                AltaMarAlba = DateTime.Now.TimeOfDay,
                AltaMarOcaso = DateTime.Now.TimeOfDay,
                Temperatura = 20,
                Velocidad = 0,
            };
            @entity.Historicos.Add(@historico);
        }

        /// <summary>
        /// Finds All Arenal
        /// </summary>
        /// <returns>Instance of <see cref="Task{IList{ViewArenal}}"/></returns>
        public async Task<IList<ViewArenal>> FindAllArenal()
        {
            ICollection<Arenal> @arenales = await Context.Arenal
                .TagWith("FindAllArenal")
                .AsNoTracking()
                .AsSplitQuery()
                .Include(x => x.ArenalPoblaciones)
                .ThenInclude(x => x.Poblacion)
                .Include(x => x.Historicos)
                .ToListAsync();

            return Mapper.Map<IList<ViewArenal>>(@arenales);
        }

        /// <summary>
        /// Finds Paginated Arenal
        /// </summary>
        /// <param name="viewModel">Injected <see cref="FilterPage"/></param>
        /// <returns>Instance of <see cref="Task{ViewPage{ViewArenal}}"/></returns>
        public async Task<ViewPage<ViewArenal>> FindPaginatedArenal(FilterPage @viewModel)
        {
            ViewPage<ViewArenal> @page = new()
            {
                Length = await Context.Arenal
                .TagWith("CountAllArenal")
                .AsSplitQuery()
                .AsNoTracking()
                .CountAsync(),
                Index = @viewModel.Index,
                Size = @viewModel.Size,
                Items = Mapper.Map<IList<ViewArenal>>(await Context.Arenal
               .TagWith("FindPaginatedArenal")
               .AsNoTracking()
               .AsSplitQuery()
               .Include(x => x.ArenalPoblaciones)
               .ThenInclude(x => x.Poblacion)
               .Include(x => x.Historicos)
               .Skip(@viewModel.Index * @viewModel.Size)
               .Take(@viewModel.Size)
               .ToListAsync())
            };

            return @page;
        }

        /// <summary>
        /// Finds All Arenal By Poblacion Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{IList{ViewArenal}}"/></returns>
        public async Task<IList<ViewArenal>> FindAllArenalByPoblacionId(int @id)
        {
            ICollection<Arenal> @arenales = await Context.ArenalPoblacion
               .TagWith("FindAllArenalByPoblacionId")
               .AsNoTracking()
               .AsSplitQuery()
               .Include(x => x.Poblacion)
               .Include(x => x.Arenal.Historicos)
               .ThenInclude(x => x.Viento)
               .Include(x => x.Arenal.Historicos)
               .ThenInclude(x => x.Bandera)
               .Include(x => x.Arenal)            
               .Where(x => x.Poblacion.Id == @id)
               .Select(x => x.Arenal)
               .ToListAsync();

            return Mapper.Map<IList<ViewArenal>>(@arenales);
        }

        /// <summary>
        /// Finds All Historico By Arenal Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{IList{ViewHistorico}}"/></returns>
        public async Task<IList<ViewHistorico>> FindAllHistoricoByArenalId(int @id)
        {
            ICollection<Historico> @historicos = await Context.Historico
               .TagWith("FindAllHistoricoByArenalId")
               .AsNoTracking()
               .AsSplitQuery()
               .Include(x => x.Arenal)
               .Include(x => x.Bandera)
               .Include(x => x.Viento)
               .Where(x => x.Arenal.Id == @id)
               .ToListAsync();

            return Mapper.Map<IList<ViewHistorico>>(@historicos);
        }

        /// <summary>
        /// Finds Arenal By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{Arenal}"/></returns>
        public async Task<Arenal> FindArenalById(int @id)
        {
            Arenal @arenal = await Context.Arenal
                .TagWith("FindArenalById")
                .AsQueryable()
                .AsSplitQuery()
                .Include(x => x.ArenalPoblaciones)
                .ThenInclude(x => x.Poblacion)
                .FirstOrDefaultAsync(x => x.Id == @id);

            if (@arenal == null)
            {
                // Log
                string @logData = nameof(@arenal)
                    + " with Id "
                    + @id
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemNotFoundLog(@logData);

                throw new ServiceException(nameof(@arenal)
                    + " with Id "
                    + @id
                    + " does not exist");
            }

            return @arenal;
        }

        /// <summary>
        /// Finds Poblacion By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{Poblacion}"/></returns>
        public async Task<Poblacion> FindPoblacionById(int @id)
        {
            Poblacion @poblacion = await Context.Poblacion
                 .TagWith("FindPoblacionById")
                 .FirstOrDefaultAsync(x => x.Id == @id);

            if (@poblacion == null)
            {
                // Log
                string @logData = nameof(@poblacion)
                    + " with Id "
                    + @id
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemNotFoundLog(@logData);

                throw new ServiceException(nameof(@poblacion)
                    + " with Id "
                    + @id
                    + " does not exist");
            }

            return poblacion;
        }

        /// <summary>
        /// Finds Bandera By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{Bandera}"/></returns>
        public async Task<Bandera> FindBanderaById(int @id)
        {
            Bandera @bandera = await Context.Bandera
                 .TagWith("FindBanderaById")
                 .FirstOrDefaultAsync(x => x.Id == @id);

            if (@bandera == null)
            {
                // Log
                string @logData = nameof(@bandera)
                    + " with Id "
                    + @id
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemNotFoundLog(@logData);

                throw new ServiceException(nameof(@bandera)
                    + " with Id "
                    + @id
                    + " does not exist");
            }

            return @bandera;
        }

        /// <summary>
        /// Finds Viento By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{Viento}"/></returns>
        public async Task<Viento> FindVientoById(int @id)
        {
            Viento @viento = await Context.Viento
                 .TagWith("FindVientoById")
                 .FirstOrDefaultAsync(x => x.Id == @id);

            if (@viento == null)
            {
                // Log
                string @logData = nameof(@viento)
                    + " with Id "
                    + @id
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemNotFoundLog(@logData);

                throw new ServiceException(nameof(@viento)
                    + " with Id "
                    + @id
                    + " does not exist");
            }

            return @viento;
        }

        /// <summary>
        /// Removes Arenal By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task"/></returns>
        public async Task RemoveArenalById(int @id)
        {
            try
            {
                Arenal @arenal = await FindArenalById(@id);

                Context.Arenal.Remove(@arenal);

                await Context.SaveChangesAsync();

                // Log
                string @logData = nameof(@arenal)
                    + " with Id"
                    + @arenal.Id
                    + " was removed at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteDeleteItemLog(@logData);
            }
            catch (DbUpdateConcurrencyException)
            {
                await FindArenalById(@id);
            }
        }

        /// <summary>
        /// Updates Arenal
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateArenal"/></param>
        /// <returns>Instance of <see cref="Task{ViewArenal}"/></returns>
        public async Task<ViewArenal> UpdateArenal(UpdateArenal @viewModel)
        {
            await CheckName(@viewModel);

            Arenal @arenal = await FindArenalById(@viewModel.Id);
            @arenal.Name = @viewModel.Name.Trim();
            @arenal.ArenalPoblaciones = new List<ArenalPoblacion>();
            @arenal.Historicos = new List<Historico>();

            try
            {
                Context.Arenal.Update(@arenal);

                UpdateArenalPoblacion(@viewModel, @arenal);

                await UpdateHistorico(@arenal);

                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                await CheckName(@viewModel);
            }

            // Log
            string @logData = nameof(@arenal)
                + " with Id"
                + @arenal.Id
                + " was modified at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteUpdateItemLog(@logData);

            return Mapper.Map<ViewArenal>(@arenal); ;
        }

        /// <summary>
        /// Updates Arenal Poblacion
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateArenal"/></param>
        /// <param name="entity">Injected <see cref="Arenal"/></param>
        public void UpdateArenalPoblacion(UpdateArenal @viewModel, Arenal @entity)
        {
            @viewModel.PoblacionesId.AsQueryable().ToList().ForEach(async x =>
            {
                Poblacion @poblacion = await FindPoblacionById(x);

                ArenalPoblacion @arenalPoblacion = new()
                {
                    Arenal = @entity,
                    Poblacion = @poblacion,
                };

                @entity.ArenalPoblaciones.Add(@arenalPoblacion);
            });
        }

        /// <summary>
        /// Updates Historico
        /// </summary>
        /// <param name="entity">Injected <see cref="Arenal"/></param>
        /// <returns>Instance of <see cref="Task"/></returns>
        public async Task UpdateHistorico(Arenal @entity)
        {
            Historico @historico = new()
            {
                Arenal = @entity,
                Bandera = await FindBanderaById((int)FlagIdentifiers.Amarilla),
                Viento = await FindVientoById((int)WindIdentifiers.Norte),
                BajaMarAlba = DateTime.Now.TimeOfDay,
                BajaMarOcaso = DateTime.Now.TimeOfDay,
                AltaMarAlba = DateTime.Now.TimeOfDay,
                AltaMarOcaso = DateTime.Now.TimeOfDay,
                Temperatura = 20,
                Velocidad = 0
            };
            @entity.Historicos.Add(@historico);
        }

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddArenal"/></param>
        /// <returns>Instance of <see cref="Task{Arenal}"/></returns>
        public async Task<Arenal> CheckName(AddArenal @viewModel)
        {
            Arenal @arenal = await Context.Arenal
                 .AsNoTracking()
                 .AsSplitQuery()
                 .TagWith("CheckName")
                 .FirstOrDefaultAsync(x => x.Name == @viewModel.Name.Trim());

            if (@arenal != null)
            {
                // Log
                string @logData = nameof(@arenal)
                    + " with Name "
                    + @arenal.Name
                    + " was already found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemFoundLog(@logData);

                throw new ServiceException(nameof(@arenal)
                    + " with Name "
                    + @viewModel.Name
                    + " already exists");
            }

            return @arenal;
        }

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateArenal"/></param>
        /// <returns>Instance of <see cref="Task{Arenal}"/></returns>
        public async Task<Arenal> CheckName(UpdateArenal @viewModel)
        {
            Arenal @arenal = await Context.Arenal
                 .AsNoTracking()
                 .AsSplitQuery()
                 .TagWith("CheckName")
                 .FirstOrDefaultAsync(x => x.Name == @viewModel.Name.Trim() && x.Id != @viewModel.Id);

            if (@arenal != null)
            {
                // Log
                string @logData = nameof(@arenal)
                    + " with Name "
                    + @arenal.Name
                    + " was already found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemFoundLog(@logData);

                throw new ServiceException(nameof(@arenal)
                    + " with Name "
                    + @viewModel.Name
                    + " already exists");
            }

            return @arenal;
        }
    }
}
