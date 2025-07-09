using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sandwitch.Domain.Entities;
using Sandwitch.Domain.Enums;
using Sandwitch.Domain.Exceptions;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Additions;
using Sandwitch.Domain.ViewModels.Filters;
using Sandwitch.Domain.ViewModels.Updates;
using Sandwitch.Infrastructure.Contexts.Interfaces;

namespace Sandwitch.Infrastructure.Managers;

/// <summary>
///     Represents a <see cref="ArenalManager" /> class. Inherits <see cref="BaseManager" />. Implements
///     <see cref="IArenalManager" />
/// </summary>
/// <param name="context">Injected <see cref="IApplicationContext" /></param>
/// <param name="logger">Injected <see cref="ILogger{ArenalManager}" /></param>
public class ArenalManager(
    IApplicationContext context,
    ILogger<ArenalManager> logger) : BaseManager(context), IArenalManager
{
    /// <summary>
    ///     Adds Arenal
    /// </summary>
    /// <param name="viewModel">Injected <see cref="AddArenal" /></param>
    /// <returns>Instance of <see cref="Task{ViewArenal}" /></returns>
    public async Task<Arenal> AddArenal(AddArenal viewModel)
    {
        await CheckName(viewModel);

        Arenal arenal = new()
        {
            Name = viewModel.Name.Trim(),
            ArenalPoblaciones = new List<ArenalPoblacion>(),
            Historicos = new List<Historico>()
        };

        try
        {
            await Context.Arenal.AddAsync(arenal);

            AddArenalPoblacion(viewModel, arenal);

            await AddHistorico(arenal);

            await Context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            await CheckName(viewModel);
        }

        // Log
        var logData = nameof(arenal)
                      + " with Id "
                      + arenal.Id
                      + " was added at "
                      + DateTime.Now.ToShortTimeString();

        logger.LogInformation(logData);

        return arenal;
        ;
    }

    /// <summary>
    ///     Adds Arenal Poblacion
    /// </summary>
    /// <param name="viewModel">Injected <see cref="AddArenal" /></param>
    /// <param name="entity">Injected <see cref="Arenal" /></param>
    public void AddArenalPoblacion(AddArenal viewModel,
        Arenal entity)
    {
        viewModel.PoblacionesId.AsQueryable().ToList().ForEach(async x =>
        {
            var poblacion = await FindPoblacionById(x);

            ArenalPoblacion arenalPoblacion = new()
            {
                Arenal = entity,
                Poblacion = poblacion
            };

            entity.ArenalPoblaciones.Add(arenalPoblacion);
        });
    }

    /// <summary>
    ///     Adds Historico
    /// </summary>
    /// <param name="entity">Injected <see cref="Arenal" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    public async Task AddHistorico(Arenal entity)
    {
        Historico historico = new()
        {
            Arenal = entity,
            Bandera = await FindBanderaById((int)FlagIdentifiers.Amarilla),
            Viento = await FindVientoById((int)WindIdentifiers.Norte),
            BajaMarAlba = DateTime.Now.TimeOfDay,
            BajaMarOcaso = DateTime.Now.TimeOfDay,
            AltaMarAlba = DateTime.Now.TimeOfDay,
            AltaMarOcaso = DateTime.Now.TimeOfDay,
            Temperatura = 20,
            Velocidad = 0
        };
        entity.Historicos.Add(historico);
    }

    /// <summary>
    ///     Finds All Arenal
    /// </summary>
    /// <returns>Instance of <see cref="Task{IList{Arenal}}" /></returns>
    public async Task<IList<Arenal>> FindAllArenal()
    {
        IList<Arenal> arenales = await Context.Arenal
            .TagWith("FindAllArenal")
            .AsNoTracking()
            .AsSplitQuery()
            .Include(x => x.ArenalPoblaciones)
            .ThenInclude(x => x.Poblacion)
            .Include(x => x.Historicos)
            .ToListAsync();

        return arenales;
    }

    /// <summary>
    ///     Finds Paginated Arenal
    /// </summary>
    /// <param name="viewModel">Injected <see cref="FilterPage" /></param>
    /// <returns>Instance of <see cref="Task{Page{Arenal}}" /></returns>
    public async Task<Page<Arenal>> FindPaginatedArenal(FilterPage viewModel)
    {
        Page<Arenal> page = new()
        {
            Length = await Context.Arenal
                .TagWith("CountAllArenal")
                .AsSplitQuery()
                .AsNoTracking()
                .CountAsync(),
            Index = viewModel.Index,
            Size = viewModel.Size,
            Items = await Context.Arenal
                .TagWith("FindPaginatedArenal")
                .AsNoTracking()
                .AsSplitQuery()
                .Include(x => x.ArenalPoblaciones)
                .ThenInclude(x => x.Poblacion)
                .Include(x => x.Historicos)
                .Skip(viewModel.Index * viewModel.Size)
                .Take(viewModel.Size)
                .ToListAsync()
        };

        return page;
    }

    /// <summary>
    ///     Finds All Historico By Arenal Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{IList{ViewHistorico}}" /></returns>
    public async Task<IList<Historico>> FindAllHistoricoByArenalId(int id)
    {
        IList<Historico> historicos = await Context.Historico
            .TagWith("FindAllHistoricoByArenalId")
            .AsNoTracking()
            .AsSplitQuery()
            .Include(x => x.Arenal)
            .Include(x => x.Bandera)
            .Include(x => x.Viento)
            .Where(x => x.Arenal.Id == id)
            .ToListAsync();

        return historicos;
    }

    /// <summary>
    ///     Finds Arenal By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Arenal}" /></returns>
    public async Task<Arenal> FindArenalById(int id)
    {
        var arenal = await Context.Arenal
            .TagWith("FindArenalById")
            .AsQueryable()
            .AsSplitQuery()
            .Include(x => x.ArenalPoblaciones)
            .ThenInclude(x => x.Poblacion)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (arenal == null)
        {
            // Log
            var logData = nameof(arenal)
                          + " with Id "
                          + id
                          + " was not found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(arenal)
                                       + " with Id "
                                       + id
                                       + " does not exist");
        }

        return arenal;
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
    ///     Finds Bandera By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Bandera}" /></returns>
    public async Task<Bandera> FindBanderaById(int id)
    {
        var bandera = await Context.Bandera
            .TagWith("FindBanderaById")
            .FirstOrDefaultAsync(x => x.Id == id);

        if (bandera == null)
        {
            // Log
            var logData = nameof(bandera)
                          + " with Id "
                          + id
                          + " was not found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(bandera)
                                       + " with Id "
                                       + id
                                       + " does not exist");
        }

        return bandera;
    }

    /// <summary>
    ///     Removes Arenal By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    public async Task RemoveArenalById(int id)
    {
        try
        {
            var arenal = await FindArenalById(id);

            Context.Arenal.Remove(arenal);

            await Context.SaveChangesAsync();

            // Log
            var logData = nameof(arenal)
                          + " with Id"
                          + arenal.Id
                          + " was removed at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogInformation(logData);
        }
        catch (DbUpdateConcurrencyException)
        {
            await FindArenalById(id);
        }
    }

    /// <summary>
    ///     Updates Arenal
    /// </summary>
    /// <param name="viewModel">Injected <see cref="UpdateArenal" /></param>
    /// <returns>Instance of <see cref="Task{Arenal}" /></returns>
    public async Task<Arenal> UpdateArenal(UpdateArenal viewModel)
    {
        await CheckName(viewModel);

        var arenal = await FindArenalById(viewModel.Id);
        arenal.Name = viewModel.Name.Trim();
        arenal.ArenalPoblaciones = new List<ArenalPoblacion>();
        arenal.Historicos = new List<Historico>();

        try
        {
            Context.Arenal.Update(arenal);

            UpdateArenalPoblacion(viewModel, arenal);

            await UpdateHistorico(arenal);

            await Context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            await CheckName(viewModel);
        }

        // Log
        var logData = nameof(arenal)
                      + " with Id"
                      + arenal.Id
                      + " was modified at "
                      + DateTime.Now.ToShortTimeString();

        logger.LogInformation(logData);

        return arenal;
        ;
    }

    /// <summary>
    ///     Updates Arenal Poblacion
    /// </summary>
    /// <param name="viewModel">Injected <see cref="UpdateArenal" /></param>
    /// <param name="entity">Injected <see cref="Arenal" /></param>
    public void UpdateArenalPoblacion(UpdateArenal viewModel, Arenal entity)
    {
        viewModel.PoblacionesId.AsQueryable().ToList().ForEach(async x =>
        {
            var poblacion = await FindPoblacionById(x);

            ArenalPoblacion arenalPoblacion = new()
            {
                Arenal = entity,
                Poblacion = poblacion
            };

            entity.ArenalPoblaciones.Add(arenalPoblacion);
        });
    }

    /// <summary>
    ///     Updates Historico
    /// </summary>
    /// <param name="entity">Injected <see cref="Arenal" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    public async Task UpdateHistorico(Arenal entity)
    {
        Historico historico = new()
        {
            Arenal = entity,
            Bandera = await FindBanderaById((int)FlagIdentifiers.Amarilla),
            Viento = await FindVientoById((int)WindIdentifiers.Norte),
            BajaMarAlba = DateTime.Now.TimeOfDay,
            BajaMarOcaso = DateTime.Now.TimeOfDay,
            AltaMarAlba = DateTime.Now.TimeOfDay,
            AltaMarOcaso = DateTime.Now.TimeOfDay,
            Temperatura = 20,
            Velocidad = 0
        };
        entity.Historicos.Add(historico);
    }

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <param name="viewModel">Injected <see cref="AddArenal" /></param>
    /// <returns>Instance of <see cref="Task{Arenal}" /></returns>
    public async Task<Arenal> CheckName(AddArenal viewModel)
    {
        var arenal = await Context.Arenal
            .AsNoTracking()
            .AsSplitQuery()
            .TagWith("CheckName")
            .FirstOrDefaultAsync(x => x.Name == viewModel.Name.Trim());

        if (arenal != null)
        {
            // Log
            var logData = nameof(arenal)
                          + " with Name "
                          + arenal.Name
                          + " was already found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(arenal)
                                       + " with Name "
                                       + viewModel.Name
                                       + " already exists");
        }

        return arenal;
    }

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <param name="viewModel">Injected <see cref="UpdateArenal" /></param>
    /// <returns>Instance of <see cref="Task{Arenal}" /></returns>
    public async Task<Arenal> CheckName(UpdateArenal viewModel)
    {
        var arenal = await Context.Arenal
            .AsNoTracking()
            .AsSplitQuery()
            .TagWith("CheckName")
            .FirstOrDefaultAsync(x => x.Name == viewModel.Name.Trim() && x.Id != viewModel.Id);

        if (arenal != null)
        {
            // Log
            var logData = nameof(arenal)
                          + " with Name "
                          + arenal.Name
                          + " was already found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(arenal)
                                       + " with Name "
                                       + viewModel.Name
                                       + " already exists");
        }

        return arenal;
    }

    /// <summary>
    ///     Finds Viento By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Viento}" /></returns>
    public async Task<Viento> FindVientoById(int id)
    {
        var viento = await Context.Viento
            .TagWith("FindVientoById")
            .FirstOrDefaultAsync(x => x.Id == id);

        if (viento == null)
        {
            // Log
            var logData = nameof(viento)
                          + " with Id "
                          + id
                          + " was not found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(viento)
                                       + " with Id "
                                       + id
                                       + " does not exist");
        }

        return viento;
    }
}