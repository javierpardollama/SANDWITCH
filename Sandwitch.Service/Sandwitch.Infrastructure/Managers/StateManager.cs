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
///     Represents a <see cref="StateManager" /> class. Inherits <see cref="BaseManager" />. Implements
///     <see cref="IStateManager" />
/// </summary>
/// <param name="context">Injected <see cref="IApplicationContext" /></param>
/// <param name="logger">Injected <see cref="ILogger{StateManager}" /></param>
public class StateManager(
    IApplicationContext context,
    ILogger<StateManager> logger) : BaseManager(context), IStateManager
{
    /// <summary>
    ///     Adds State
    /// </summary>
    /// <param name="entity">Injected <see cref="State" /></param>
    /// <returns>Instance of <see cref="Task{State}" /></returns>
    public async Task<State> AddState(State @entity)
    {
        await CheckName(@entity.Name);      

        try
        {
            await Context.State.AddAsync(@entity);

            await Context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            await CheckName(@entity.Name);
        }

        // Log
        var logData = nameof(State)
                      + " with Id "
                      + @entity.Id
                      + " was added at "
                      + DateTime.Now.ToShortTimeString();

        logger.LogInformation(logData);

        return @entity;
    }

    /// <summary>
    ///     Finds All State
    /// </summary>
    /// <returns>Instance of <see cref="Task{IList{CatalogDto}}" /></returns>
    public async Task<IList<CatalogDto>> FindAllState()
    {
        IList<CatalogDto> @States = await Context.State
            .TagWith("FindAllState")
            .AsNoTracking()
            .AsSplitQuery()
            .Select(x=> x.ToCatalog())
            .ToListAsync();

        return @States;
    }

    /// <summary>
    ///     Finds Paginated State
    /// </summary>
    /// <param name="index">Injected <see cref="int" /></param>
    /// <param name="size">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{PageDto{StateDto}}" /></returns>
    public async Task<PageDto<StateDto>> FindPaginatedState(int @index, int @size)
    {
        PageDto<StateDto> @page = new()
        {
            Length = await Context.State
                .AsNoTracking()
                .AsSplitQuery()
                .TagWith("CountAllState")
                .CountAsync(),
            Index = @index,
            Size = @size,
            Items = await Context.State
                .TagWith("FindPaginatedState")
                .AsNoTracking()
                .AsSplitQuery()
                .Include(x => x.Towns)
                .OrderByDescending(x => x.LastModified)
                .Skip(@index * @size)
                .Take(@size)
                .Select(x => x.ToDto())
                .ToListAsync()
        };

        return @page;
    }

    /// <summary>
    ///     Finds State By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{State}" /></returns>
    public async Task<State> FindStateById(int @id)
    {
        var @State = await Context.State
            .TagWith("FindStateById")
            .Where(x => x.Id == @id)
            .FirstOrDefaultAsync();

        if (@State == null)
        {
            // Log
            var logData = nameof(State)
                          + " with Id "
                          + id
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
    ///     Removes State By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    public async Task RemoveStateById(int @id)
    {
        try
        {
            State @State = await FindStateById(@id);

            Context.State.Remove(@State);

            await Context.SaveChangesAsync();

            // Log
            var logData = nameof(State)
                          + " with Id "
                          + @State.Id
                          + " was removed at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogInformation(logData);
        }
        catch (DbUpdateConcurrencyException)
        {
            await FindStateById(@id);
        }
    }

    /// <summary>
    ///     Updates State
    /// </summary>
    /// <param name="entity">Injected <see cref="State" /></param>
    /// <returns>Instance of <see cref="Task{State}" /></returns>
    public async Task<State> UpdateState(State @entity)
    {
        await CheckName(entity.Id, entity.Name);

        State @State = await FindStateById(entity.Id);
        @State.Name = entity.Name.Trim();
        @State.ImageUri = entity.ImageUri.Trim();

        try
        {
            Context.State.Update(@State);

            await Context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            await CheckName(@entity.Id, @entity.Name);
        }

        // Log
        var logData = nameof(State)
                      + " with Id "
                      + @entity.Id
                      + " was modified at "
                      + DateTime.Now.ToShortTimeString();

        logger.LogInformation(logData);

        return @State;
    }

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <param name="name">Injected <see cref="string" /></param>
    /// <returns>Instance of <see cref="Task{bool}" /></returns>
    public async Task<bool> CheckName(string @name)
    {
        var @found = await Context.State
            .AsNoTracking()
            .AsSplitQuery()
            .TagWith("CheckName")
            .Where(x => x.Name == @name.Trim())
            .AnyAsync();

        if (@found)
        {
            // Log
            var logData = nameof(State)
                          + " with Name "
                          + @name
                          + " was already found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(State)
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
        var @found = await Context.State
            .AsNoTracking()
            .AsSplitQuery()
            .TagWith("CheckName")
            .Where(x => x.Name == @name.Trim() && x.Id != @id)
            .AnyAsync();

        if (@found)
        {
            // Log
            var logData = nameof(State)
                          + " with Name "
                          + @name
                          + " was already found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(State)
                                       + " with Name "
                                        + @name
                                       + " already exists");
        }

        return @found;
    }

    /// <summary>
    ///     Reloads State By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{StateDto}" /></returns>
    public async Task<StateDto> ReloadStateById(int @id)
    {
        StateDto @dto = await Context.State
            .TagWith("ReloadStateById")
            .AsQueryable()
            .AsSplitQuery()
            .AsNoTracking()
            .Where(x => x.Id == @id)
            .Select(x => x.ToDto())
            .FirstOrDefaultAsync();


        if (@dto is null)
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

        return @dto;
    }
}