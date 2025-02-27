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
    /// Represents a <see cref="ProvinciaService"/> class. Inherits <see cref="BaseService"/>. Implements <see cref="IProvinciaService"/>
    /// </summary>    
    /// <param name="context">Injected <see cref="IApplicationContext"/></param>
    /// <param name="mapper">Injected <see cref="IMapper"/></param>
    /// <param name="logger">Injected <see cref="ILogger"/></param>
    public class ProvinciaService(IApplicationContext @context,
                            IMapper @mapper,
                            ILogger<ProvinciaService> @logger) : BaseService(@context,
                                                                      @mapper,
                                                                      @logger), IProvinciaService
    {

        /// <summary>
        /// Adds Provincia
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddProvincia"/></param>
        /// <returns>Instance of <see cref="Task{ViewProvincia}"/></returns>
        public async Task<ViewProvincia> AddProvincia(AddProvincia @viewModel)
        {
            await CheckName(@viewModel);

            Provincia @provincia = new()
            {
                Name = @viewModel.Name.Trim(),
                ImageUri = @viewModel.ImageUri.Trim()
            };

            try
            {
                await Context.Provincia.AddAsync(@provincia);

                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                await CheckName(viewModel);
            }

            // Log
            string @logData = nameof(@provincia)
                + " with Id "
                + @provincia.Id
                + " was added at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteInsertItemLog(@logData);

            return Mapper.Map<ViewProvincia>(@provincia);
        }

        /// <summary>
        /// Finds All Provincia
        /// </summary>
        /// <returns>Instance of <see cref="Task{IList{ViewProvincia}}"/></returns>
        public async Task<IList<ViewProvincia>> FindAllProvincia()
        {
            IList<Provincia> @provincias = await Context.Provincia
                .TagWith("FindAllProvincia")
                .AsNoTracking()
                .AsSplitQuery()
                .Include(x => x.Poblaciones)
                .ToListAsync();

            return Mapper.Map<IList<ViewProvincia>>(@provincias);
        }

        /// <summary>
        /// Finds Paginated Provincia
        /// </summary>
        /// <param name="viewModel">Injected <see cref="FilterPage"/></param>
        /// <returns>Instance of <see cref="Task{ViewPage{ViewProvincia}}"/></returns>
        public async Task<ViewPage<ViewProvincia>> FindPaginatedProvincia(FilterPage @viewModel)
        {
            ViewPage<ViewProvincia> @page = new()
            {
                Length = await Context.Provincia
                    .AsNoTracking()
                    .AsSplitQuery()
                    .TagWith("CountAllProvincia")
                    .CountAsync(),
                Index = @viewModel.Index,
                Size = @viewModel.Size,
                Items = Mapper.Map<IList<ViewProvincia>>(await Context.Provincia
                    .TagWith("FindPaginatedProvincia")
                    .AsNoTracking()
                    .AsSplitQuery()
                    .Include(x => x.Poblaciones)
                    .Skip(@viewModel.Index * @viewModel.Size)
                    .Take(@viewModel.Size)
                    .ToListAsync())
            };

            return @page;
        }

        /// <summary>
        /// Finds Provincia By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{Provincia}"/></returns>
        public async Task<Provincia> FindProvinciaById(int id)
        {
            Provincia @provincia = await Context.Provincia
                .TagWith("FindProvinciaById")
                .FirstOrDefaultAsync(x => x.Id == id);

            if (@provincia == null)
            {
                // Log
                string @logData = nameof(@provincia)
                    + " with Id "
                    + id
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemNotFoundLog(@logData);

                throw new ServiceException(nameof(@provincia)
                    + " with Id "
                    + id
                    + " does not exist");
            }

            return @provincia;
        }

        /// <summary>
        /// Removes Provincia By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task"/></returns>
        public async Task RemoveProvinciaById(int id)
        {
            try
            {
                Provincia @provincia = await FindProvinciaById(id);

                Context.Provincia.Remove(@provincia);

                await Context.SaveChangesAsync();

                // Log
                string @logData = nameof(@provincia)
                    + " with Id "
                    + @provincia.Id
                    + " was removed at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteDeleteItemLog(@logData);
            }
            catch (DbUpdateConcurrencyException)
            {
                await FindProvinciaById(id);
            }
        }

        /// <summary>
        /// Updates Provincia
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateProvincia"/></param>
        /// <returns>Instance of <see cref="Task{ViewProvincia}"/></returns>
        public async Task<ViewProvincia> UpdateProvincia(UpdateProvincia @viewModel)
        {
            await CheckName(@viewModel);

            Provincia @provincia = await FindProvinciaById(@viewModel.Id);
            @provincia.Name = @viewModel.Name.Trim();
            @provincia.ImageUri = @viewModel.ImageUri.Trim();

            try
            {
                Context.Provincia.Update(@provincia);

                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                await CheckName(@viewModel);
            }

            // Log
            string @logData = nameof(@provincia)
                + " with Id "
                + @provincia.Id
                + " was modified at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteUpdateItemLog(@logData);

            return Mapper.Map<ViewProvincia>(@provincia);
        }

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddProvincia"/></param>
        /// <returns>Instance of <see cref="Task{Provincia}"/></returns>
        public async Task<Provincia> CheckName(AddProvincia @viewModel)
        {
            Provincia @provincia = await Context.Provincia
                 .AsNoTracking()
                 .AsSplitQuery()
                 .TagWith("CheckName")
                 .FirstOrDefaultAsync(x => x.Name == @viewModel.Name.Trim());

            if (@provincia != null)
            {
                // Log
                string @logData = nameof(@provincia)
                    + " with Name "
                    + @provincia.Name
                    + " was already found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemFoundLog(@logData);

                throw new ServiceException(nameof(@provincia)
                    + " with Name "
                    + @viewModel.Name
                    + " already exists");
            }

            return @provincia;
        }

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddProvincia"/></param>
        /// <returns>Instance of <see cref="Task{Provincia}"/></returns>
        public async Task<Provincia> CheckName(UpdateProvincia @viewModel)
        {
            Provincia @provincia = await Context.Provincia
                 .AsNoTracking()
                 .AsSplitQuery()
                 .TagWith("CheckName")
                 .FirstOrDefaultAsync(x => x.Name == @viewModel.Name.Trim() && x.Id != @viewModel.Id);

            if (@provincia != null)
            {
                // Log
                string @logData = nameof(@provincia)
                    + " with Name "
                    + provincia.Name
                    + " was already found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemFoundLog(@logData);

                throw new ServiceException(nameof(provincia)
                    + " with Name "
                    + @viewModel.Name
                    + " already exists");
            }

            return @provincia;
        }
    }
}
