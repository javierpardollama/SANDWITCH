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
    /// Represents a <see cref="BanderaService"/> class. Inherits <see cref="BaseService"/>. Implements <see cref="IBanderaService"/>
    /// </summary>    
    /// <param name="context">Injected <see cref="IApplicationContext"/></param>
    /// <param name="mapper">Injected <see cref="IMapper"/></param>
    /// <param name="logger">Injected <see cref="ILogger{BanderaService}"/></param>
    public class BanderaService(IApplicationContext @context,
                          IMapper @mapper,
                          ILogger<BanderaService> @logger) : BaseService(@context,
                                                                  @mapper), IBanderaService
    {

        /// <summary>
        /// Adds Bandera
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddBandera"/></param>
        /// <returns>Instance of <see cref="Task{ViewBandera}"/></returns>
        public async Task<ViewBandera> AddBandera(AddBandera @viewModel)
        {
            await CheckName(@viewModel);

            Bandera @bandera = new()
            {
                Name = @viewModel.Name.Trim(),
                ImageUri = @viewModel.ImageUri.Trim()
            };

            try
            {
                await Context.Bandera.AddAsync(@bandera);

                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                await CheckName(@viewModel);
            }

            // Log
            string @logData = nameof(@bandera)
                + " with Id "
                + @bandera.Id
                + " was added at "
                + DateTime.Now.ToShortTimeString();

            @logger.WriteInsertItemLog(@logData);

            return Mapper.Map<ViewBandera>(@bandera);
        }

        /// <summary>
        /// Finds All Bandera
        /// </summary>
        /// <returns>Instance of <see cref="Task{IList{ViewBandera}}"/></returns>
        public async Task<IList<ViewBandera>> FindAllBandera()
        {
            IList<Bandera> @banderas = await Context.Bandera
                .TagWith("FindAllBandera")
                .AsNoTracking()
                .AsSplitQuery()
                .ToListAsync();

            return Mapper.Map<IList<ViewBandera>>(@banderas);
        }

        /// <summary>
        /// Finds Paginated Bandera
        /// </summary>
        /// <param name="viewModel">Injected <see cref="FilterPage"/></param>
        /// <returns>Instance of <see cref="Task{ViewPage{ViewBandera}}"/></returns>
        public async Task<ViewPage<ViewBandera>> FindPaginatedBandera(FilterPage @viewModel)
        {
            ViewPage<ViewBandera> @page = new()
            {
                Length = await Context.Bandera
                    .TagWith("CountAllBandera")
                    .AsNoTracking()
                    .AsSplitQuery()
                    .CountAsync(),
                Index = @viewModel.Index,
                Size = @viewModel.Size,
                Items = Mapper.Map<IList<ViewBandera>>(await Context.Bandera
               .TagWith("FindPaginatedBandera")
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
        public async Task<IList<ViewHistorico>> FindAllHistoricoByBanderaId(int @id)
        {
            ICollection<Historico> @historicos = await Context.Historico
               .TagWith("FindAllHistoricoByBanderaId")
               .AsNoTracking()
               .AsSplitQuery()
               .Include(x => x.Arenal)
               .Include(x => x.Bandera)
               .Where(x => x.Bandera.Id == @id)
               .ToListAsync();

            return Mapper.Map<IList<ViewHistorico>>(@historicos);
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

                @logger.WriteGetItemNotFoundLog(@logData);

                throw new ServiceException(nameof(@bandera)
                    + " with Id "
                    + @id
                    + " does not exist");
            }

            return @bandera;
        }

        /// <summary>
        /// Removes Bandera By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task"/></returns>
        public async Task RemoveBanderaById(int @id)
        {
            try
            {
                Bandera @bandera = await FindBanderaById(@id);

                Context.Bandera.Remove(@bandera);

                await Context.SaveChangesAsync();

                // Log
                string @logData = nameof(@bandera)
                    + " with Id "
                    + @bandera.Id
                    + " was removed at "
                    + DateTime.Now.ToShortTimeString();

                @logger.WriteDeleteItemLog(@logData);
            }
            catch (DbUpdateConcurrencyException)
            {
                await FindBanderaById(@id);
            }
        }

        /// <summary>
        /// Updates Bandera
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateBandera"/></param>
        /// <returns>Instance of <see cref="Task{ViewBandera}"/></returns>
        public async Task<ViewBandera> UpdateBandera(UpdateBandera @viewModel)
        {
            await CheckName(@viewModel);

            Bandera @bandera = await FindBanderaById(@viewModel.Id);
            @bandera.Name = @viewModel.Name.Trim();
            @bandera.ImageUri = @viewModel.ImageUri.Trim();

            try
            {
                Context.Bandera.Update(@bandera);

                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                await CheckName(@viewModel);
            }

            // Log
            string @logData = nameof(@bandera)
                + " with Id "
                + @bandera.Id
                + " was modified at "
                + DateTime.Now.ToShortTimeString();

            @logger.WriteUpdateItemLog(@logData);

            return Mapper.Map<ViewBandera>(@bandera);
        }

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddBandera"/></param>
        /// <returns>Instance of <see cref="Task{Bandera}"/></returns>
        public async Task<Bandera> CheckName(AddBandera @viewModel)
        {
            Bandera @bandera = await Context.Bandera
                 .TagWith("CheckName")
                 .AsNoTracking()
                 .AsSplitQuery()
                 .FirstOrDefaultAsync(x => x.Name == @viewModel.Name.Trim());

            if (@bandera != null)
            {
                // Log
                string @logData = nameof(@bandera)
                    + " with Name "
                    + @bandera.Name
                    + " was already found at "
                    + DateTime.Now.ToShortTimeString();

                @logger.WriteGetItemFoundLog(@logData);

                throw new ServiceException(nameof(@bandera)
                    + " with Name "
                    + @viewModel.Name
                    + " already exists");
            }

            return @bandera;
        }

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateBandera"/></param>
        /// <returns>Instance of <see cref="Task{Bandera}"/></returns>
        public async Task<Bandera> CheckName(UpdateBandera @viewModel)
        {
            Bandera @bandera = await Context.Bandera
                 .TagWith("CheckName")
                 .AsNoTracking()
                 .AsSplitQuery()
                 .FirstOrDefaultAsync(x => x.Name == @viewModel.Name.Trim() && x.Id != viewModel.Id);

            if (@bandera != null)
            {
                // Log
                string @logData = nameof(@bandera)
                    + " with Name "
                    + @bandera.Name
                    + " was already found at "
                    + DateTime.Now.ToShortTimeString();

                @logger.WriteGetItemFoundLog(@logData);

                throw new ServiceException(nameof(@bandera)
                    + " with Name "
                    + @viewModel.Name
                    + " already exists");
            }

            return bandera;
        }
    }
}
