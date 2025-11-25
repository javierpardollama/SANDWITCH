using Sandwitch.Domain.Dtos;
using Sandwitch.Domain.Entities;

namespace Sandwitch.Domain.Managers;

/// <summary>
///     Represents a <see cref="IProvinciaManager" /> interface. Inherits <see cref="IBaseManager" />
/// </summary>
public interface IProvinciaManager : IBaseManager
{
    /// <summary>
    ///     Finds All Provincia
    /// </summary>
    /// <returns>Instance of <see cref="Task{IList{CatalogDto}}" /></returns>
    public Task<IList<CatalogDto>> FindAllProvincia();

    /// <summary>
    ///     Finds Paginated Provincia
    /// </summary>
    /// <param name="index">Injected <see cref="int" /></param>
    /// <param name="size">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{PageDto{ProvinciaDto}}" /></returns>
    public Task<PageDto<ProvinciaDto>> FindPaginatedProvincia(int @index, int @size);

    /// <summary>
    ///     Finds Provincia By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Provincia}" /></returns>
    public Task<Provincia> FindProvinciaById(int @id);

    /// <summary>
    ///     Removes Provincia By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    public Task RemoveProvinciaById(int @id);

    /// <summary>
    ///     Updates Provincia
    /// </summary>
    /// <param name="entity">Injected <see cref="Provincia" /></param>
    /// <returns>Instance of <see cref="Task{Provincia}" /></returns>
    public Task<Provincia> UpdateProvincia(Provincia @entity);

    /// <summary>
    ///     Adds Provincia
    /// </summary>
    /// <param name="entity">Injected <see cref="Provincia" /></param>
    /// <returns>Instance of <see cref="Task{Provincia}" /></returns>
    public Task<Provincia> AddProvincia(Provincia @entity);

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
    ///     Reloads Provincia By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{ProvinciaDto}" /></returns>
    public Task<ProvinciaDto> ReloadProvinciaById(int @id);
}