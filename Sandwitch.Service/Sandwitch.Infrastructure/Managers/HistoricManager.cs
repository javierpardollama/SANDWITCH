using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sandwitch.Domain.Dtos;
using Sandwitch.Domain.Entities;
using Sandwitch.Domain.Exceptions;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.Profiles;
using Sandwitch.Infrastructure.Contexts.Interfaces;

namespace Sandwitch.Infrastructure.Managers;

/// <summary>
///     Represents a <see cref="HistoricManager" /> class. Inherits <see cref="BaseManager" />. Implements
///     <see cref="IHistoricManager" />
/// </summary>
/// <param name="context">Injected <see cref="IApplicationContext" /></param>
/// <param name="logger">Injected <see cref="ILogger{HistoricManager}" /></param>
public class HistoricManager(
    IApplicationContext context,
    ILogger<HistoricManager> logger) : BaseManager(context), IHistoricManager
{
    /// <summary>
    ///     Finds Beach By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Beach}" /></returns>
    public async Task<Beach> FindBeachById(int id)
    {
        Beach @Beach = await Context.Beach
            .TagWith("FindBeachById")
            .AsQueryable()
            .AsSplitQuery()
            .Include(x => x.BeachTowns)
            .ThenInclude(x => x.Town)
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

        if (@Beach == null)
        {
            // Log
            var logData = nameof(Beach)
                          + " with Id "
                          + id
                          + " was not found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(Beach)
                                       + " with Id "
                                       + id
                                       + " does not exist");
        }

        return @Beach;
    }

    /// <summary>
    ///     Finds Flag By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Flag}" /></returns>
    public async Task<Flag> FindFlagById(int id)
    {
        Flag @Flag = await Context.Flag
            .TagWith("FindFlagById")
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

        if (@Flag == null)
        {
            // Log
            var logData = nameof(Flag)
                          + " with Id "
                          + id
                          + " was not found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(Flag)
                                       + " with Id "
                                       + id
                                       + " does not exist");
        }

        return @Flag;
    }

    /// <summary>
    ///     Adds Historic
    /// </summary>
    /// <param name="entity">Injected <see cref="Historic" /></param>
    /// <returns>Instance of <see cref="Task{Historic}" /></returns>
    public async Task<Historic> AddHistoric(Historic @entity)
    {
        Historic @Historic = new()
        {
            Beach = await FindBeachById(@entity.BeachId),
            Flag = await FindFlagById(@entity.FlagId),
            Wind = await FindWindById(@entity.WindId),
            Speed = @entity.Speed,
            LowSeaDawn = @entity.LowSeaDawn,
            LowSeaSunset = @entity.LowSeaSunset,
            HighSeaDawn = @entity.HighSeaDawn,
            HighSeaSunset = @entity.HighSeaSunset,
            Temperature = @entity.Temperature
        };

        Context.Historic.Add(@Historic);

        await Context.SaveChangesAsync();

        // Log
        var logData = nameof(Historic)
                      + " with Id "
                      + @Historic.Id
                      + " was added at "
                      + DateTime.Now.ToShortTimeString();

        logger.LogInformation(logData);

        return @Historic;
    }

    /// <summary>
    ///     Finds Wind By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Wind}" /></returns>
    public async Task<Wind> FindWindById(int id)
    {
        Wind @Wind = await Context.Wind
            .TagWith("FindWindById")
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

        if (@Wind == null)
        {
            // Log
            var logData = nameof(Wind)
                          + " with Id "
                          + id
                          + " was not found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(Wind)
                                       + " with Id "
                                       + id
                                       + " does not exist");
        }

        return @Wind;
    }

    /// <summary>
    ///     Reloads Historic By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{HistoricDto}" /></returns>
    public async Task<HistoricDto> ReloadHistoricById(int id)
    {
        HistoricDto @dto = await Context.Historic
            .TagWith("ReloadHistoricById")
            .AsQueryable()
            .AsSplitQuery()
            .Include(x => x.Beach)
            .Include(x => x.Wind)
            .Include(x => x.Flag)
            .Where(x => x.Id == id)
            .Select(x => x.ToDto())
            .FirstOrDefaultAsync();
            

        if (@dto is null)
        {
            // Log
            var logData = nameof(Historic)
                          + " with Id "
                          + id
                          + " was not found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(Historic)
                                       + " with Id "
                                       + id
                                       + " does not exist");
        }

        return @dto;
    }
}