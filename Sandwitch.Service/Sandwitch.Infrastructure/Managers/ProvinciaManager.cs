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
    /// <param name="viewModel">Injected <see cref="AddProvincia" /></param>
    /// <returns>Instance of <see cref="Task{Provincia}" /></returns>
    public async Task<Provincia> AddProvincia(AddProvincia viewModel)
    {
        await CheckName(viewModel);

        Provincia @provincia = new()
        {
            Name = viewModel.Name.Trim(),
            ImageUri = viewModel.ImageUri.Trim()
        };

        try
        {
            await Context.Provincia.AddAsync(@provincia);

            await Context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            await CheckName(viewModel);
        }

        // Log
        var logData = nameof(Provincia)
                      + " with Id "
                      + @provincia.Id
                      + " was added at "
                      + DateTime.Now.ToShortTimeString();

        logger.LogInformation(logData);

        return @provincia;
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
    public async Task<Provincia> FindProvinciaById(int id)
    {
        var @provincia = await Context.Provincia
            .TagWith("FindProvinciaById")
            .FirstOrDefaultAsync(x => x.Id == id);

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
                                       + id
                                       + " does not exist");
        }

        return @provincia;
    }

    /// <summary>
    ///     Removes Provincia By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    public async Task RemoveProvinciaById(int id)
    {
        try
        {
            Provincia @provincia = await FindProvinciaById(id);

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
            await FindProvinciaById(id);
        }
    }

    /// <summary>
    ///     Updates Provincia
    /// </summary>
    /// <param name="viewModel">Injected <see cref="UpdateProvincia" /></param>
    /// <returns>Instance of <see cref="Task{ViewProvincia}" /></returns>
    public async Task<Provincia> UpdateProvincia(UpdateProvincia viewModel)
    {
        await CheckName(viewModel);

        Provincia @provincia = await FindProvinciaById(viewModel.Id);
        @provincia.Name = viewModel.Name.Trim();
        @provincia.ImageUri = viewModel.ImageUri.Trim();

        try
        {
            Context.Provincia.Update(@provincia);

            await Context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            await CheckName(viewModel);
        }

        // Log
        var logData = nameof(Provincia)
                      + " with Id "
                      + provincia.Id
                      + " was modified at "
                      + DateTime.Now.ToShortTimeString();

        logger.LogInformation(logData);

        return @provincia;
    }

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <param name="viewModel">Injected <see cref="AddProvincia" /></param>
    /// <returns>Instance of <see cref="Task{Provincia}" /></returns>
    public async Task<Provincia> CheckName(AddProvincia viewModel)
    {
        var @provincia = await Context.Provincia
            .AsNoTracking()
            .AsSplitQuery()
            .TagWith("CheckName")
            .FirstOrDefaultAsync(x => x.Name == viewModel.Name.Trim());

        if (@provincia != null)
        {
            // Log
            var logData = nameof(Provincia)
                          + " with Name "
                          + @provincia.Name
                          + " was already found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(Provincia)
                                       + " with Name "
                                       + viewModel.Name
                                       + " already exists");
        }

        return @provincia;
    }

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <param name="viewModel">Injected <see cref="AddProvincia" /></param>
    /// <returns>Instance of <see cref="Task{Provincia}" /></returns>
    public async Task<Provincia> CheckName(UpdateProvincia viewModel)
    {
        Provincia @provincia = await Context.Provincia
            .AsNoTracking()
            .AsSplitQuery()
            .TagWith("CheckName")
            .FirstOrDefaultAsync(x => x.Name == viewModel.Name.Trim() && x.Id != viewModel.Id);

        if (@provincia != null)
        {
            // Log
            var logData = nameof(Provincia)
                          + " with Name "
                          + provincia.Name
                          + " was already found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(Provincia)
                                       + " with Name "
                                       + viewModel.Name
                                       + " already exists");
        }

        return @provincia;
    }
}