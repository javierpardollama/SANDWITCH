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
///     Represents a <see cref="VientoManager" /> class. Inherits <see cref="BaseManager" />. Implements
///     <see cref="IVientoManager" />
/// </summary>
/// <param name="context">Injected <see cref="IApplicationContext" /></param>
/// <param name="logger">Injected <see cref="ILogger{VientoManager}" /></param>
public class VientoManager(
    IApplicationContext context,
    ILogger<VientoManager> logger) : BaseManager(context), IVientoManager
{
    /// <summary>
    ///     Adds Viento
    /// </summary>
    /// <param name="entity">Injected <see cref="Viento" /></param>
    /// <returns>Instance of <see cref="Task{Viento}" /></returns>
    public async Task<Viento> AddViento(Viento @entity)
    {
        await CheckName(entity.Name);

        try
        {
            await Context.Viento.AddAsync(@entity);

            await Context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            await CheckName(@entity.Name);
        }

        // Log
        var logData = nameof(Viento)
                      + " with Id "
                      + @entity.Id
                      + " was added at "
                      + DateTime.Now.ToShortTimeString();

        logger.LogInformation(logData);

        return @entity;
    }

    /// <summary>
    ///     Finds All Viento
    /// </summary>
    /// <returns>Instance of <see cref="Task{IList{CatalogDto}}" /></returns>
    public async Task<IList<CatalogDto>> FindAllViento()
    {
        IList<CatalogDto> @vientos = await Context.Viento
            .TagWith("FindAllViento")
            .AsNoTracking()
            .AsSplitQuery()
            .Select(x => x.ToCatalog())
            .ToListAsync();

        return @vientos;
    }

    /// <summary>
    ///     Finds Paginated Viento
    /// </summary>
    /// <param name="index">Injected <see cref="int" /></param>
    /// <param name="size">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{PageDto{VientoDto}}" /></returns>
    public async Task<PageDto<VientoDto>> FindPaginatedViento(int @index, int @size)
    {
        PageDto<VientoDto> @page = new()
        {
            Length = await Context.Viento
                .TagWith("CountAllViento")
                .AsNoTracking()
                .AsSplitQuery()
                .CountAsync(),
            Index = @index,
            Size = @size,
            Items = await Context.Viento
                .TagWith("FindPaginatedViento")
                .AsNoTracking()
                .AsSplitQuery()
                .Skip(@index * @size)
                .Take(@size)
                .Select(x => x.ToDto())
                .ToListAsync()
        };

        return @page;
    }

    /// <summary>
    ///     Finds All Historico By Poblacion Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="IList{HistoricoDto}" /></returns>
    public async Task<IList<HistoricoDto>> FindAllHistoricoByVientoId(int @id)
    {
        IList<HistoricoDto> @historicos = await Context.Historico
            .TagWith("FindAllHistoricoByVientoId")
            .AsNoTracking()
            .AsSplitQuery()
            .Include(x => x.Arenal)
            .Include(x => x.Viento)
            .Where(x => x.VientoId == @id)
            .Select(x => x.ToDto())
            .ToListAsync();

        return @historicos;
    }

    /// <summary>
    ///     Finds Viento By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Viento}" /></returns>
    public async Task<Viento> FindVientoById(int @id)
    {
        Viento @viento = await Context.Viento
            .TagWith("FindVientoById")
            .Where(x => x.Id == @id)
            .FirstOrDefaultAsync();

        if (@viento == null)
        {
            // Log
            var logData = nameof(Viento)
                          + " with Id "
                          + @id
                          + " was not found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(Viento)
                                       + " with Id "
                                       + @id
                                       + " does not exist");
        }

        return @viento;
    }

    /// <summary>
    ///     Removes Viento By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    public async Task RemoveVientoById(int @id)
    {
        try
        {
            Viento @viento = await FindVientoById(@id);

            Context.Viento.Remove(@viento);

            await Context.SaveChangesAsync();

            // Log
            var logData = nameof(Viento)
                          + " with Id "
                          + @viento.Id
                          + " was removed at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogInformation(logData);
        }
        catch (DbUpdateConcurrencyException)
        {
            await FindVientoById(@id);
        }
    }

    /// <summary>
    ///     Updates Viento
    /// </summary>
    /// <param name="@entity">Injected <see cref="Viento" /></param>
    /// <returns>Instance of <see cref="Task{Viento}" /></returns>
    public async Task<Viento> UpdateViento(Viento @entity)
    {
        await CheckName(@entity.Id, @entity.Name);

        Viento @viento = await FindVientoById(@entity.Id);
        @viento.Name = @entity.Name.Trim();
        @viento.ImageUri = @entity.ImageUri.Trim();

        try
        {
            Context.Viento.Update(viento);

            await Context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            await CheckName(@entity.Id, @entity.Name);
        }

        // Log
        var logData = nameof(Viento)
                      + " with Id "
                      + @viento.Id
                      + " was modified at "
                      + DateTime.Now.ToShortTimeString();

        logger.LogInformation(logData);

        return @viento;
    }

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <param name="name">Injected <see cref="string" /></param>
    /// <returns>Instance of <see cref="Task{bool}" /></returns>
    public async Task<bool> CheckName(string @name)
    {
        var @found = await Context.Viento
            .TagWith("CheckName")
            .AsNoTracking()
            .AsSplitQuery()
            .Where(x => x.Name == @name.Trim())
            .AnyAsync();

        if (@found)
        {
            // Log
            var logData = nameof(Viento)
                          + " with Name "
                          + @name
                          + " was already found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(Viento)
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
        var @found = await Context.Viento
            .TagWith("CheckName")
            .AsNoTracking()
            .AsSplitQuery()
            .Where(x => x.Name == @name.Trim() && x.Id != @id)
            .AnyAsync();

        if (@found)
        {
            // Log
            var logData = nameof(Viento)
                          + " with Name "
                          + @name
                          + " was already found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(Viento)
                                       + " with Name "
                                        + @name
                                       + " already exists");
        }

        return @found;
    }

    /// <summary>
    ///     Reloads Viento By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{VientoDto}" /></returns>
    public async Task<VientoDto> ReloadVientoById(int id)
    {
        VientoDto @dto = await Context.Viento
            .TagWith("ReloadVientoById")
            .AsQueryable()
            .AsSplitQuery()
            .Where(x => x.Id == id)
            .Select(x => x.ToDto())
            .FirstOrDefaultAsync();


        if (@dto is null)
        {
            // Log
            var logData = nameof(Viento)
                          + " with Id "
                          + id
                          + " was not found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(Viento)
                                       + " with Id "
                                       + id
                                       + " does not exist");
        }

        return @dto;
    }
}