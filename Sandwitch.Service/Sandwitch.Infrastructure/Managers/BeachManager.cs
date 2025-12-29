using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sandwitch.Domain.Dtos;
using Sandwitch.Domain.Entities;
using Sandwitch.Domain.Enums;
using Sandwitch.Domain.Exceptions;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.Profiles;
using Sandwitch.Infrastructure.Contexts.Interfaces;

namespace Sandwitch.Infrastructure.Managers;

/// <summary>
///     Represents a <see cref="BeachManager" /> class. Inherits <see cref="BaseManager" />. Implements
///     <see cref="IBeachManager" />
/// </summary>
/// <param name="context">Injected <see cref="IApplicationContext" /></param>
/// <param name="logger">Injected <see cref="ILogger{BeachManager}" /></param>
public class BeachManager(
    IApplicationContext context,
    ILogger<BeachManager> logger) : BaseManager(context), IBeachManager
{
    /// <summary>
    ///     Adds Beach
    /// </summary>
    /// <param name="@entity">Injected <see cref="Beach" /></param>
    /// <returns>Instance of <see cref="Task{ViewBeach}" /></returns>
    public async Task<Beach> AddBeach(Beach @entity)
    {
        await CheckName(@entity.Name);

        Beach Beach = new()
        {
            Name = @entity.Name.Trim(),
            BeachTowns = [],
            Historics = []
        };

        try
        {
            await Context.Beach.AddAsync(Beach);            

            await Context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            await CheckName(@entity.Name);
        }

        // Log
        var logData = nameof(Beach)
                      + " with Id "
                      + Beach.Id
                      + " was added at "
                      + DateTime.Now.ToShortTimeString();

        logger.LogInformation(logData);

        return Beach;
    }

    /// <summary>
    ///     Adds Beach Town
    /// </summary>
    /// <param name="Townes">Injected <see cref="List{Town}" /></param>
    /// <param name="entity">Injected <see cref="Beach" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    public async Task AddBeachTown(List<Town> @Townes, Beach @entity)
    {
        var @BeachTownes = @Townes.Select(@Town => new BeachTown()
        {
            Beach = @entity,
            Town = @Town           
        }).ToList();

        await Context.BeachTown.AddRangeAsync(@BeachTownes);

        await Context.SaveChangesAsync();

        // Log
        string @logData = nameof(BeachTown)
                          + "s with Ids "
                          + string.Join(",", @BeachTownes.Select(x => x.Id))
                          + " were added at "
                          + DateTime.UtcNow.ToShortTimeString();

        @logger.LogInformation(@logData);
    }

    /// <summary>
    ///     Adds Historic
    /// </summary>
    /// <param name="entity">Injected <see cref="Beach" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    public async Task AddHistoric(Beach @entity)
    {
        Historic @Historic = new()
        {
            Beach = @entity,
            Flag = await FindFlagById((int)FlagIdentifiers.Amarilla),
            Wind = await FindWindById((int)WindIdentifiers.Norte),
            LowSeaDawn = DateTime.Now.TimeOfDay,
            LowSeaSunset = DateTime.Now.TimeOfDay,
            HighSeaDawn = DateTime.Now.TimeOfDay,
            HighSeaSunset = DateTime.Now.TimeOfDay,
            Temperature = 20,
            Speed = 0
        };

        await Context.Historic.AddAsync(@Historic);

        await Context.SaveChangesAsync();

        // Log
        string @logData = nameof(Historic)
                          + "s with Id "
                          + @Historic.Id
                          + " were added at "
                          + DateTime.UtcNow.ToShortTimeString();

        @logger.LogInformation(@logData);
    }

    /// <summary>
    /// Finds All Town By Ids
    /// </summary>
    /// <param name="ids">Injected <see cref="ICollection{int}"/></param>
    /// <returns>Instance of <see cref="Task{List{Town}}"/></returns>
    public async Task<List<Town>> FindAllTownByIds(ICollection<int> @ids)
    {
        var @tasks = @ids.Select(@id => FindTownById(@id));
        var @Townes = await Task.WhenAll(tasks);
        return [.. @Townes];
    }

    /// <summary>
    ///     Finds All Beach
    /// </summary>
    /// <returns>Instance of <see cref="Task{IList{CatalogDto}}" /></returns>
    public async Task<IList<CatalogDto>> FindAllBeach()
    {
        IList<CatalogDto> @Beaches = await Context.Beach
            .TagWith("FindAllBeach")
            .AsNoTracking()
            .AsSplitQuery()
            .Select(x => x.ToCatalog())
            .ToListAsync();

        return @Beaches;
    }

    /// <summary>
    ///     Finds Paginated Beach
    /// </summary>
    /// <param name="index">Injected <see cref="int" /></param>
    /// <param name="size">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{PageDto{BeachDto}}" /></returns>
    public async Task<PageDto<BeachDto>> FindPaginatedBeach(int @index, int @size)
    {
        PageDto<BeachDto> @page = new()
        {
            Length = await Context.Beach
                .TagWith("CountAllBeach")
                .AsSplitQuery()
                .AsNoTracking()
                .CountAsync(),
            Index = @index,
            Size = @size,
            Items = await Context.Beach
                .TagWith("FindPaginatedBeach")
                .AsNoTracking()
                .AsSplitQuery()
                .Include(x => x.BeachTowns)
                .ThenInclude(x => x.Town)               
                .OrderByDescending(x => x.LastModified)
                .Skip(@index * @size)
                .Take(@size)
                .Select(x => x.ToDto())
                .ToListAsync()
        };

        return @page;
    }

    /// <summary>
    ///     Finds All Historic By Beach Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{IList{HistoricDto}}" /></returns>
    public async Task<IList<HistoricDto>> FindAllHistoricByBeachId(int @id)
    {
        IList<HistoricDto> @Historics = await Context.Historic
            .TagWith("FindAllHistoricByBeachId")
            .AsNoTracking()
            .AsSplitQuery()
            .Include(x => x.Beach)
            .Include(x => x.Flag)
            .Include(x => x.Wind)
            .Where(x => x.BeachId == @id)            
            .Select(x => x.ToDto())
            .ToListAsync();

        return @Historics;
    }

    /// <summary>
    ///     Finds Beach By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Beach}" /></returns>
    public async Task<Beach> FindBeachById(int @id)
    {
        Beach @Beach = await Context.Beach
            .TagWith("FindBeachById")
            .AsQueryable()
            .AsSplitQuery()
            .Include(x => x.BeachTowns)
            .ThenInclude(x => x.Town)
            .Where(x => x.Id == @id)
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
                          + @id
                          + " was not found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(Town)
                                       + " with Id "
                                       + @id
                                       + " does not exist");
        }

        return @Town;
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
            .Where(x => x.Id == @id)
            .FirstOrDefaultAsync();

        if (@Flag == null)
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

        return @Flag;
    }

    /// <summary>
    ///     Removes Beach By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    public async Task RemoveBeachById(int @id)
    {
        try
        {
            Beach @Beach = await FindBeachById(@id);

            Context.Beach.Remove(@Beach);

            await Context.SaveChangesAsync();

            // Log
            var logData = nameof(Beach)
                          + " with Id"
                          + @Beach.Id
                          + " was removed at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogInformation(logData);
        }
        catch (DbUpdateConcurrencyException)
        {
            await FindBeachById(@id);
        }
    }

    /// <summary>
    ///     Updates Beach
    /// </summary>
    /// <param name="entity">Injected <see cref="Beach" /></param>
    /// <returns>Instance of <see cref="Task{Beach}" /></returns>
    public async Task<Beach> UpdateBeach(Beach @entity)
    {
        await CheckName(@entity.Id, @entity.Name);

        Beach @Beach = await FindBeachById(@entity.Id);
        @Beach.Name = @entity.Name.Trim();
        @Beach.BeachTowns = [];
        @Beach.Historics = [];

        try
        {
            Context.Beach.Update(@Beach);           

            await Context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            await CheckName(@entity.Id, @entity.Name);
        }

        // Log
        var logData = nameof(Beach)
                      + " with Id"
                      + @entity.Id
                      + " was modified at "
                      + DateTime.Now.ToShortTimeString();

        logger.LogInformation(logData);

        return @Beach;
    }

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <param name="name">Injected <see cref="string" /></param>
    /// <returns>Instance of <see cref="Task{bool}" /></returns>
    public async Task<bool> CheckName(string @name)
    {
        var @found = await Context.Beach
            .AsNoTracking()
            .AsSplitQuery()
            .TagWith("CheckName")
            .Where(x => x.Name == @name.Trim())
            .AnyAsync();

        if (@found)
        {
            // Log
            var logData = nameof(Beach)
                          + " with Name "
                          + @name
                          + " was already found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(Beach)
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
        var @found = await Context.Beach
            .AsNoTracking()
            .AsSplitQuery()
            .TagWith("CheckName")
            .Where(x => x.Name == @name.Trim() && x.Id != @id)
            .AnyAsync();

        if (found)
        {
            // Log
            var logData = nameof(Beach)
                          + " with Name "
                          + @name
                          + " was already found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(Beach)
                                       + " with Name "
                                       + @name
                                       + " already exists");
        }

        return @found;
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
                          + id
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
    ///     Reloads Beach By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{BeachDto}" /></returns>
    public async Task<BeachDto> ReloadBeachById(int id)
    {
        BeachDto @dto = await Context.Beach
            .TagWith("ReloadBeachById")
            .AsQueryable()
            .AsSplitQuery()
            .AsNoTracking()
            .Include(x=> x.BeachTowns)
            .ThenInclude(x=> x.Town)
            .Where(x => x.Id == id)
            .Select(x => x.ToDto())
            .FirstOrDefaultAsync();


        if (@dto is null)
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
                                       + @id
                                       + " does not exist");
        }

        return @dto;
    }
}