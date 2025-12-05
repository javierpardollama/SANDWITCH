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
///     Represents a <see cref="ProvinciaManager" /> class. Inherits <see cref="BaseManager" />. Implements
///     <see cref="IProvinciaManager" />
/// </summary>
/// <param name="context">Injected <see cref="IApplicationContext" /></param>
/// <param name="logger">Injected <see cref="ILogger{ProvinciaManager}" /></param>
public class ProvinciaManager(
    IApplicationContext context,
    ILogger<ProvinciaManager> logger) : BaseManager(context), IProvinciaManager
{
    /// <summary>
    ///     Adds Provincia
    /// </summary>
    /// <param name="entity">Injected <see cref="Provincia" /></param>
    /// <returns>Instance of <see cref="Task{Provincia}" /></returns>
    public async Task<Provincia> AddProvincia(Provincia @entity)
    {
        await CheckName(@entity.Name);      

        try
        {
            await Context.Provincia.AddAsync(@entity);

            await Context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            await CheckName(@entity.Name);
        }

        // Log
        var logData = nameof(Provincia)
                      + " with Id "
                      + @entity.Id
                      + " was added at "
                      + DateTime.Now.ToShortTimeString();

        logger.LogInformation(logData);

        return @entity;
    }

    /// <summary>
    ///     Finds All Provincia
    /// </summary>
    /// <returns>Instance of <see cref="Task{IList{CatalogDto}}" /></returns>
    public async Task<IList<CatalogDto>> FindAllProvincia()
    {
        IList<CatalogDto> @provincias = await Context.Provincia
            .TagWith("FindAllProvincia")
            .AsNoTracking()
            .AsSplitQuery()
            .Select(x=> x.ToCatalog())
            .ToListAsync();

        return @provincias;
    }

    /// <summary>
    ///     Finds Paginated Provincia
    /// </summary>
    /// <param name="index">Injected <see cref="int" /></param>
    /// <param name="size">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{PageDto{ProvinciaDto}}" /></returns>
    public async Task<PageDto<ProvinciaDto>> FindPaginatedProvincia(int @index, int @size)
    {
        PageDto<ProvinciaDto> @page = new()
        {
            Length = await Context.Provincia
                .AsNoTracking()
                .AsSplitQuery()
                .TagWith("CountAllProvincia")
                .CountAsync(),
            Index = @index,
            Size = @size,
            Items = await Context.Provincia
                .TagWith("FindPaginatedProvincia")
                .AsNoTracking()
                .AsSplitQuery()
                .Include(x => x.Poblaciones)
                .OrderByDescending(x => x.LastModified)
                .Skip(@index * @size)
                .Take(@size)
                .Select(x => x.ToDto())
                .ToListAsync()
        };

        return @page;
    }

    /// <summary>
    ///     Finds Provincia By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Provincia}" /></returns>
    public async Task<Provincia> FindProvinciaById(int @id)
    {
        var @provincia = await Context.Provincia
            .TagWith("FindProvinciaById")
            .Where(x => x.Id == @id)
            .FirstOrDefaultAsync();

        if (@provincia == null)
        {
            // Log
            var logData = nameof(Provincia)
                          + " with Id "
                          + id
                          + " was not found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(Provincia)
                                       + " with Id "
                                       + @id
                                       + " does not exist");
        }

        return @provincia;
    }

    /// <summary>
    ///     Removes Provincia By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    public async Task RemoveProvinciaById(int @id)
    {
        try
        {
            Provincia @provincia = await FindProvinciaById(@id);

            Context.Provincia.Remove(@provincia);

            await Context.SaveChangesAsync();

            // Log
            var logData = nameof(Provincia)
                          + " with Id "
                          + @provincia.Id
                          + " was removed at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogInformation(logData);
        }
        catch (DbUpdateConcurrencyException)
        {
            await FindProvinciaById(@id);
        }
    }

    /// <summary>
    ///     Updates Provincia
    /// </summary>
    /// <param name="entity">Injected <see cref="Provincia" /></param>
    /// <returns>Instance of <see cref="Task{Provincia}" /></returns>
    public async Task<Provincia> UpdateProvincia(Provincia @entity)
    {
        await CheckName(entity.Id, entity.Name);

        Provincia @provincia = await FindProvinciaById(entity.Id);
        @provincia.Name = entity.Name.Trim();
        @provincia.ImageUri = entity.ImageUri.Trim();

        try
        {
            Context.Provincia.Update(@provincia);

            await Context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            await CheckName(@entity.Id, @entity.Name);
        }

        // Log
        var logData = nameof(Provincia)
                      + " with Id "
                      + @entity.Id
                      + " was modified at "
                      + DateTime.Now.ToShortTimeString();

        logger.LogInformation(logData);

        return @provincia;
    }

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <param name="name">Injected <see cref="string" /></param>
    /// <returns>Instance of <see cref="Task{bool}" /></returns>
    public async Task<bool> CheckName(string @name)
    {
        var @found = await Context.Provincia
            .AsNoTracking()
            .AsSplitQuery()
            .TagWith("CheckName")
            .Where(x => x.Name == @name.Trim())
            .AnyAsync();

        if (@found)
        {
            // Log
            var logData = nameof(Provincia)
                          + " with Name "
                          + @name
                          + " was already found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(Provincia)
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
        var @found = await Context.Provincia
            .AsNoTracking()
            .AsSplitQuery()
            .TagWith("CheckName")
            .Where(x => x.Name == @name.Trim() && x.Id != @id)
            .AnyAsync();

        if (@found)
        {
            // Log
            var logData = nameof(Provincia)
                          + " with Name "
                          + @name
                          + " was already found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(Provincia)
                                       + " with Name "
                                        + @name
                                       + " already exists");
        }

        return @found;
    }

    /// <summary>
    ///     Reloads Provincia By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{ProvinciaDto}" /></returns>
    public async Task<ProvinciaDto> ReloadProvinciaById(int @id)
    {
        ProvinciaDto @dto = await Context.Provincia
            .TagWith("ReloadProvinciaById")
            .AsQueryable()
            .AsSplitQuery()
            .AsNoTracking()
            .Where(x => x.Id == @id)
            .Select(x => x.ToDto())
            .FirstOrDefaultAsync();


        if (@dto is null)
        {
            // Log
            var logData = nameof(Provincia)
                          + " with Id "
                          + @id
                          + " was not found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(Provincia)
                                       + " with Id "
                                       + @id
                                       + " does not exist");
        }

        return @dto;
    }
}