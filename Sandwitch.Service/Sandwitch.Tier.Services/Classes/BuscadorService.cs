using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sandwitch.Tier.Contexts.Interfaces;
using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.Services.Interfaces;
using Sandwitch.Tier.ViewModels.Classes.Filters;
using Sandwitch.Tier.ViewModels.Classes.Finders;
using Sandwitch.Tier.ViewModels.Classes.Views;

namespace Sandwitch.Tier.Services.Classes
{
    /// <summary>
    /// Represents a <see cref="BuscadorService"/> class. Inherits <see cref="BaseService"/>. Implements <see cref="IBanderaService"/>
    /// </summary>    
    /// <param name="context">Injected <see cref="IApplicationContext"/></param>
    /// <param name="mapper">Injected <see cref="IMapper"/></param>
    /// <param name="logger">Injected <see cref="ILogger"/></param>
    public class BuscadorService(
        IApplicationContext @context,
        IMapper @mapper,
        ILogger<BuscadorService> @logger) : BaseService(@context,
        @mapper), IBuscadorService
    {
        /// <summary>
        /// Finds All Buscador
        /// </summary>
        /// <returns>Instance of <see cref="Task{IList{ViewBuscador}}"/></returns>
        public async Task<IList<ViewBuscador>> FindAllBuscador()
        {
            IList<Buscador> @buscadores = await Context.Provincia.Select(provincia => new Buscador()
                {
                    Id = provincia.Id,
                    ImageUri = provincia.ImageUri,
                    Name = provincia.Name,
                    Type = nameof(Provincia)
                }
            ).Union(Context.Poblacion.Select(poblacion => new Buscador()
            {
                Id = poblacion.Id,
                ImageUri = poblacion.ImageUri,
                Name = poblacion.Name,
                Type = nameof(Poblacion)
            })).ToListAsync();
            
            return Mapper.Map<IList<ViewBuscador>>(@buscadores);
        }

        /// <summary>
        /// Finds All Arenal By Buscador Id
        /// </summary>
        /// <param name="viewModel">Injected <see cref="FinderArenal"/></param>
        /// <returns>Instance of <see cref="Task{IList{ViewArenal}}"/></returns>
        public async Task<IList<ViewArenal>> FindAllArenalByBuscadorId(FinderArenal @viewModel)
        {
            Expression<Func<ArenalPoblacion, bool>> @expression = viewModel.Type switch
            {
                nameof(Poblacion) => x => x.Poblacion.Id == viewModel.Id,
                nameof(Provincia) => x => x.Poblacion.Provincia.Id == viewModel.Id,
                _ => x => false
            };
           
            IList<Arenal> arenales = await Context.ArenalPoblacion
                    .TagWith("FindAllArenalByBuscadorId")
                    .AsNoTracking()
                    .AsSplitQuery()
                    .Include(x => x.Poblacion.Provincia)
                    .Include(x => x.Arenal.Historicos)
                    .ThenInclude(x => x.Viento)
                    .Include(x => x.Arenal.Historicos)
                    .ThenInclude(x => x.Bandera)
                    .Where(@expression)
                    .Select(x => x.Arenal)
                    .ToListAsync();
            
            
            return Mapper.Map<IList<ViewArenal>>(@arenales);
        }
    }
}