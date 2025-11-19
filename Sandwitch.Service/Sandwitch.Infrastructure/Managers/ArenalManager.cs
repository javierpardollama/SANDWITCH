using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sandwitch.Domain.Dtos;
using Sandwitch.Domain.Entities;
using Sandwitch.Domain.Enums;
using Sandwitch.Domain.Exceptions;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.Profiles;
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
    /// <param name="@entity">Injected <see cref="Arenal" /></param>
    /// <returns>Instance of <see cref="Task{ViewArenal}" /></returns>
    public async Task<Arenal> AddArenal(Arenal @entity)
    {
        await CheckName(@entity.Name);

        Arenal arenal = new()
        {
            Name = @entity.Name.Trim(),
            ArenalPoblaciones = [],
            Historicos = []
        };

        try
        {
            await Context.Arenal.AddAsync(arenal);            

            await Context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            await CheckName(@entity.Name);
        }

        // Log
        var logData = nameof(arenal)
                      + " with Id "
                      + arenal.Id
                      + " was added at "
                      + DateTime.Now.ToShortTimeString();

        logger.LogInformation(logData);

        return arenal;
    }

    /// <summary>
    ///     Adds Arenal Poblacion
    /// </summary>
    /// <param name="viewModel">Injected <see cref="AddArenal" /></param>
    /// <param name="entity">Injected <see cref="Arenal" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    public async Task AddArenalPoblacion(List<Poblacion> @poblaciones, Arenal @entity)
    {
        var @arenalPoblaciones = @poblaciones.Select(@poblacion => new ArenalPoblacion()
        {
            Arenal = @entity,
            Poblacion = @poblacion           
        }).ToList();

        await Context.ArenalPoblacion.AddRangeAsync(@arenalPoblaciones);

        await Context.SaveChangesAsync();

        // Log
        string @logData = nameof(ArenalPoblacion)
                          + "s with Ids "
                          + string.Join(",", @arenalPoblaciones.Select(x => x.Id))
                          + " were added at "
                          + DateTime.UtcNow.ToShortTimeString();

        @logger.LogInformation(@logData);
    }

    /// <summary>
    ///     Adds Historico
    /// </summary>
    /// <param name="entity">Injected <see cref="Arenal" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    public async Task AddHistorico(Arenal @entity)
    {
        Historico @historico = new()
        {
            Arenal = @entity,
            Bandera = await FindBanderaById((int)FlagIdentifiers.Amarilla),
            Viento = await FindVientoById((int)WindIdentifiers.Norte),
            BajaMarAlba = DateTime.Now.TimeOfDay,
            BajaMarOcaso = DateTime.Now.TimeOfDay,
            AltaMarAlba = DateTime.Now.TimeOfDay,
            AltaMarOcaso = DateTime.Now.TimeOfDay,
            Temperatura = 20,
            Velocidad = 0
        };

        await Context.Historico.AddAsync(@historico);

        await Context.SaveChangesAsync();

        // Log
        string @logData = nameof(Historico)
                          + "s with Id "
                          + @historico.Id
                          + " were added at "
                          + DateTime.UtcNow.ToShortTimeString();

        @logger.LogInformation(@logData);
    }

    /// <summary>
    /// Finds All Poblacion By Ids
    /// </summary>
    /// <param name="ids">Injected <see cref="ICollection{int}"/></param>
    /// <returns>Instance of <see cref="Task{List{Poblacion}}"/></returns>
    public async Task<List<Poblacion>> FindAllPoblacionByIds(ICollection<int> @ids)
    {
        var @tasks = @ids.Select(@id => FindPoblacionById(@id));
        var @poblaciones = await Task.WhenAll(tasks);
        return [.. @poblaciones];
    }

    /// <summary>
    ///     Finds All Arenal
    /// </summary>
    /// <returns>Instance of <see cref="Task{IList{CatalogDto}}" /></returns>
    public async Task<IList<CatalogDto>> FindAllArenal()
    {
        IList<CatalogDto> @arenales = await Context.Arenal
            .TagWith("FindAllArenal")
            .AsNoTracking()
            .AsSplitQuery()
            .Select(x => x.ToCatalog())
            .ToListAsync();

        return @arenales;
    }

    /// <summary>
    ///     Finds Paginated Arenal
    /// </summary>
    /// <param name="index">Injected <see cref="int" /></param>
    /// <param name="size">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{PageDto{ArenalDto}}" /></returns>
    public async Task<PageDto<ArenalDto>> FindPaginatedArenal(int @index, int @size)
    {
        PageDto<ArenalDto> @page = new()
        {
            Length = await Context.Arenal
                .TagWith("CountAllArenal")
                .AsSplitQuery()
                .AsNoTracking()
                .CountAsync(),
            Index = @index,
            Size = @size,
            Items = await Context.Arenal
                .TagWith("FindPaginatedArenal")
                .AsNoTracking()
                .AsSplitQuery()
                .Include(x => x.ArenalPoblaciones)
                .ThenInclude(x => x.Poblacion)
                .Include(x => x.Historicos)
                .Skip(@index * @size)
                .Take(@size)
                .Select(x => x.ToDto())
                .ToListAsync()
        };

        return @page;
    }

    /// <summary>
    ///     Finds All Historico By Arenal Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{IList{HistoricoDto}}" /></returns>
    public async Task<IList<HistoricoDto>> FindAllHistoricoByArenalId(int id)
    {
        IList<HistoricoDto> @historicos = await Context.Historico
            .TagWith("FindAllHistoricoByArenalId")
            .AsNoTracking()
            .AsSplitQuery()
            .Include(x => x.Arenal)
            .Include(x => x.Bandera)
            .Include(x => x.Viento)
            .Where(x => x.Arenal.Id == id)
            .Select(x => x.ToDto())
            .ToListAsync();

        return @historicos;
    }

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
    ///     Finds Poblacion By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Poblacion}" /></returns>
    public async Task<Poblacion> FindPoblacionById(int id)
    {
        Poblacion @poblacion = await Context.Poblacion
            .TagWith("FindPoblacionById")
            .FirstOrDefaultAsync(x => x.Id == id);

        if (@poblacion == null)
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
                                       + id
                                       + " does not exist");
        }

        return @poblacion;
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
    ///     Removes Arenal By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    public async Task RemoveArenalById(int id)
    {
        try
        {
            Arenal @arenal = await FindArenalById(id);

            Context.Arenal.Remove(@arenal);

            await Context.SaveChangesAsync();

            // Log
            var logData = nameof(Arenal)
                          + " with Id"
                          + @arenal.Id
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
    /// <param name="viewModel">Injected <see cref="Arenal" /></param>
    /// <returns>Instance of <see cref="Task{Arenal}" /></returns>
    public async Task<Arenal> UpdateArenal(Arenal @entity)
    {
        await CheckName(@entity.Id, @entity.Name);

        Arenal @arenal = await FindArenalById(@entity.Id);
        @arenal.Name = @entity.Name.Trim();
        @arenal.ArenalPoblaciones = [];
        @arenal.Historicos = [];

        try
        {
            Context.Arenal.Update(@arenal);           

            await Context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            await CheckName(@entity.Id, @entity.Name);
        }

        // Log
        var logData = nameof(Arenal)
                      + " with Id"
                      + @entity.Id
                      + " was modified at "
                      + DateTime.Now.ToShortTimeString();

        logger.LogInformation(logData);

        return @arenal;
    }   

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <param name="name">Injected <see cref="string" /></param>
    /// <returns>Instance of <see cref="Task{Arenal}" /></returns>
    public async Task<Arenal> CheckName(string @name)
    {
        Arenal @arenal = await Context.Arenal
            .AsNoTracking()
            .AsSplitQuery()
            .TagWith("CheckName")
            .FirstOrDefaultAsync(x => x.Name == @name.Trim());

        if (@arenal != null)
        {
            // Log
            var logData = nameof(Arenal)
                          + " with Name "
                          + @arenal.Name
                          + " was already found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(Arenal)
                                       + " with Name "
                                       + @name
                                       + " already exists");
        }

        return @arenal;
    }

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <param name="name">Injected <see cref="string" /></param>
    /// <returns>Instance of <see cref="Task{Arenal}" /></returns>
    public async Task<Arenal> CheckName(int @id, string @name)
    {
        Arenal @arenal = await Context.Arenal
            .AsNoTracking()
            .AsSplitQuery()
            .TagWith("CheckName")
            .FirstOrDefaultAsync(x => x.Name == @name.Trim() && x.Id != @id);

        if (@arenal != null)
        {
            // Log
            var logData = nameof(Arenal)
                          + " with Name "
                          + @arenal.Name
                          + " was already found at "
                          + DateTime.Now.ToShortTimeString();

            logger.LogError(logData);

            throw new ServiceException(nameof(Arenal)
                                       + " with Name "
                                       + @name
                                       + " already exists");
        }

        return @arenal;
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
    ///     Reloads Arenal By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{ArenalDto}" /></returns>
    public async Task<ArenalDto> ReloadArenalById(int id)
    {
        ArenalDto @dto = await Context.Arenal
            .TagWith("ReloadBanderaById")
            .AsQueryable()
            .AsSplitQuery()
            .Include(x=> x.ArenalPoblaciones)
            .ThenInclude(x=> x.Poblacion)
            .Select(x => x.ToDto())
            .FirstOrDefaultAsync(x => x.Id == id);


        if (@dto is null)
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

        return @dto;
    }
}