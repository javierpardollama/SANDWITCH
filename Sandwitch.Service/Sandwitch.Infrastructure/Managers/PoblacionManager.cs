using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sandwitch.Domain.Entities;
using Sandwitch.Domain.Exceptions;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Additions;
using Sandwitch.Domain.ViewModels.Filters;
using Sandwitch.Domain.ViewModels.Updates;
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
    /// <param name="viewModel">Injected <see cref="AddPoblacion" /></param>
    /// <returns>Instance of <see cref="Task{Poblacion}" /></returns>
    public async Task<Poblacion> AddPoblacion(AddPoblacion viewModel)
    {
        await CheckName(viewModel);

        Poblacion poblacion = new()
        {
            Name = viewModel.Name.Trim(),
            Provincia = await FindProvinciaById(viewModel.ProvinciaId),
            ImageUri = viewModel.ImageUri.Trim()
        };

        try
        {
            await Context.Poblacion.AddAsync(poblacion);

            await Context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            await CheckName(viewModel);
        }

        // Log
        var logData = nameof(poblacion)
                      + " with Id "
                      + poblacion.Id
                      + " was added at "
                      + DateTime.Now.ToShortTimeString();

        logger.LogInformation(logData);

        return poblacion;
    }

    /// <summary>
    ///     Finds All Poblacion
    /// </summary>
    /// <returns>Instance of <see cref="Task{IList{Poblacion}}" /></returns>
    public async Task<IList<Poblacion>> FindAllPoblacion()
    {
        IList<Poblacion> poblaciones = await Context.Poblacion
            .TagWith("FindAllPoblacion")
            .AsNoTracking()
            .AsSplitQuery()
            .Include(x => x.Provincia)
            .ToListAsync();

        return poblaciones;
    }

    /// <summary>
    ///     Finds Paginated Poblacion
    /// </summary>
    /// <param name="viewModel">Injected <see cref="FilterPage" /></param>
    /// <returns>Instance of <see cref="Task{Page{Poblacion}}" /></returns>
    public async Task<Page<Poblacion>> FindPaginatedPoblacion(FilterPage viewModel)
    {
        Page<Poblacion> page = new()
        {
            Length = await Context.Poblacion
                .TagWith("CountAllPoblacion")
                .AsNoTracking()
                .AsSplitQuery()
                .CountAsync(),
            Index = viewModel.Index,
            Size = viewModel.Size,
            Items = await Context.Poblacion
                .TagWith("FindPaginatedPoblacion")
                .AsNoTracking()
                .AsSplitQuery()
                .Include(x => x.Provincia)
                .Skip(viewModel.Index * viewModel.Size)
                .Take(viewModel.Size)
                .ToListAsync()
        };

        return page;
    }

    /// <summary>
    ///     Finds Poblacion By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Poblacion}" /></returns>
    public async Task<Poblacion> FindPoblacionById(int id)
    {
        var poblacion = await Context.Poblacion
            .TagWith("FindPoblacionById")
            .FirstOrDefaultAsync(x => x.Id == id);

        if (poblacion == null)
        {
            // Log
            var logData = nameof(poblacion)
                          + " with Id "
                          + id
                          + " was not found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(poblacion)
                                       + " with Id "
                                       + id
                                       + " does not exist");
        }

        return poblacion;
    }

    /// <summary>
    ///     Finds Provincia By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Provincia}" /></returns>
    public async Task<Provincia> FindProvinciaById(int id)
    {
        var provincia = await Context.Provincia
            .TagWith("FindProvinciaById")
            .FirstOrDefaultAsync(x => x.Id == id);

        if (provincia == null)
        {
            // Log
            var logData = nameof(provincia)
                          + " with Id "
                          + id
                          + " was not found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(provincia)
                                       + " with Id "
                                       + id
                                       + " does not exist");
        }

        return provincia;
    }

    /// <summary>
    ///     Removes Poblacion By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    public async Task RemovePoblacionById(int id)
    {
        try
        {
            var poblacion = await FindPoblacionById(id);

            Context.Poblacion.Remove(poblacion);

            await Context.SaveChangesAsync();

            // Log
            var logData = nameof(poblacion)
                          + " with Id "
                          + poblacion.Id
                          + " was removed at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogInformation(logData);
        }
        catch (DbUpdateConcurrencyException)
        {
            await FindPoblacionById(id);
        }
    }

    /// <summary>
    ///     Updates Poblacion
    /// </summary>
    /// <param name="viewModel">Injected <see cref="UpdatePoblacion" /></param>
    /// <returns>Instance of <see cref="Task{Poblacion}" /></returns>
    public async Task<Poblacion> UpdatePoblacion(UpdatePoblacion viewModel)
    {
        await CheckName(viewModel);

        var poblacion = await FindPoblacionById(viewModel.Id);
        poblacion.Name = viewModel.Name.Trim();
        poblacion.Provincia = await FindProvinciaById(viewModel.ProvinciaId);
        poblacion.ImageUri = viewModel.ImageUri.Trim();

        try
        {
            Context.Poblacion.Update(poblacion);

            await Context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            await CheckName(viewModel);
        }

        // Log
        var logData = nameof(poblacion)
                      + " with Id "
                      + poblacion.Id
                      + " was modified at "
                      + DateTime.Now.ToShortTimeString();

        logger.LogInformation(logData);

        return poblacion;
    }

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <param name="viewModel">Injected <see cref="AddPoblacion" /></param>
    /// <returns>Instance of <see cref="Task{Poblacion}" /></returns>
    public async Task<Poblacion> CheckName(AddPoblacion viewModel)
    {
        var poblacion = await Context.Poblacion
            .AsNoTracking()
            .AsSplitQuery()
            .TagWith("CheckName")
            .FirstOrDefaultAsync(x => x.Name == viewModel.Name.Trim());

        if (poblacion != null)
        {
            // Log
            var logData = nameof(poblacion)
                          + " with Name "
                          + poblacion.Name
                          + " was already found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(poblacion)
                                       + " with Name "
                                       + viewModel.Name
                                       + " already exists");
        }

        return poblacion;
    }

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <param name="viewModel">Injected <see cref="AddPoblacion" /></param>
    /// <returns>Instance of <see cref="Task{Poblacion}" /></returns>
    public async Task<Poblacion> CheckName(UpdatePoblacion viewModel)
    {
        var poblacion = await Context.Poblacion
            .AsNoTracking()
            .AsSplitQuery()
            .TagWith("CheckName")
            .FirstOrDefaultAsync(x => (x.Name == viewModel.Name.Trim()) & (x.Id != viewModel.Id));

        if (poblacion != null)
        {
            // Log
            var logData = nameof(poblacion)
                          + " with Name "
                          + poblacion.Name
                          + " was already found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(poblacion)
                                       + " with Name "
                                       + viewModel.Name
                                       + " already exists");
        }

        return poblacion;
    }
}