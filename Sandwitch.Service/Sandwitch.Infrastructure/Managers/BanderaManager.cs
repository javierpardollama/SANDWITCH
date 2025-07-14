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
///     Represents a <see cref="BanderaManager" /> class. Inherits <see cref="BaseManager" />. Implements
///     <see cref="IBanderaManager" />
/// </summary>
/// <param name="context">Injected <see cref="IApplicationContext" /></param>
/// <param name="logger">Injected <see cref="ILogger{BanderaManager}" /></param>
public class BanderaManager(
    IApplicationContext context,
    ILogger<BanderaManager> logger) : BaseManager(context), IBanderaManager
{
    /// <summary>
    ///     Adds Bandera
    /// </summary>
    /// <param name="viewModel">Injected <see cref="AddBandera" /></param>
    /// <returns>Instance of <see cref="Task{Bandera}" /></returns>
    public async Task<Bandera> AddBandera(AddBandera viewModel)
    {
        await CheckName(viewModel);

        Bandera bandera = new()
        {
            Name = viewModel.Name.Trim(),
            ImageUri = viewModel.ImageUri.Trim()
        };

        try
        {
            await Context.Bandera.AddAsync(bandera);

            await Context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            await CheckName(viewModel);
        }

        // Log
        var logData = nameof(bandera)
                      + " with Id "
                      + bandera.Id
                      + " was added at "
                      + DateTime.Now.ToShortTimeString();

        logger.LogInformation(logData);

        return bandera;
    }

    /// <summary>
    ///     Finds All Bandera
    /// </summary>
    /// <returns>Instance of <see cref="Task{IList{ViewBandera}}" /></returns>
    public async Task<IList<Bandera>> FindAllBandera()
    {
        IList<Bandera> @banderas = await Context.Bandera
            .TagWith("FindAllBandera")
            .AsNoTracking()
            .AsSplitQuery()
            .ToListAsync();

        return @banderas;
    }

    /// <summary>
    ///     Finds Paginated Bandera
    /// </summary>
    /// <param name="viewModel">Injected <see cref="FilterPage" /></param>
    /// <returns>Instance of <see cref="Task{Page{Bandera}}" /></returns>
    public async Task<Page<Bandera>> FindPaginatedBandera(FilterPage viewModel)
    {
        Page<Bandera> @page = new()
        {
            Length = await Context.Bandera
                .TagWith("CountAllBandera")
                .AsNoTracking()
                .AsSplitQuery()
                .CountAsync(),
            Index = viewModel.Index,
            Size = viewModel.Size,
            Items = await Context.Bandera
                .TagWith("FindPaginatedBandera")
                .AsNoTracking()
                .AsSplitQuery()
                .Skip(viewModel.Index * viewModel.Size)
                .Take(viewModel.Size)
                .ToListAsync()
        };

        return @page;
    }

    /// <summary>
    ///     Finds All Historico By Poblacion Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="IList{ViewHistorico}" /></returns>
    public async Task<IList<Historico>> FindAllHistoricoByBanderaId(int id)
    {
        IList<Historico> @historicos = await Context.Historico
            .TagWith("FindAllHistoricoByBanderaId")
            .AsNoTracking()
            .AsSplitQuery()
            .Include(x => x.Arenal)
            .Include(x => x.Bandera)
            .Where(x => x.Bandera.Id == id)
            .ToListAsync();

        return @historicos;
    }

    /// <summary>
    ///     Finds Bandera By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Bandera}" /></returns>
    public async Task<Bandera> FindBanderaById(int id)
    {
        Bandera @bandera = await Context.Bandera
            .TagWith("FindBanderaById")
            .FirstOrDefaultAsync(x => x.Id == id);

        if (@bandera == null)
        {
            // Log
            var logData = nameof(Bandera)
                          + " with Id "
                          + id
                          + " was not found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(Bandera)
                                       + " with Id "
                                       + id
                                       + " does not exist");
        }

        return @bandera;
    }

    /// <summary>
    ///     Removes Bandera By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    public async Task RemoveBanderaById(int id)
    {
        try
        {
            Bandera @bandera = await FindBanderaById(id);

            Context.Bandera.Remove(@bandera);

            await Context.SaveChangesAsync();

            // Log
            var logData = nameof(Bandera)
                          + " with Id "
                          + @bandera.Id
                          + " was removed at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogInformation(logData);
        }
        catch (DbUpdateConcurrencyException)
        {
            await FindBanderaById(id);
        }
    }

    /// <summary>
    ///     Updates Bandera
    /// </summary>
    /// <param name="viewModel">Injected <see cref="UpdateBandera" /></param>
    /// <returns>Instance of <see cref="Task{Bandera}" /></returns>
    public async Task<Bandera> UpdateBandera(UpdateBandera viewModel)
    {
        await CheckName(viewModel);

        Bandera @bandera = await FindBanderaById(viewModel.Id);
        @bandera.Name = viewModel.Name.Trim();
        @bandera.ImageUri = viewModel.ImageUri.Trim();

        try
        {
            Context.Bandera.Update(@bandera);

            await Context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            await CheckName(viewModel);
        }

        // Log
        var logData = nameof(Bandera)
                      + " with Id "
                      + bandera.Id
                      + " was modified at "
                      + DateTime.Now.ToShortTimeString();

        logger.LogInformation(logData);

        return @bandera;
    }

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <param name="viewModel">Injected <see cref="AddBandera" /></param>
    /// <returns>Instance of <see cref="Task{Bandera}" /></returns>
    public async Task<Bandera> CheckName(AddBandera viewModel)
    {
        Bandera @bandera = await Context.Bandera
            .TagWith("CheckName")
            .AsNoTracking()
            .AsSplitQuery()
            .FirstOrDefaultAsync(x => x.Name == viewModel.Name.Trim());

        if (@bandera != null)
        {
            // Log
            var logData = nameof(Bandera)
                          + " with Name "
                          + @bandera.Name
                          + " was already found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(Bandera)
                                       + " with Name "
                                       + viewModel.Name
                                       + " already exists");
        }

        return @bandera;
    }

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <param name="viewModel">Injected <see cref="UpdateBandera" /></param>
    /// <returns>Instance of <see cref="Task{Bandera}" /></returns>
    public async Task<Bandera> CheckName(UpdateBandera viewModel)
    {
        Bandera @bandera = await Context.Bandera
            .TagWith("CheckName")
            .AsNoTracking()
            .AsSplitQuery()
            .FirstOrDefaultAsync(x => x.Name == viewModel.Name.Trim() && x.Id != viewModel.Id);

        if (@bandera != null)
        {
            // Log
            var logData = nameof(Bandera)
                          + " with Name "
                          + @bandera.Name
                          + " was already found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(Bandera)
                                       + " with Name "
                                       + viewModel.Name
                                       + " already exists");
        }

        return @bandera;
    }
}