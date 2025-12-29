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
///     Represents a <see cref="WindManager" /> class. Inherits <see cref="BaseManager" />. Implements
///     <see cref="IWindManager" />
/// </summary>
/// <param name="context">Injected <see cref="IApplicationContext" /></param>
/// <param name="logger">Injected <see cref="ILogger{WindManager}" /></param>
public class WindManager(
    IApplicationContext context,
    ILogger<WindManager> logger) : BaseManager(context), IWindManager
{
    /// <summary>
    ///     Adds Wind
    /// </summary>
    /// <param name="entity">Injected <see cref="Wind" /></param>
    /// <returns>Instance of <see cref="Task{Wind}" /></returns>
    public async Task<Wind> AddWind(Wind @entity)
    {
        await CheckName(entity.Name);

        try
        {
            await Context.Wind.AddAsync(@entity);

            await Context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            await CheckName(@entity.Name);
        }

        // Log
        var logData = nameof(Wind)
                      + " with Id "
                      + @entity.Id
                      + " was added at "
                      + DateTime.Now.ToShortTimeString();

        logger.LogInformation(logData);

        return @entity;
    }

    /// <summary>
    ///     Finds All Wind
    /// </summary>
    /// <returns>Instance of <see cref="Task{IList{CatalogDto}}" /></returns>
    public async Task<IList<CatalogDto>> FindAllWind()
    {
        IList<CatalogDto> @Winds = await Context.Wind
            .TagWith("FindAllWind")
            .AsNoTracking()
            .AsSplitQuery()
            .Select(x => x.ToCatalog())
            .ToListAsync();

        return @Winds;
    }

    /// <summary>
    ///     Finds Paginated Wind
    /// </summary>
    /// <param name="index">Injected <see cref="int" /></param>
    /// <param name="size">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{PageDto{WindDto}}" /></returns>
    public async Task<PageDto<WindDto>> FindPaginatedWind(int @index, int @size)
    {
        PageDto<WindDto> @page = new()
        {
            Length = await Context.Wind
                .TagWith("CountAllWind")
                .AsNoTracking()
                .AsSplitQuery()
                .CountAsync(),
            Index = @index,
            Size = @size,
            Items = await Context.Wind
                .TagWith("FindPaginatedWind")
                .AsNoTracking()
                .AsSplitQuery()
                .OrderByDescending(x => x.LastModified)
                .Skip(@index * @size)
                .Take(@size)
                .Select(x => x.ToDto())
                .ToListAsync()
        };

        return @page;
    }

    /// <summary>
    ///     Finds All Historic By Town Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="IList{HistoricDto}" /></returns>
    public async Task<IList<HistoricDto>> FindAllHistoricByWindId(int @id)
    {
        IList<HistoricDto> @Historics = await Context.Historic
            .TagWith("FindAllHistoricByWindId")
            .AsNoTracking()
            .AsSplitQuery()
            .Include(x => x.Beach)
            .Include(x => x.Wind)
            .Where(x => x.WindId == @id)
            .Select(x => x.ToDto())
            .ToListAsync();

        return @Historics;
    }

    /// <summary>
    ///     Finds Wind By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Wind}" /></returns>
    public async Task<Wind> FindWindById(int @id)
    {
        Wind @Wind = await Context.Wind
            .TagWith("FindWindById")
            .Where(x => x.Id == @id)
            .FirstOrDefaultAsync();

        if (@Wind == null)
        {
            // Log
            var logData = nameof(Wind)
                          + " with Id "
                          + @id
                          + " was not found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(Wind)
                                       + " with Id "
                                       + @id
                                       + " does not exist");
        }

        return @Wind;
    }

    /// <summary>
    ///     Removes Wind By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    public async Task RemoveWindById(int @id)
    {
        try
        {
            Wind @Wind = await FindWindById(@id);

            Context.Wind.Remove(@Wind);

            await Context.SaveChangesAsync();

            // Log
            var logData = nameof(Wind)
                          + " with Id "
                          + @Wind.Id
                          + " was removed at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogInformation(logData);
        }
        catch (DbUpdateConcurrencyException)
        {
            await FindWindById(@id);
        }
    }

    /// <summary>
    ///     Updates Wind
    /// </summary>
    /// <param name="entity">Injected <see cref="Wind" /></param>
    /// <returns>Instance of <see cref="Task{Wind}" /></returns>
    public async Task<Wind> UpdateWind(Wind @entity)
    {
        await CheckName(@entity.Id, @entity.Name);

        Wind @Wind = await FindWindById(@entity.Id);
        @Wind.Name = @entity.Name.Trim();
        @Wind.ImageUri = @entity.ImageUri.Trim();

        try
        {
            Context.Wind.Update(Wind);

            await Context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            await CheckName(@entity.Id, @entity.Name);
        }

        // Log
        var logData = nameof(Wind)
                      + " with Id "
                      + @Wind.Id
                      + " was modified at "
                      + DateTime.Now.ToShortTimeString();

        logger.LogInformation(logData);

        return @Wind;
    }

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <param name="name">Injected <see cref="string" /></param>
    /// <returns>Instance of <see cref="Task{bool}" /></returns>
    public async Task<bool> CheckName(string @name)
    {
        var @found = await Context.Wind
            .TagWith("CheckName")
            .AsNoTracking()
            .AsSplitQuery()
            .Where(x => x.Name == @name.Trim())
            .AnyAsync();

        if (@found)
        {
            // Log
            var logData = nameof(Wind)
                          + " with Name "
                          + @name
                          + " was already found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(Wind)
                                       + " with Name "
                                       + @name
                                       + " already exists");
        }

        return @found;
    }

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <param name="name">Injected <see cref="string" /></param>
    /// <returns>Instance of <see cref="Task{bool}" /></returns>
    public async Task<bool> CheckName(int @id, string @name)
    {
        var @found = await Context.Wind
            .TagWith("CheckName")
            .AsNoTracking()
            .AsSplitQuery()
            .Where(x => x.Name == @name.Trim() && x.Id != @id)
            .AnyAsync();

        if (@found)
        {
            // Log
            var logData = nameof(Wind)
                          + " with Name "
                          + @name
                          + " was already found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(Wind)
                                       + " with Name "
                                        + @name
                                       + " already exists");
        }

        return @found;
    }

    /// <summary>
    ///     Reloads Wind By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{WindDto}" /></returns>
    public async Task<WindDto> ReloadWindById(int @id)
    {
        WindDto @dto = await Context.Wind
            .TagWith("ReloadWindById")
            .AsQueryable()
            .AsSplitQuery()
            .AsNoTracking()
            .Where(x => x.Id == @id)
            .Select(x => x.ToDto())
            .FirstOrDefaultAsync();


        if (@dto is null)
        {
            // Log
            var logData = nameof(Wind)
                          + " with Id "
                          + @id
                          + " was not found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(Wind)
                                       + " with Id "
                                       + @id
                                       + " does not exist");
        }

        return @dto;
    }
}