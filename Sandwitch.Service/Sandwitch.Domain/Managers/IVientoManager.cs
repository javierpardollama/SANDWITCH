using Sandwitch.Domain.Dtos;
using Sandwitch.Domain.Entities;

namespace Sandwitch.Domain.Managers;

/// <summary>
///     Represents a <see cref="IVientoManager" /> interface. Inherits <see cref="IBaseManager" />
/// </summary>
public interface IVientoManager : IBaseManager
{
    /// <summary>
    ///     Finds All Viento
    /// </summary>
    /// <returns>Instance of <see cref="Task{IList{CatalogDto}}" /></returns>
    public Task<IList<CatalogDto>> FindAllViento();

    /// <summary>
    ///     Finds Paginated Viento
    /// </summary>
    /// <param name="index">Injected <see cref="int" /></param>
    /// <param name="size">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{PageDto{VientoDto}}" /></returns>
    public Task<PageDto<VientoDto>> FindPaginatedViento(int @index, int @size);

    /// <summary>
    ///     Finds All Historico By Poblacion Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{IList{HistoricoDto}}" /></returns>
    public Task<IList<HistoricoDto>> FindAllHistoricoByVientoId(int @id);

    /// <summary>
    ///     Finds Viento By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Viento}" /></returns>
    public Task<Viento> FindVientoById(int @id);

    /// <summary>
    ///     Removes Viento By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    public Task RemoveVientoById(int @id);

    /// <summary>
    ///     Updates Viento
    /// </summary>
    /// <param name="entity">Injected <see cref="Viento" /></param>
    /// <returns>Instance of <see cref="Task{Viento}" /></returns>
    public Task<Viento> UpdateViento(Viento @entity);

    /// <summary>
    ///     Adds Viento
    /// </summary>
    /// <param name="entity">Injected <see cref="Viento" /></param>
    /// <returns>Instance of <see cref="Task{Viento}" /></returns>
    public Task<Viento> AddViento(Viento @entity);

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <param name="name">Injected <see cref="string" /></param>
    /// <returns>Instance of <see cref="Task{bool}" /></returns>
    public Task<bool> CheckName(string @name);

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <param name="name">Injected <see cref="string" /></param>
    /// <returns>Instance of <see cref="Task{bool}" /></returns>
    public Task<bool> CheckName(int @id, string @name);

    /// <summary>
    ///     Reloads Viento By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{VientoDto}" /></returns>
    public Task<VientoDto> ReloadVientoById(int @id);
}