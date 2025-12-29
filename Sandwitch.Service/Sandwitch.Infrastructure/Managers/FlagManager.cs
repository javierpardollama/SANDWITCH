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
///     Represents a <see cref="FlagManager" /> class. Inherits <see cref="BaseManager" />. Implements
///     <see cref="IFlagManager" />
/// </summary>
/// <param name="context">Injected <see cref="IApplicationContext" /></param>
/// <param name="logger">Injected <see cref="ILogger{FlagManager}" /></param>
public class FlagManager(
    IApplicationContext context,
    ILogger<FlagManager> logger) : BaseManager(context), IFlagManager
{
    /// <summary>
    ///     Adds Flag
    /// </summary>
    /// <param name="entity">Injected <see cref="Flag" /></param>
    /// <returns>Instance of <see cref="Task{Flag}" /></returns>
    public async Task<Flag> AddFlag(Flag @entity)
    {
        await CheckName(@entity.Name);

        Flag @Flag = new()
        {
            Name = entity.Name.Trim(),
            ImageUri = entity.ImageUri.Trim()
        };

        try
        {
            await Context.Flag.AddAsync(@Flag);

            await Context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            await CheckName(@entity.Name);
        }

        // Log
        var logData = nameof(@Flag)
                      + " with Id "
                      + @Flag.Id
                      + " was added at "
                      + DateTime.Now.ToShortTimeString();

        logger.LogInformation(logData);

        return @Flag;
    }

    /// <summary>
    ///     Finds All Flag
    /// </summary>
    /// <returns>Instance of <see cref="Task{IList{CatalogDto}}" /></returns>
    public async Task<IList<CatalogDto>> FindAllFlag()
    {
        IList<CatalogDto> @Flags = await Context.Flag
            .TagWith("FindAllFlag")
            .AsNoTracking()
            .AsSplitQuery()
            .Select(x => x.ToCatalog())
            .ToListAsync();

        return @Flags;
    }

    /// <summary>
    ///     Finds Paginated Flag
    /// </summary>
    /// <param name="index">Injected <see cref="int" /></param>
    /// <param name="size">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{PageDto{FlagDto}}" /></returns>
    public async Task<PageDto<FlagDto>> FindPaginatedFlag(int @index, int @size)
    {
        PageDto<FlagDto> @page = new()
        {
            Length = await Context.Flag
                .TagWith("CountAllFlag")
                .AsNoTracking()
                .AsSplitQuery()
                .CountAsync(),
            Index = @index,
            Size = @size,
            Items = await Context.Flag
                .TagWith("FindPaginatedFlag")
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
    ///     Finds All Historic By Flag Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{IList{HistoricDto}}" /></returns>
    public async Task<IList<HistoricDto>> FindAllHistoricByFlagId(int @id)
    {
        IList<HistoricDto> @Historics = await Context.Historic
            .TagWith("FindAllHistoricByFlagId")
            .AsNoTracking()
            .AsSplitQuery()
            .Include(x => x.Beach)
            .Include(x => x.Flag)
            .Where(x => x.FlagId == @id)
            .Select(x=> x.ToDto())
            .ToListAsync();

        return @Historics;
    }

    /// <summary>
    ///     Finds Flag By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Flag}" /></returns>
    public async Task<Flag> FindFlagById(int @id)
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
                                       + @id
                                       + " does not exist");
        }

        return @Flag;
    }

    /// <summary>
    ///     Removes Flag By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    public async Task RemoveFlagById(int @id)
    {
        try
        {
            Flag @Flag = await FindFlagById(@id);

            Context.Flag.Remove(@Flag);

            await Context.SaveChangesAsync();

            // Log
            var logData = nameof(Flag)
                          + " with Id "
                          + @Flag.Id
                          + " was removed at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogInformation(logData);
        }
        catch (DbUpdateConcurrencyException)
        {
            await FindFlagById(@id);
        }
    }

    /// <summary>
    ///     Updates Flag
    /// </summary>
    /// <param name="entity">Injected <see cref="Flag" /></param>
    /// <returns>Instance of <see cref="Task{Flag}" /></returns>
    public async Task<Flag> UpdateFlag(Flag @entity)
    {
        await CheckName(@entity.Id, @entity.Name);

        Flag @Flag = await FindFlagById(@entity.Id);
        @Flag.Name = @entity.Name.Trim();
        @Flag.ImageUri = @entity.ImageUri.Trim();

        try
        {
            Context.Flag.Update(@Flag);

            await Context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            await CheckName(@entity.Id, @entity.Name);
        }

        // Log
        var logData = nameof(Flag)
                      + " with Id "
                      + Flag.Id
                      + " was modified at "
                      + DateTime.Now.ToShortTimeString();

        logger.LogInformation(logData);

        return @Flag;
    }

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <param name="name">Injected <see cref="string" /></param>
    /// <returns>Instance of <see cref="Task{bool}" /></returns>
    public async Task<bool> CheckName(string @name)
    {
        var @found = await Context.Flag
            .TagWith("CheckName")
            .AsNoTracking()
            .AsSplitQuery()
            .Where(x => x.Name == @name.Trim())
            .AnyAsync();

        if (@found)
        {
            // Log
            var logData = nameof(Flag)
                          + " with Name "
                          + @name
                          + " was already found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(Flag)
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
        var @found = await Context.Flag
            .TagWith("CheckName")
            .AsNoTracking()
            .AsSplitQuery()
            .Where(x => x.Name == @name.Trim() && x.Id != @id)
            .AnyAsync();

        if (@found)
        {
            // Log
            var logData = nameof(Flag)
                          + " with Name "
                          + @name
                          + " was already found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(Flag)
                                       + " with Name "
                                       + @name
                                       + " already exists");
        }

        return @found;
    }

    /// <summary>
    ///     Reloads Flag By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{FlagDto}" /></returns>
    public async Task<FlagDto> ReloadFlagById(int @id)
    {
        FlagDto @dto = await Context.Flag
            .TagWith("ReloadFlagById")
            .AsQueryable()
            .AsSplitQuery()
            .AsNoTracking()
            .Where(x => x.Id == @id)
            .Select(x => x.ToDto())
            .FirstOrDefaultAsync();


        if (@dto is null)
        {
            // Log
            var logData = nameof(Flag)
                          + " with Id "
                          + @id
                          + " was not found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(Flag)
                                       + " with Id "
                                       + @id
                                       + " does not exist");
        }

        return @dto;
    }
}