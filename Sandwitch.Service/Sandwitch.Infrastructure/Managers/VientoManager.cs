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
    /// <param name="viewModel">Injected <see cref="AddViento" /></param>
    /// <returns>Instance of <see cref="Task{Viento}" /></returns>
    public async Task<Viento> AddViento(AddViento viewModel)
    {
        await CheckName(viewModel);

        Viento Viento = new()
        {
            Name = viewModel.Name.Trim(),
            ImageUri = viewModel.ImageUri.Trim()
        };

        try
        {
            await Context.Viento.AddAsync(Viento);

            await Context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            await CheckName(viewModel);
        }

        // Log
        var logData = nameof(Viento)
                      + " with Id "
                      + Viento.Id
                      + " was added at "
                      + DateTime.Now.ToShortTimeString();

        logger.LogInformation(logData);

        return Viento;
    }

    /// <summary>
    ///     Finds All Viento
    /// </summary>
    /// <returns>Instance of <see cref="Task{IList{Viento}}" /></returns>
    public async Task<IList<Viento>> FindAllViento()
    {
        IList<Viento> Vientos = await Context.Viento
            .TagWith("FindAllViento")
            .AsNoTracking()
            .AsSplitQuery()
            .ToListAsync();

        return Vientos;
    }

    /// <summary>
    ///     Finds Paginated Viento
    /// </summary>
    /// <param name="viewModel">Injected <see cref="FilterPage" /></param>
    /// <returns>Instance of <see cref="Task{Page{Viento}}" /></returns>
    public async Task<Page<Viento>> FindPaginatedViento(FilterPage viewModel)
    {
        Page<Viento> page = new()
        {
            Length = await Context.Viento
                .TagWith("CountAllViento")
                .AsNoTracking()
                .AsSplitQuery()
                .CountAsync(),
            Index = viewModel.Index,
            Size = viewModel.Size,
            Items = await Context.Viento
                .TagWith("FindPaginatedViento")
                .AsNoTracking()
                .AsSplitQuery()
                .Skip(viewModel.Index * viewModel.Size)
                .Take(viewModel.Size)
                .ToListAsync()
        };

        return page;
    }

    /// <summary>
    ///     Finds All Historico By Poblacion Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="IList{Historico}" /></returns>
    public async Task<IList<Historico>> FindAllHistoricoByVientoId(int id)
    {
        IList<Historico> historicos = await Context.Historico
            .TagWith("FindAllHistoricoByVientoId")
            .AsNoTracking()
            .AsSplitQuery()
            .Include(x => x.Arenal)
            .Include(x => x.Viento)
            .Where(x => x.Viento.Id == id)
            .ToListAsync();

        return historicos;
    }

    /// <summary>
    ///     Finds Viento By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Viento}" /></returns>
    public async Task<Viento> FindVientoById(int id)
    {
        var Viento = await Context.Viento
            .TagWith("FindVientoById")
            .FirstOrDefaultAsync(x => x.Id == id);

        if (Viento == null)
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

        return Viento;
    }

    /// <summary>
    ///     Removes Viento By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    public async Task RemoveVientoById(int id)
    {
        try
        {
            var Viento = await FindVientoById(id);

            Context.Viento.Remove(Viento);

            await Context.SaveChangesAsync();

            // Log
            var logData = nameof(Viento)
                          + " with Id "
                          + Viento.Id
                          + " was removed at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogInformation(logData);
        }
        catch (DbUpdateConcurrencyException)
        {
            await FindVientoById(id);
        }
    }

    /// <summary>
    ///     Updates Viento
    /// </summary>
    /// <param name="viewModel">Injected <see cref="UpdateViento" /></param>
    /// <returns>Instance of <see cref="Task{Viento}" /></returns>
    public async Task<Viento> UpdateViento(UpdateViento viewModel)
    {
        await CheckName(viewModel);

        var Viento = await FindVientoById(viewModel.Id);
        Viento.Name = viewModel.Name.Trim();
        Viento.ImageUri = viewModel.ImageUri.Trim();

        try
        {
            Context.Viento.Update(Viento);

            await Context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            await CheckName(viewModel);
        }

        // Log
        var logData = nameof(Viento)
                      + " with Id "
                      + Viento.Id
                      + " was modified at "
                      + DateTime.Now.ToShortTimeString();

        logger.LogInformation(logData);

        return Viento;
    }

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <param name="viewModel">Injected <see cref="AddViento" /></param>
    /// <returns>Instance of <see cref="Task{Viento}" /></returns>
    public async Task<Viento> CheckName(AddViento viewModel)
    {
        var Viento = await Context.Viento
            .TagWith("CheckName")
            .AsNoTracking()
            .AsSplitQuery()
            .FirstOrDefaultAsync(x => x.Name == viewModel.Name.Trim());

        if (Viento != null)
        {
            // Log
            var logData = nameof(Viento)
                          + " with Name "
                          + Viento.Name
                          + " was already found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(Viento)
                                       + " with Name "
                                       + viewModel.Name
                                       + " already exists");
        }

        return Viento;
    }

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <param name="viewModel">Injected <see cref="UpdateViento" /></param>
    /// <returns>Instance of <see cref="Task{Viento}" /></returns>
    public async Task<Viento> CheckName(UpdateViento viewModel)
    {
        var Viento = await Context.Viento
            .TagWith("CheckName")
            .AsNoTracking()
            .AsSplitQuery()
            .FirstOrDefaultAsync(x => x.Name == viewModel.Name.Trim() && x.Id != viewModel.Id);

        if (Viento != null)
        {
            // Log
            var logData = nameof(Viento)
                          + " with Name "
                          + Viento.Name
                          + " was already found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(Viento)
                                       + " with Name "
                                       + viewModel.Name
                                       + " already exists");
        }

        return Viento;
    }
}