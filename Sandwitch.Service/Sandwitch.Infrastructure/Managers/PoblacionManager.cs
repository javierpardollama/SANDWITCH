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
///     Represents a <see cref="PoblacionManager" /> class. Inherits <see cref="BaseManager" />. Implements
///     <see cref="IPoblacionManager" />
/// </summary>
/// <param name="context">Injected <see cref="IApplicationContext" /></param>
/// <param name="logger">Injected <see cref="ILogger{PoblacionManager}" /></param>
public class PoblacionManager(
    IApplicationContext context,
    ILogger<PoblacionManager> logger) : BaseManager(context), IPoblacionManager
{
    /// <summary>
    ///     Adds Poblacion
    /// </summary>
    /// <param name="entity">Injected <see cref="Poblacion" /></param>
    /// <returns>Instance of <see cref="Task{Poblacion}" /></returns>
    public async Task<Poblacion> AddPoblacion(Poblacion @entity)
    {
        await CheckName(@entity.Name);     

        try
        {
            await Context.Poblacion.AddAsync(@entity);

            await Context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            await CheckName(@entity.Name);
        }

        // Log
        var logData = nameof(Poblacion)
                      + " with Id "
                      + @entity.Id
                      + " was added at "
                      + DateTime.Now.ToShortTimeString();

        logger.LogInformation(logData);

        return @entity;
    }

    /// <summary>
    ///     Finds All Poblacion
    /// </summary>
    /// <returns>Instance of <see cref="Task{IList{CatalogDto}}" /></returns>
    public async Task<IList<CatalogDto>> FindAllPoblacion()
    {
        IList<CatalogDto> @poblaciones = await Context.Poblacion
            .TagWith("FindAllPoblacion")
            .AsNoTracking()
            .AsSplitQuery()
            .Select(x => x.ToCatalog())
            .ToListAsync();

        return @poblaciones;
    }

    /// <summary>
    ///     Finds Paginated Poblacion
    /// </summary>
    /// <param name="index">Injected <see cref="int" /></param>
    /// <param name="size">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{PageDto{ProvinciaDto}}" /></returns>
    public async Task<PageDto<PoblacionDto>> FindPaginatedPoblacion(int @index, int @size)
    {
        PageDto<PoblacionDto> @page = new()
        {
            Length = await Context.Poblacion
                .TagWith("CountAllPoblacion")
                .AsNoTracking()
                .AsSplitQuery()
                .CountAsync(),
            Index = @index,
            Size = @size,
            Items = await Context.Poblacion
                .TagWith("FindPaginatedPoblacion")
                .AsNoTracking()
                .AsSplitQuery()
                .Include(x => x.Provincia)
                .Skip(@index * @size)
                .Take(@size)
                .Select(x=> x.ToDto())
                .ToListAsync()
        };

        return @page;
    }

    /// <summary>
    ///     Finds Poblacion By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Poblacion}" /></returns>
    public async Task<Poblacion> FindPoblacionById(int @id)
    {
        Poblacion @poblacion = await Context.Poblacion
            .TagWith("FindPoblacionById")
            .Where(x => x.Id == @id)
            .FirstOrDefaultAsync();

        if (@poblacion == null)
        {
            // Log
            var logData = nameof(Poblacion)
                          + " with Id "
                          + id
                          + " was not found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(@poblacion)
                                       + " with Id "
                                       + id
                                       + " does not exist");
        }

        return @poblacion;
    }

    /// <summary>
    ///     Finds Provincia By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Provincia}" /></returns>
    public async Task<Provincia> FindProvinciaById(int @id)
    {
        Provincia @provincia = await Context.Provincia
            .TagWith("FindProvinciaById")
            .Where(x => x.Id == @id)
            .FirstOrDefaultAsync();

        if (@provincia == null)
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

        return @provincia;
    }

    /// <summary>
    ///     Removes Poblacion By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    public async Task RemovePoblacionById(int @id)
    {
        try
        {
            Poblacion @poblacion = await FindPoblacionById(@id);

            Context.Poblacion.Remove(@poblacion);

            await Context.SaveChangesAsync();

            // Log
            var logData = nameof(Poblacion)
                          + " with Id "
                          + @poblacion.Id
                          + " was removed at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogInformation(logData);
        }
        catch (DbUpdateConcurrencyException)
        {
            await FindPoblacionById(@id);
        }
    }

    /// <summary>
    ///     Updates Poblacion
    /// </summary>
    /// <param name="entity">Injected <see cref="Poblacion" /></param>
    /// <returns>Instance of <see cref="Task{Poblacion}" /></returns>
    public async Task<Poblacion> UpdatePoblacion(Poblacion @entity)
    {
        await CheckName(@entity.Id, @entity.Name);

        Poblacion @poblacion = await FindPoblacionById(@entity.Id);
        @poblacion.Name = @entity.Name.Trim();
        @poblacion.Provincia = await FindProvinciaById(@entity.ProvinciaId);
        @poblacion.ImageUri = @entity.ImageUri.Trim();

        try
        {
            Context.Poblacion.Update(@poblacion);

            await Context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            await CheckName(@entity.Id, @entity.Name);
        }

        // Log
        var logData = nameof(Poblacion)
                      + " with Id "
                      + @entity.Id
                      + " was modified at "
                      + DateTime.Now.ToShortTimeString();

        logger.LogInformation(logData);

        return @poblacion;
    }

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <param name="name">Injected <see cref="string" /></param>
    /// <returns>Instance of <see cref="Task{bool}" /></returns>
    public async Task<bool> CheckName(string @name)
    {
        var @found = await Context.Poblacion
            .AsNoTracking()
            .AsSplitQuery()
            .TagWith("CheckName")
            .Where(x => x.Name == @name.Trim())
            .AnyAsync();

        if (@found)
        {
            // Log
            var logData = nameof(Poblacion)
                          + " with Name "
                          + @name
                          + " was already found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(Poblacion)
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
        var @found = await Context.Poblacion
            .AsNoTracking()
            .AsSplitQuery()
            .TagWith("CheckName")
            .Where(x => x.Name == @name.Trim() && x.Id != @id)
            .AnyAsync();

        if (@found)
        {
            // Log
            var logData = nameof(Poblacion)
                          + " with Name "
                          + @name
                          + " was already found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(Poblacion)
                                       + " with Name "
                                       + @name
                                       + " already exists");
        }

        return @found;
    }

    /// <summary>
    ///     Reloads Poblacion By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{PoblacionDto}" /></returns>
    public async Task<PoblacionDto> ReloadPoblacionById(int @id)
    {
        PoblacionDto @dto = await Context.Poblacion
            .TagWith("ReloadPoblacionById")
            .AsQueryable()
            .AsSplitQuery()
            .AsNoTracking()
            .Include(x=> x.Provincia)
            .Where(x => x.Id == @id)
            .Select(x => x.ToDto())
            .FirstOrDefaultAsync();


        if (@dto is null)
        {
            // Log
            var logData = nameof(Poblacion)
                          + " with Id "
                          + id
                          + " was not found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(Poblacion)
                                       + " with Id "
                                       + @id
                                       + " does not exist");
        }

        return @dto;
    }
}