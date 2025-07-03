using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

namespace Sandwitch.Tier.Services.Classes
{
    /// <summary>
    /// Represents a <see cref="PoblacionService"/> class. Inherits <see cref="BaseService"/>. Implements <see cref="IPoblacionService"/>
    /// </summary>   
    /// <param name="context">Injected <see cref="IApplicationContext"/></param>
    /// <param name="mapper">Injected <see cref="IMapper"/></param>
    /// <param name="logger">Injected <see cref="ILogger{PoblacionService}"/></param>
    public class PoblacionService(IApplicationContext @context,
                                  IMapper @mapper,
                                  ILogger<PoblacionService> @logger) : BaseService(@context,
                                                                      @mapper), IPoblacionService
    {

        /// <summary>
        /// Adds Poblacion
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddPoblacion"/></param>
        /// <returns>Instance of <see cref="Task{ViewPoblacion}"/></returns>
        public async Task<ViewPoblacion> AddPoblacion(AddPoblacion @viewModel)
        {
            await CheckName(@viewModel);

            Poblacion @poblacion = new()
            {
                Name = @viewModel.Name.Trim(),
                Provincia = await FindProvinciaById(@viewModel.ProvinciaId),
                ImageUri = @viewModel.ImageUri.Trim()
            };

            try
            {
                await Context.Poblacion.AddAsync(@poblacion);

                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                await CheckName(@viewModel);
            }

            // Log
            string @logData = nameof(@poblacion)
                + " with Id "
                + @poblacion.Id
                + " was added at "
                + DateTime.Now.ToShortTimeString();

            @logger.WriteInsertItemLog(@logData);

            return Mapper.Map<ViewPoblacion>(@poblacion);
        }

        /// <summary>
        /// Finds All Poblacion
        /// </summary>
        /// <returns>Instance of <see cref="Task{IList{ViewPoblacion}}"/></returns>
        public async Task<IList<ViewPoblacion>> FindAllPoblacion()
        {
            IList<Poblacion> @poblaciones = await Context.Poblacion
                .TagWith("FindAllPoblacion")
                .AsNoTracking()
                .AsSplitQuery()
                .Include(x => x.Provincia)
                .ToListAsync();

            return Mapper.Map<IList<ViewPoblacion>>(@poblaciones);
        }

        /// <summary>
        /// Finds Paginated Poblacion
        /// </summary>
        /// <param name="viewModel">Injected <see cref="FilterPage"/></param>
        /// <returns>Instance of <see cref="Task{ViewPage{ViewPoblacion}}"/></returns>
        public async Task<ViewPage<ViewPoblacion>> FindPaginatedPoblacion(FilterPage @viewModel)
        {
            ViewPage<ViewPoblacion> @page = new()
            {
                Length = await Context.Poblacion
                    .TagWith("CountAllPoblacion")
                    .AsNoTracking()
                    .AsSplitQuery()
                    .CountAsync(),
                Index = @viewModel.Index,
                Size = @viewModel.Size,
                Items = Mapper.Map<IList<ViewPoblacion>>(await Context.Poblacion
                    .TagWith("FindPaginatedPoblacion")
                    .AsNoTracking()
                    .AsSplitQuery()
                    .Include(x => x.Provincia)
                    .Skip(@viewModel.Index * @viewModel.Size)
                    .Take(@viewModel.Size)
                    .ToListAsync())
            };

            return @page;
        }

        /// <summary>
        /// Finds Poblacion By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{Poblacion}"/></returns>
        public async Task<Poblacion> FindPoblacionById(int id)
        {
            Poblacion @poblacion = await Context.Poblacion
                .TagWith("FindPoblacionById")
                .FirstOrDefaultAsync(x => x.Id == id);

            if (@poblacion == null)
            {
                // Log
                string @logData = nameof(@poblacion)
                    + " with Id "
                    + id
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                @logger.WriteGetItemNotFoundLog(@logData);

                throw new ServiceException(nameof(@poblacion)
                    + " with Id "
                    + id
                    + " does not exist");
            }

            return @poblacion;
        }

        /// <summary>
        /// Finds Provincia By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{Provincia}"/></returns>
        public async Task<Provincia> FindProvinciaById(int @id)
        {
            Provincia @provincia = await Context.Provincia
                 .TagWith("FindProvinciaById")
                 .FirstOrDefaultAsync(x => x.Id == @id);

            if (@provincia == null)
            {
                // Log
                string @logData = nameof(@provincia)
                    + " with Id "
                    + @id
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                @logger.WriteGetItemNotFoundLog(@logData);

                throw new ServiceException(nameof(@provincia)
                    + " with Id "
                    + @id
                    + " does not exist");
            }

            return @provincia;
        }

        /// <summary>
        /// Removes Poblacion By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task"/></returns>
        public async Task RemovePoblacionById(int @id)
        {
            try
            {
                Poblacion @poblacion = await FindPoblacionById(@id);

                Context.Poblacion.Remove(@poblacion);

                await Context.SaveChangesAsync();

                // Log
                string @logData = nameof(@poblacion)
                    + " with Id "
                    + @poblacion.Id
                    + " was removed at "
                    + DateTime.Now.ToShortTimeString();

                @logger.WriteDeleteItemLog(@logData);
            }
            catch (DbUpdateConcurrencyException)
            {
                await FindPoblacionById(@id);
            }
        }

        /// <summary>
        /// Updates Poblacion
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdatePoblacion"/></param>
        /// <returns>Instance of <see cref="Task{ViewPoblacion}"/></returns>
        public async Task<ViewPoblacion> UpdatePoblacion(UpdatePoblacion @viewModel)
        {
            await CheckName(@viewModel);

            Poblacion @poblacion = await FindPoblacionById(@viewModel.Id);
            @poblacion.Name = @viewModel.Name.Trim();
            @poblacion.Provincia = await FindProvinciaById(@viewModel.ProvinciaId);
            @poblacion.ImageUri = @viewModel.ImageUri.Trim();

            try
            {
                Context.Poblacion.Update(@poblacion);

                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                await CheckName(@viewModel);
            }

            // Log
            string @logData = nameof(@poblacion)
                + " with Id "
                + @poblacion.Id
                + " was modified at "
                + DateTime.Now.ToShortTimeString();

            @logger.WriteUpdateItemLog(@logData);

            return Mapper.Map<ViewPoblacion>(@poblacion);
        }

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddPoblacion"/></param>
        /// <returns>Instance of <see cref="Task{Poblacion}"/></returns>
        public async Task<Poblacion> CheckName(AddPoblacion @viewModel)
        {
            Poblacion @poblacion = await Context.Poblacion
                 .AsNoTracking()
                 .AsSplitQuery()
                 .TagWith("CheckName")
                 .FirstOrDefaultAsync(x => x.Name == @viewModel.Name.Trim());

            if (@poblacion != null)
            {
                // Log
                string @logData = nameof(@poblacion)
                    + " with Name "
                    + @poblacion.Name
                    + " was already found at "
                    + DateTime.Now.ToShortTimeString();

                @logger.WriteGetItemFoundLog(@logData);

                throw new ServiceException(nameof(@poblacion)
                    + " with Name "
                    + @viewModel.Name
                    + " already exists");
            }

            return @poblacion;
        }

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddPoblacion"/></param>
        /// <returns>Instance of <see cref="Task{Poblacion}"/></returns>
        public async Task<Poblacion> CheckName(UpdatePoblacion @viewModel)
        {
            Poblacion @poblacion = await Context.Poblacion
                 .AsNoTracking()
                 .AsSplitQuery()
                 .TagWith("CheckName")
                 .FirstOrDefaultAsync(x => x.Name == @viewModel.Name.Trim() & x.Id != @viewModel.Id);

            if (@poblacion != null)
            {
                // Log
                string @logData = nameof(@poblacion)
                    + " with Name "
                    + @poblacion.Name
                    + " was already found at "
                    + DateTime.Now.ToShortTimeString();

                @logger.WriteGetItemFoundLog(@logData);

                throw new ServiceException(nameof(@poblacion)
                    + " with Name "
                    + @viewModel.Name
                    + " already exists");
            }

            return @poblacion;
        }
    }
}
