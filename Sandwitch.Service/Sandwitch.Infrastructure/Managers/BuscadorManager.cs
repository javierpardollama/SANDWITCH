using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sandwitch.Domain.Entities;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Finders;
using Sandwitch.Infrastructure.Contexts.Interfaces;

namespace Sandwitch.Infrastructure.Managers;

/// <summary>
///     Represents a <see cref="BuscadorManager" /> class. Inherits <see cref="BaseManager" />. Implements
///     <see cref="IBuscadorManager" />
/// </summary>
/// <param name="context">Injected <see cref="IApplicationContext" /></param>
public class BuscadorManager(
    IApplicationContext context) : BaseManager(context), IBuscadorManager
{
    /// <summary>
    ///     Finds All Buscador
    /// </summary>
    /// <returns>Instance of <see cref="Task{IList{ViewBuscador}}" /></returns>
    public async Task<IList<Buscador>> FindAllBuscador()
    {
        IList<Buscador> @buscadores = await Context.Provincia
            .AsNoTracking()
            .Select(provincia => new Buscador
            {
                Id = provincia.Id,
                ImageUri = provincia.ImageUri,
                Name = provincia.Name,
                Type = nameof(Provincia)
            }
        ).Union(Context.Poblacion
                .AsNoTracking()
                .Select(poblacion => new Buscador
        {
            Id = poblacion.Id,
            ImageUri = poblacion.ImageUri,
            Name = poblacion.Name,
            Type = nameof(Poblacion)
        })).ToListAsync();

        return @buscadores;
    }

    /// <summary>
    ///     Finds All Arenal By Buscador Id
    /// </summary>
    /// <param name="viewModel">Injected <see cref="FinderArenal" /></param>
    /// <returns>Instance of <see cref="Task{IList{Arenal}}" /></returns>
    public async Task<IList<Arenal>> FindAllArenalByBuscadorId(FinderArenal viewModel)
    {
        Expression<Func<ArenalPoblacion, bool>> expression = viewModel.Type switch
        {
            nameof(Poblacion) => x => x.Poblacion.Id == viewModel.Id,
            nameof(Provincia) => x => x.Poblacion.Provincia.Id == viewModel.Id,
            _ => x => false
        };

        IList<Arenal> @arenales = await Context.ArenalPoblacion
            .TagWith("FindAllArenalByBuscadorId")
            .AsNoTracking()
            .AsSplitQuery()
            .Include(x => x.Poblacion.Provincia)
            .Include(x => x.Arenal.Historicos)
            .ThenInclude(x => x.Viento)
            .Include(x => x.Arenal.Historicos)
            .ThenInclude(x => x.Bandera)
            .Where(expression)
            .Select(x => x.Arenal)
            .Distinct()
            .ToListAsync();


        return @arenales;
    }
}