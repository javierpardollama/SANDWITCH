using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sandwitch.Domain.Entities;
using Sandwitch.Domain.Exceptions;
using Sandwitch.Domain.Managers;
using Sandwitch.Infrastructure.Contexts.Interfaces;

namespace Sandwitch.Infrastructure.Managers;

/// <summary>
///     Represents a <see cref="HistoricoManager" /> class. Inherits <see cref="BaseManager" />. Implements
///     <see cref="IHistoricoManager" />
/// </summary>
/// <param name="context">Injected <see cref="IApplicationContext" /></param>
/// <param name="logger">Injected <see cref="ILogger{HistoricoManager}" /></param>
public class HistoricoManager(
    IApplicationContext context,
    ILogger<HistoricoManager> logger) : BaseManager(context), IHistoricoManager
{
    /// <summary>
    ///     Finds Arenal By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Arenal}" /></returns>
    public async Task<Arenal> FindArenalById(int id)
    {
        Arenal @arenal = await Context.Arenal
            .TagWith("FindArenalById")
            .AsQueryable()
            .AsSplitQuery()
            .Include(x => x.ArenalPoblaciones)
            .ThenInclude(x => x.Poblacion)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (@arenal == null)
        {
            // Log
            var logData = nameof(Arenal)
                          + " with Id "
                          + id
                          + " was not found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(Arenal)
                                       + " with Id "
                                       + id
                                       + " does not exist");
        }

        return @arenal;
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
    ///     Adds Historico
    /// </summary>
    /// <param name="viewModel">Injected <see cref="AddHistorico" /></param>
    /// <returns>Instance of <see cref="Task{Historico}" /></returns>
    public async Task<Historico> AddHistorico(AddHistorico viewModel)
    {
        Historico @historico = new()
        {
            Arenal = await FindArenalById(viewModel.ArenalId),
            Bandera = await FindBanderaById(viewModel.BanderaId),
            Viento = await FindVientoById(viewModel.VientoId),
            Velocidad = viewModel.Velocidad,
            BajaMarAlba = viewModel.BajaMarAlba,
            BajaMarOcaso = viewModel.BajaMarOcaso,
            AltaMarAlba = viewModel.AltaMarAlba,
            AltaMarOcaso = viewModel.AltaMarOcaso,
            Temperatura = viewModel.Temperatura
        };

        Context.Historico.Add(@historico);

        await Context.SaveChangesAsync();

        // Log
        var logData = nameof(Historico)
                      + " with Id "
                      + @historico.Id
                      + " was added at "
                      + DateTime.Now.ToShortTimeString();

        logger.LogInformation(logData);

        return @historico;
    }

    /// <summary>
    ///     Finds Viento By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Viento}" /></returns>
    public async Task<Viento> FindVientoById(int id)
    {
        Viento @viento = await Context.Viento
            .TagWith("FindVientoById")
            .FirstOrDefaultAsync(x => x.Id == id);

        if (@viento == null)
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

        return @viento;
    }
}