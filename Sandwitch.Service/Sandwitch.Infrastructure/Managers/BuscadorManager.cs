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
        var provinciasTask = new ValueTask<List<BuscadorDto>>(
            Context.Provincia
                .AsNoTracking()
                .Select(p => p.ToFinder())
                .ToListAsync());

        var poblacionesTask = new ValueTask<List<BuscadorDto>>(
            Context.Poblacion
                .AsNoTracking()
                .Select(p => p.ToFinder())
                .ToListAsync());

        var resultsTasks = await Task.WhenAll(provinciasTask.AsTask(), poblacionesTask.AsTask());

        var buscadores = resultsTasks[0].Union(resultsTasks[1]).ToList();

        return buscadores;
    }

    /// <summary>
    ///     Finds All Arenal By Buscador Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <param name="type">Injected <see cref="string" /></param>
    /// <returns>Instance of <see cref="Task{IList{Arenal}}" /></returns>
    public async Task<IList<ArenalDto>> FindAllArenalByBuscadorId(int id, string type)
    {
        Expression<Func<Arenal, bool>> expression = type switch
        {
            nameof(Poblacion) => x => x.ArenalPoblaciones.Any(x=> x.PoblacionId == id),
            nameof(Provincia) => x => x.ArenalPoblaciones.Any(x => x.Poblacion.ProvinciaId == id),
            _ => x => false
        };

        IList<ArenalDto> @arenales = await Context.Arenal
            .TagWith("FindAllArenalByBuscadorId")
            .AsNoTracking()
            .AsSplitQuery()
            .Include(x=> x.ArenalPoblaciones)
            .ThenInclude(x => x.Poblacion)
            .Include(x => x.Historicos)
            .ThenInclude(x => x.Viento)
            .Include(x => x.Historicos)           
            .ThenInclude(x => x.Bandera)
            .Where(expression)
            .Select(x =>x.ToDto())
            .ToListAsync();      

        return @arenales;
    }
}