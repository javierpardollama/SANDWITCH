using Microsoft.EntityFrameworkCore;
using Sandwitch.Domain.Dtos;
using Sandwitch.Domain.Entities;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.Profiles;
using Sandwitch.Infrastructure.Contexts.Interfaces;
using System.Linq.Expressions;

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
    /// <returns>Instance of <see cref="Task{IList{BuscadorDto}}" /></returns>
    public async Task<IList<BuscadorDto>> FindAllBuscador()
    {
        IList<BuscadorDto> @buscadores = await Context.Provincia
            .AsNoTracking()
            .Select(provincia=> provincia.ToQuery()
        ).Union(Context.Poblacion
                .AsNoTracking()
                .Select(poblacion => poblacion.ToQuery()))
        .ToListAsync();

        return @buscadores;
    }

    /// <summary>
    ///     Finds All Arenal By Buscador Id
    /// </summary>
    /// <param name="viewModel">Injected <see cref="FinderArenal" /></param>
    /// <returns>Instance of <see cref="Task{IList{Arenal}}" /></returns>
    public async Task<IList<ArenalDto>> FindAllArenalByBuscadorId(int id, string type)
    {
        Expression<Func<ArenalPoblacion, bool>> expression = type switch
        {
            nameof(Poblacion) => x => x.Poblacion.Id == id,
            nameof(Provincia) => x => x.Poblacion.Provincia.Id == id,
            _ => x => false
        };

        IList<ArenalDto> @arenales = await Context.ArenalPoblacion
            .TagWith("FindAllArenalByBuscadorId")
            .AsNoTracking()
            .AsSplitQuery()
            .Include(x => x.Poblacion.Provincia)
            .Include(x => x.Arenal.Historicos)
            .ThenInclude(x => x.Viento)
            .Include(x => x.Arenal.Historicos)
            .ThenInclude(x => x.Bandera)
            .Where(expression)
            .Select(x => x.Arenal.ToDto())
            .Distinct()
            .ToListAsync();


        return @arenales;
    }
}