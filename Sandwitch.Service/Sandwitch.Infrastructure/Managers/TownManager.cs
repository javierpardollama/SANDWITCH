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
///     Represents a <see cref="TownManager" /> class. Inherits <see cref="BaseManager" />. Implements
///     <see cref="ITownManager" />
/// </summary>
/// <param name="context">Injected <see cref="IApplicationContext" /></param>
/// <param name="logger">Injected <see cref="ILogger{TownManager}" /></param>
public class TownManager(
    IApplicationContext context,
    ILogger<TownManager> logger) : BaseManager(context), ITownManager
{
    /// <summary>
    ///     Adds Town
    /// </summary>
    /// <param name="entity">Injected <see cref="Town" /></param>
    /// <returns>Instance of <see cref="Task{Town}" /></returns>
    public async Task<Town> AddTown(Town @entity)
    {
        await CheckName(@entity.Name);     

        try
        {
            await Context.Town.AddAsync(@entity);

            await Context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            await CheckName(@entity.Name);
        }

        // Log
        var logData = nameof(Town)
                      + " with Id "
                      + @entity.Id
                      + " was added at "
                      + DateTime.Now.ToShortTimeString();

        logger.LogInformation(logData);

        return @entity;
    }

    /// <summary>
    ///     Finds All Town
    /// </summary>
    /// <returns>Instance of <see cref="Task{IList{CatalogDto}}" /></returns>
    public async Task<IList<CatalogDto>> FindAllTown()
    {
        IList<CatalogDto> @Townes = await Context.Town
            .TagWith("FindAllTown")
            .AsNoTracking()
            .AsSplitQuery()
            .Select(x => x.ToCatalog())
            .ToListAsync();

        return @Townes;
    }

    /// <summary>
    ///     Finds Paginated Town
    /// </summary>
    /// <param name="index">Injected <see cref="int" /></param>
    /// <param name="size">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{PageDto{StateDto}}" /></returns>
    public async Task<PageDto<TownDto>> FindPaginatedTown(int @index, int @size)
    {
        PageDto<TownDto> @page = new()
        {
            Length = await Context.Town
                .TagWith("CountAllTown")
                .AsNoTracking()
                .AsSplitQuery()
                .CountAsync(),
            Index = @index,
            Size = @size,
            Items = await Context.Town
                .TagWith("FindPaginatedTown")
                .AsNoTracking()
                .AsSplitQuery()
                .Include(x => x.State)
                .OrderByDescending(x => x.LastModified)
                .Skip(@index * @size)
                .Take(@size)
                .Select(x=> x.ToDto())
                .ToListAsync()
        };

        return @page;
    }

    /// <summary>
    ///     Finds Town By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Town}" /></returns>
    public async Task<Town> FindTownById(int @id)
    {
        Town @Town = await Context.Town
            .TagWith("FindTownById")
            .Where(x => x.Id == @id)
            .FirstOrDefaultAsync();

        if (@Town == null)
        {
            // Log
            var logData = nameof(Town)
                          + " with Id "
                          + id
                          + " was not found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(@Town)
                                       + " with Id "
                                       + id
                                       + " does not exist");
        }

        return @Town;
    }

    /// <summary>
    ///     Finds State By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{State}" /></returns>
    public async Task<State> FindStateById(int @id)
    {
        State @State = await Context.State
            .TagWith("FindStateById")
            .Where(x => x.Id == @id)
            .FirstOrDefaultAsync();

        if (@State == null)
        {
            // Log
            var logData = nameof(State)
                          + " with Id "
                          + @id
                          + " was not found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(State)
                                       + " with Id "
                                       + @id
                                       + " does not exist");
        }

        return @State;
    }

    /// <summary>
    ///     Removes Town By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    public async Task RemoveTownById(int @id)
    {
        try
        {
            Town @Town = await FindTownById(@id);

            Context.Town.Remove(@Town);

            await Context.SaveChangesAsync();

            // Log
            var logData = nameof(Town)
                          + " with Id "
                          + @Town.Id
                          + " was removed at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogInformation(logData);
        }
        catch (DbUpdateConcurrencyException)
        {
            await FindTownById(@id);
        }
    }

    /// <summary>
    ///     Updates Town
    /// </summary>
    /// <param name="entity">Injected <see cref="Town" /></param>
    /// <returns>Instance of <see cref="Task{Town}" /></returns>
    public async Task<Town> UpdateTown(Town @entity)
    {
        await CheckName(@entity.Id, @entity.Name);

        Town @Town = await FindTownById(@entity.Id);
        @Town.Name = @entity.Name.Trim();
        @Town.State = await FindStateById(@entity.StateId);
        @Town.ImageUri = @entity.ImageUri.Trim();

        try
        {
            Context.Town.Update(@Town);

            await Context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            await CheckName(@entity.Id, @entity.Name);
        }

        // Log
        var logData = nameof(Town)
                      + " with Id "
                      + @entity.Id
                      + " was modified at "
                      + DateTime.Now.ToShortTimeString();

        logger.LogInformation(logData);

        return @Town;
    }

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <param name="name">Injected <see cref="string" /></param>
    /// <returns>Instance of <see cref="Task{bool}" /></returns>
    public async Task<bool> CheckName(string @name)
    {
        var @found = await Context.Town
            .AsNoTracking()
            .AsSplitQuery()
            .TagWith("CheckName")
            .Where(x => x.Name == @name.Trim())
            .AnyAsync();

        if (@found)
        {
            // Log
            var logData = nameof(Town)
                          + " with Name "
                          + @name
                          + " was already found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(Town)
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
        var @found = await Context.Town
            .AsNoTracking()
            .AsSplitQuery()
            .TagWith("CheckName")
            .Where(x => x.Name == @name.Trim() && x.Id != @id)
            .AnyAsync();

        if (@found)
        {
            // Log
            var logData = nameof(Town)
                          + " with Name "
                          + @name
                          + " was already found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(Town)
                                       + " with Name "
                                       + @name
                                       + " already exists");
        }

        return @found;
    }

    /// <summary>
    ///     Reloads Town By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{TownDto}" /></returns>
    public async Task<TownDto> ReloadTownById(int @id)
    {
        TownDto @dto = await Context.Town
            .TagWith("ReloadTownById")
            .AsQueryable()
            .AsSplitQuery()
            .AsNoTracking()
            .Include(x=> x.State)
            .Where(x => x.Id == @id)
            .Select(x => x.ToDto())
            .FirstOrDefaultAsync();


        if (@dto is null)
        {
            // Log
            var logData = nameof(Town)
                          + " with Id "
                          + id
                          + " was not found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(Town)
                                       + " with Id "
                                       + @id
                                       + " does not exist");
        }

        return @dto;
    }
}