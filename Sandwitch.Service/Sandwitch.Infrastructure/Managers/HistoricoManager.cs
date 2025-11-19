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
    /// <param name="entity">Injected <see cref="Historico" /></param>
    /// <returns>Instance of <see cref="Task{Historico}" /></returns>
    public async Task<Historico> AddHistorico(Historico @entity)
    {
        Historico @historico = new()
        {
            Arenal = await FindArenalById(@entity.ArenalId),
            Bandera = await FindBanderaById(@entity.BanderaId),
            Viento = await FindVientoById(@entity.VientoId),
            Velocidad = @entity.Velocidad,
            BajaMarAlba = @entity.BajaMarAlba,
            BajaMarOcaso = @entity.BajaMarOcaso,
            AltaMarAlba = @entity.AltaMarAlba,
            AltaMarOcaso = @entity.AltaMarOcaso,
            Temperatura = @entity.Temperatura
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

    /// <summary>
    ///     Reloads Historico By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{HistoricoDto}" /></returns>
    public async Task<HistoricoDto> ReloadHistoricoById(int id)
    {
        HistoricoDto @dto = await Context.Historico
            .TagWith("ReloadHistoricoById")
            .AsQueryable()
            .AsSplitQuery()
            .Include(x => x.Arenal)
            .Include(x => x.Viento)
            .Include(x => x.Bandera)
            .Select(x => x.ToDto())
            .FirstOrDefaultAsync(x => x.Id == id);
            

        if (@dto is null)
        {
            // Log
            var logData = nameof(Historico)
                          + " with Id "
                          + id
                          + " was not found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(Historico)
                                       + " with Id "
                                       + id
                                       + " does not exist");
        }

        return @dto;
    }
}