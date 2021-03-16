using System;
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
    /// Represents a <see cref="PoblacionService"/> class. Inherits <see cref="BaseService"/>. Implements <see cref="IPoblacionService"/>
    /// </summary>
    public class PoblacionService : BaseService, IPoblacionService
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="PoblacionService"/>
        /// </summary>
        /// <param name="context">Injected <see cref="IApplicationContext"/></param>
        /// <param name="mapper">Injected <see cref="IMapper"/></param>
        /// <param name="logger">Injected <see cref="ILogger"/></param>
        public PoblacionService(IApplicationContext @context,
                                IMapper @mapper,
                                ILogger<PoblacionService> @logger) : base(@context,
                                                                          @mapper,
                                                                          @logger)
        {
        }

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
                Name = @viewModel.Name,
                Provincia = await FindProvinciaById(@viewModel.ProvinciaId),
                ImageUri = @viewModel.ImageUri
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
            string logData = @poblacion.GetType().Name
                + " with Id "
                + @poblacion.Id
                + " was added at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteInsertItemLog(logData);

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
                .AsQueryable()
                .AsNoTracking()
                .Include(x => x.Provincia)
                .ToListAsync();

            return Mapper.Map<IList<ViewPoblacion>>(@poblaciones);
        }

        /// <summary>
        /// Finds Paginated Poblacion
        /// </summary>
        /// <param name="viewModel">Injected <see cref="FilterPage"/></param>
        /// <returns>Instance of <see cref="Task{ViewPage{ViewPoblacion}}"/></returns>
        public async Task<ViewPage<ViewPoblacion>> FindPaginatedPoblacion(FilterPage @viewmodel)
        {
            ViewPage<ViewPoblacion> @page = new()
            {
                Length = Context.Poblacion.TagWith("CountAllPoblacion").Count(),
                Index = @viewmodel.Index,
                Size = @viewmodel.Size,
                Items = Mapper.Map<IList<ViewPoblacion>>(await Context.Poblacion
                .TagWith("FindPaginatedPoblacion")
                .AsQueryable()
                .AsNoTracking()
                .Include(x => x.Provincia)
                .Skip(@viewmodel.Index * @viewmodel.Size)
                .Take(@viewmodel.Size)
                .ToListAsync())
            };

            return @page;
        }

        /// <summary>
        /// Finds All Poblacion By Provincia Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{IList{ViewPoblacion}}"/></returns>
        public async Task<IList<ViewPoblacion>> FindAllPoblacionByProvinciaId(int @id)
        {
            IList<Poblacion> @poblaciones = await Context.Poblacion
              .TagWith("FindAllPoblacionByProvinciaId")
              .AsQueryable()
              .AsNoTracking()
              .Include(x => x.Provincia)
              .Where(x => x.Provincia.Id == @id)
              .ToListAsync();

            return Mapper.Map<IList<ViewPoblacion>>(@poblaciones);
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
                string @logData = @poblacion.GetType().Name
                    + " with Id "
                    + id
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemNotFoundLog(@logData);

                throw new Exception(@poblacion.GetType().Name
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
                string @logData = @provincia.GetType().Name
                    + " with Id "
                    + @id
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemNotFoundLog(@logData);

                throw new Exception(@provincia.GetType().Name
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
                string @logData = @poblacion.GetType().Name
                    + " with Id "
                    + @poblacion.Id
                    + " was removed at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteDeleteItemLog(@logData);
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
            @poblacion.Name = @viewModel.Name;
            @poblacion.Provincia = await FindProvinciaById(@viewModel.ProvinciaId);
            @poblacion.ImageUri = @viewModel.ImageUri;

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
            string @logData = @poblacion.GetType().Name
                + " with Id "
                + @poblacion.Id
                + " was modified at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteUpdateItemLog(@logData);

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
                 .TagWith("CheckName")
                 .FirstOrDefaultAsync(x => x.Name == @viewModel.Name);

            if (@poblacion != null)
            {
                // Log
                string @logData = @poblacion.GetType().Name
                    + " with Name "
                    + @poblacion.Name
                    + " was already found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemFoundLog(@logData);

                throw new Exception(@poblacion.GetType().Name
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
                 .TagWith("CheckName")
                 .FirstOrDefaultAsync(x => x.Name == @viewModel.Name & x.Id != @viewModel.Id);

            if (@poblacion != null)
            {
                // Log
                string @logData = @poblacion.GetType().Name
                    + " with Name "
                    + @poblacion.Name
                    + " was already found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemFoundLog(@logData);

                throw new Exception(@poblacion.GetType().Name
                    + " with Name "
                    + @viewModel.Name
                    + " already exists");
            }

            return @poblacion;
        }
    }
}
