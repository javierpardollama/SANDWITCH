﻿using System;
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
using Sandwitch.Tier.ViewModels.Classes.Filters;
using Sandwitch.Tier.ViewModels.Classes.Updates;
using Sandwitch.Tier.ViewModels.Classes.Views;

namespace Sandwitch.Tier.Services.Classes
{
    /// <summary>
    /// Represents a <see cref="BanderaService"/> class. Inherits <see cref="BaseService"/>. Implements <see cref="IBanderaService"/>
    /// </summary>
    public class BanderaService : BaseService, IBanderaService
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="BanderaService"/>
        /// </summary>
        /// <param name="context">Injected <see cref="IApplicationContext"/></param>
        /// <param name="mapper">Injected <see cref="IMapper"/></param>
        /// <param name="logger">Injected <see cref="ILogger"/></param>
        public BanderaService(IApplicationContext @context,
                              IMapper @mapper,
                              ILogger<BanderaService> @logger) : base(@context,
                                                                      @mapper,
                                                                      @logger)
        {
        }

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
                Name = @viewModel.Name,
                ImageUri = @viewModel.ImageUri
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
            string @logData = @bandera.GetType().Name
                + " with Id "
                + @bandera.Id
                + " was added at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteInsertItemLog(@logData);

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
                .ToListAsync();

            return Mapper.Map<IList<ViewBandera>>(@banderas);
        }

        /// <summary>
        /// Finds Paginated Bandera
        /// </summary>
        /// <param name="viewModel">Injected <see cref="FilterPage"/></param>
        /// <returns>Instance of <see cref="Task{ViewPage{ViewBandera}}"/></returns>
        public async Task<ViewPage<ViewBandera>> FindPaginatedBandera(FilterPage @viewmodel)
        {
            ViewPage<ViewBandera> @page = new()
            {
                Length = Context.Bandera.TagWith("CountAllBandera").Count(),
                Index = @viewmodel.Index,
                Size = @viewmodel.Size,
                Items = Mapper.Map<IList<ViewBandera>>(await Context.Bandera
               .TagWith("FindPaginatedBandera")
               .AsQueryable()
               .AsNoTracking()
               .Skip(@viewmodel.Index * @viewmodel.Size)
               .Take(@viewmodel.Size)
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
               .AsQueryable()
               .AsNoTracking()
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
                string @logData = @bandera.GetType().Name
                    + " with Id "
                    + @id
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemNotFoundLog(@logData);

                throw new Exception(@bandera.GetType().Name
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
                string @logData = @bandera.GetType().Name
                    + " with Id "
                    + @bandera.Id
                    + " was removed at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteDeleteItemLog(@logData);
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
            @bandera.Name = @viewModel.Name;
            @bandera.ImageUri = @viewModel.ImageUri;

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
            string @logData = @bandera.GetType().Name
                + " with Id "
                + @bandera.Id
                + " was modified at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteUpdateItemLog(@logData);

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
                 .FirstOrDefaultAsync(x => x.Name == @viewModel.Name);

            if (@bandera != null)
            {
                // Log
                string @logData = @bandera.GetType().Name
                    + " with Name "
                    + @bandera.Name
                    + " was already found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemFoundLog(@logData);

                throw new Exception(@bandera.GetType().Name
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
                 .FirstOrDefaultAsync(x => x.Name == @viewModel.Name && x.Id != viewModel.Id);

            if (@bandera != null)
            {
                // Log
                string @logData = @bandera.GetType().Name
                    + " with Name "
                    + @bandera.Name
                    + " was already found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemFoundLog(@logData);

                throw new Exception(@bandera.GetType().Name
                    + " with Name "
                    + @viewModel.Name
                    + " already exists");
            }

            return bandera;
        }
    }
}
