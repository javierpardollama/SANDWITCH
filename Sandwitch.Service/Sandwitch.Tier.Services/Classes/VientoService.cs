using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
    /// Represents a <see cref="VientoService"/> class. Inherits <see cref="BaseService"/>. Implements <see cref="IVientoService"/>
    /// </summary>    
    /// <param name="context">Injected <see cref="IApplicationContext"/></param>
    /// <param name="mapper">Injected <see cref="IMapper"/></param>
    /// <param name="logger">Injected <see cref="ILogger"/></param>
    public class VientoService(IApplicationContext @context,
                          IMapper @mapper,
                          ILogger<VientoService> @logger) : BaseService(@context,
                                                                  @mapper,
                                                                  @logger), IVientoService
    {

        /// <summary>
        /// Adds Viento
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddViento"/></param>
        /// <returns>Instance of <see cref="Task{ViewViento}"/></returns>
        public async Task<ViewViento> AddViento(AddViento @viewModel)
        {
            await CheckName(@viewModel);

            Viento @Viento = new()
            {
                Name = @viewModel.Name.Trim(),
                ImageUri = @viewModel.ImageUri.Trim()
            };

            try
            {
                await Context.Viento.AddAsync(@Viento);

                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                await CheckName(@viewModel);
            }

            // Log
            string @logData = nameof(@Viento)
                + " with Id "
                + @Viento.Id
                + " was added at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteInsertItemLog(@logData);

            return Mapper.Map<ViewViento>(@Viento);
        }

        /// <summary>
        /// Finds All Viento
        /// </summary>
        /// <returns>Instance of <see cref="Task{IList{ViewViento}}"/></returns>
        public async Task<IList<ViewViento>> FindAllViento()
        {
            IList<Viento> @Vientos = await Context.Viento
                .TagWith("FindAllViento")
                .AsNoTracking()
                .AsSplitQuery()
                .ToListAsync();

            return Mapper.Map<IList<ViewViento>>(@Vientos);
        }

        /// <summary>
        /// Finds Paginated Viento
        /// </summary>
        /// <param name="viewModel">Injected <see cref="FilterPage"/></param>
        /// <returns>Instance of <see cref="Task{ViewPage{ViewViento}}"/></returns>
        public async Task<ViewPage<ViewViento>> FindPaginatedViento(FilterPage @viewModel)
        {
            ViewPage<ViewViento> @page = new()
            {
                Length = await Context.Viento
                    .TagWith("CountAllViento")
                    .AsNoTracking()
                    .AsSplitQuery()
                    .CountAsync(),
                Index = @viewModel.Index,
                Size = @viewModel.Size,
                Items = Mapper.Map<IList<ViewViento>>(await Context.Viento
               .TagWith("FindPaginatedViento")
               .AsNoTracking()
               .AsSplitQuery()
               .Skip(@viewModel.Index * @viewModel.Size)
               .Take(@viewModel.Size)
               .ToListAsync())
            };

            return @page;
        }

        /// <summary>
        /// Finds All Historico By Poblacion Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="IList{ViewHistorico}"/></returns>
        public async Task<IList<ViewHistorico>> FindAllHistoricoByVientoId(int @id)
        {
            ICollection<Historico> @historicos = await Context.Historico
               .TagWith("FindAllHistoricoByVientoId")
               .AsNoTracking()
               .AsSplitQuery()
               .Include(x => x.Arenal)
               .Include(x => x.Viento)
               .Where(x => x.Viento.Id == @id)
               .ToListAsync();

            return Mapper.Map<IList<ViewHistorico>>(@historicos);
        }

        /// <summary>
        /// Finds Viento By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{Viento}"/></returns>
        public async Task<Viento> FindVientoById(int @id)
        {
            Viento @Viento = await Context.Viento
                 .TagWith("FindVientoById")
                 .FirstOrDefaultAsync(x => x.Id == @id);

            if (@Viento == null)
            {
                // Log
                string @logData = nameof(@Viento)
                    + " with Id "
                    + @id
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemNotFoundLog(@logData);

                throw new ServiceException(nameof(@Viento)
                    + " with Id "
                    + @id
                    + " does not exist");
            }

            return @Viento;
        }

        /// <summary>
        /// Removes Viento By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task"/></returns>
        public async Task RemoveVientoById(int @id)
        {
            try
            {
                Viento @Viento = await FindVientoById(@id);

                Context.Viento.Remove(@Viento);

                await Context.SaveChangesAsync();

                // Log
                string @logData = nameof(@Viento)
                    + " with Id "
                    + @Viento.Id
                    + " was removed at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteDeleteItemLog(@logData);
            }
            catch (DbUpdateConcurrencyException)
            {
                await FindVientoById(@id);
            }
        }

        /// <summary>
        /// Updates Viento
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateViento"/></param>
        /// <returns>Instance of <see cref="Task{ViewViento}"/></returns>
        public async Task<ViewViento> UpdateViento(UpdateViento @viewModel)
        {
            await CheckName(@viewModel);

            Viento @Viento = await FindVientoById(@viewModel.Id);
            @Viento.Name = @viewModel.Name.Trim();
            @Viento.ImageUri = @viewModel.ImageUri.Trim();

            try
            {
                Context.Viento.Update(@Viento);

                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                await CheckName(@viewModel);
            }

            // Log
            string @logData = nameof(@Viento)
                + " with Id "
                + @Viento.Id
                + " was modified at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteUpdateItemLog(@logData);

            return Mapper.Map<ViewViento>(@Viento);
        }

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddViento"/></param>
        /// <returns>Instance of <see cref="Task{Viento}"/></returns>
        public async Task<Viento> CheckName(AddViento @viewModel)
        {
            Viento @Viento = await Context.Viento
                 .TagWith("CheckName")
                 .AsNoTracking()
                 .AsSplitQuery()
                 .FirstOrDefaultAsync(x => x.Name == @viewModel.Name.Trim());

            if (@Viento != null)
            {
                // Log
                string @logData = nameof(@Viento)
                    + " with Name "
                    + @Viento.Name
                    + " was already found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemFoundLog(@logData);

                throw new ServiceException(nameof(@Viento)
                    + " with Name "
                    + @viewModel.Name
                    + " already exists");
            }

            return @Viento;
        }

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateViento"/></param>
        /// <returns>Instance of <see cref="Task{Viento}"/></returns>
        public async Task<Viento> CheckName(UpdateViento @viewModel)
        {
            Viento @Viento = await Context.Viento
                 .TagWith("CheckName")
                 .AsNoTracking()
                 .AsSplitQuery()
                 .FirstOrDefaultAsync(x => x.Name == @viewModel.Name.Trim() && x.Id != viewModel.Id);

            if (@Viento != null)
            {
                // Log
                string @logData = nameof(@Viento)
                    + " with Name "
                    + @Viento.Name
                    + " was already found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemFoundLog(@logData);

                throw new ServiceException(nameof(@Viento)
                    + " with Name "
                    + @viewModel.Name
                    + " already exists");
            }

            return Viento;
        }
    }
}
