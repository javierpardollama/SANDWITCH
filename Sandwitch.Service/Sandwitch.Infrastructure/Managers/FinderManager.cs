using Microsoft.EntityFrameworkCore;
using Sandwitch.Domain.Dtos;
using Sandwitch.Domain.Entities;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.Profiles;
using Sandwitch.Infrastructure.Contexts.Interfaces;
using System.Linq.Expressions;

namespace Sandwitch.Infrastructure.Managers;

/// <summary>
///     Represents a <see cref="FinderManager" /> class. Inherits <see cref="BaseManager" />. Implements
///     <see cref="IFinderManager" />
/// </summary>
/// <param name="context">Injected <see cref="IApplicationContext" /></param>
public class FinderManager(
    IApplicationContext context) : BaseManager(context), IFinderManager
{
    /// <summary>
    ///     Finds All Finder
    /// </summary>
    /// <returns>Instance of <see cref="Task{IList{FinderDto}}" /></returns>
    public async Task<IList<FinderDto>> FindAllFinder()
    {
        var StatesTask = new ValueTask<List<FinderDto>>(
            Context.State
                .AsNoTracking()
                .Select(p => p.ToFinder())
                .ToListAsync());

        var TownesTask = new ValueTask<List<FinderDto>>(
            Context.Town
                .AsNoTracking()
                .Select(p => p.ToFinder())
                .ToListAsync());

        var resultsTasks = await Task.WhenAll(StatesTask.AsTask(), TownesTask.AsTask());

        var Finderes = resultsTasks[0].Union(resultsTasks[1]).ToList();

        return Finderes;
    }

    /// <summary>
    ///     Finds All Beach By Finder Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <param name="group">Injected <see cref="string" /></param>
    /// <returns>Instance of <see cref="Task{IList{Beach}}" /></returns>
    public async Task<IList<BeachDto>> FindAllBeachByFinderId(int @id, string @group)
    {
        Expression<Func<Beach, bool>> expression = group switch
        {
            nameof(Town) => x => x.BeachTowns.Any(x=> x.TownId == @id),
            nameof(State) => x => x.BeachTowns.Any(x => x.Town.StateId == @id),
            _ => x => false
        };

        IList<BeachDto> @Beaches = await Context.Beach
            .TagWith("FindAllBeachByFinderId")
            .AsNoTracking()
            .AsSplitQuery()
            .Include(x=> x.BeachTowns)
            .ThenInclude(x => x.Town)
            .Include(x => x.Historics)
            .ThenInclude(x => x.Wind)
            .Include(x => x.Historics)           
            .ThenInclude(x => x.Flag)
            .Where(expression)
            .Select(x =>x.ToDto())
            .ToListAsync();      

        return @Beaches;
    }
}