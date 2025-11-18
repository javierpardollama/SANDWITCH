using Sandwitch.Domain.Dtos;
using Sandwitch.Domain.Entities;

namespace Sandwitch.Domain.Managers;

/// <summary>
///     Represents a <see cref="IPoblacionManager" /> interface. Inherits <see cref="IBaseManager" />
/// </summary>
public interface IPoblacionManager : IBaseManager
{
    /// <summary>
    ///     Finds All Poblacion
    /// </summary>
    /// <returns>Instance of <see cref="Task{IList{CatalogDto}}" /></returns>
    public Task<IList<CatalogDto>> FindAllPoblacion();

    /// <summary>
    ///     Finds Paginated Poblacion
    /// </summary>
    /// <param name="index">Injected <see cref="int" /></param>
    /// <param name="size">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{PageDto{PoblacionDto}}" /></returns>
    public Task<PageDto<PoblacionDto>> FindPaginatedPoblacion(int @index, int @size);

    /// <summary>
    ///     Finds Poblacion By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Poblacion}" /></returns>
    public Task<Poblacion> FindPoblacionById(int @id);

    /// <summary>
    ///     Finds Provincia By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Provincia}" /></returns>
    public Task<Provincia> FindProvinciaById(int @id);

    /// <summary>
    ///     Removes Poblacion By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    public Task RemovePoblacionById(int @id);

    /// <summary>
    ///     Updates Poblacion
    /// </summary>
    /// <param name="entity">Injected <see cref="Poblacion" /></param>
    /// <returns>Instance of <see cref="Task{Poblacion}" /></returns>
    public Task<Poblacion> UpdatePoblacion(Poblacion @entity);

    /// <summary>
    ///     Adds Poblacion
    /// </summary>
    /// <param name="entity">Injected <see cref="Poblacion" /></param>
    /// <returns>Instance of <see cref="Task{Poblacion}" /></returns>
    public Task<Poblacion> AddPoblacion(Poblacion entity);

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <param name="name">Injected <see cref="string" /></param>
    /// <returns>Instance of <see cref="Task{Poblacion}" /></returns>
    Task<Poblacion> CheckName(string @name);

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <param name="name">Injected <see cref="string" /></param>
    /// <returns>Instance of <see cref="Task{Poblacion}" /></returns>
    Task<Poblacion> CheckName(int @id, string @name);


    /// <summary>
    ///     Reloads Poblacion By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{ArenalDto}" /></returns>
    public Task<PoblacionDto> ReloadPoblacionById(int @id);
}