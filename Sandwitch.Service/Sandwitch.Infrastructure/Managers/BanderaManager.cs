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
    /// <returns>Instance of <see cref="Task{IList{CatalogDto}}" /></returns>
    public async Task<IList<CatalogDto>> FindAllBandera()
    {
        IList<CatalogDto> @banderas = await Context.Bandera
            .TagWith("FindAllBandera")
            .AsNoTracking()
            .AsSplitQuery()
            .Select(x => x.ToCatalog())
            .ToListAsync();

        return @banderas;
    }

    /// <summary>
    ///     Finds Paginated Bandera
    /// </summary>
    /// <param name="index">Injected <see cref="int" /></param>
    /// <param name="size">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{PageDto{BanderaDto}}" /></returns>
    public async Task<PageDto<BanderaDto>> FindPaginatedBandera(int @index, int @size)
    {
        PageDto<BanderaDto> @page = new()
        {
            Length = await Context.Bandera
                .TagWith("CountAllBandera")
                .AsNoTracking()
                .AsSplitQuery()
                .CountAsync(),
            Index = @index,
            Size = @size,
            Items = await Context.Bandera
                .TagWith("FindPaginatedBandera")
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
    /// <returns>Instance of <see cref="Task{IList{HistoricoDto}}" /></returns>
    public async Task<IList<HistoricoDto>> FindAllHistoricoByBanderaId(int id)
    {
        IList<HistoricoDto> @historicos = await Context.Historico
            .TagWith("FindAllHistoricoByBanderaId")
            .AsNoTracking()
            .AsSplitQuery()
            .Include(x => x.Arenal)
            .Include(x => x.Bandera)
            .Where(x => x.Bandera.Id == id)
            .Select(x=> x.ToDto())
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
    /// <param name="name">Injected <see cref="string" /></param>
    /// <returns>Instance of <see cref="Task{Bandera}" /></returns>
    public async Task<Bandera> CheckName(string @name)
    {
        Bandera @bandera = await Context.Bandera
            .TagWith("CheckName")
            .AsNoTracking()
            .AsSplitQuery()
            .FirstOrDefaultAsync(x => x.Name == @name.Trim());

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
    public async Task<Bandera> CheckName(int @id, string @name)
    {
        Bandera @bandera = await Context.Bandera
            .TagWith("CheckName")
            .AsNoTracking()
            .AsSplitQuery()
            .FirstOrDefaultAsync(x => x.Name == @name.Trim() && x.Id != @id);

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
                                       + @name
                                       + " already exists");
        }

        return @bandera;
    }
}