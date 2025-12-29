using Sandwitch.Domain.Dtos;
using Sandwitch.Domain.Entities;

namespace Sandwitch.Domain.Managers;

/// <summary>
///     Represents a <see cref="ITownManager" /> interface. Inherits <see cref="IBaseManager" />
/// </summary>
public interface ITownManager : IBaseManager
{
    /// <summary>
    ///     Finds All Town
    /// </summary>
    /// <returns>Instance of <see cref="Task{IList{CatalogDto}}" /></returns>
    public Task<IList<CatalogDto>> FindAllTown();

    /// <summary>
    ///     Finds Paginated Town
    /// </summary>
    /// <param name="index">Injected <see cref="int" /></param>
    /// <param name="size">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{PageDto{TownDto}}" /></returns>
    public Task<PageDto<TownDto>> FindPaginatedTown(int @index, int @size);

    /// <summary>
    ///     Finds Town By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Town}" /></returns>
    public Task<Town> FindTownById(int @id);

    /// <summary>
    ///     Finds State By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{State}" /></returns>
    public Task<State> FindStateById(int @id);

    /// <summary>
    ///     Removes Town By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    public Task RemoveTownById(int @id);

    /// <summary>
    ///     Updates Town
    /// </summary>
    /// <param name="entity">Injected <see cref="Town" /></param>
    /// <returns>Instance of <see cref="Task{Town}" /></returns>
    public Task<Town> UpdateTown(Town @entity);

    /// <summary>
    ///     Adds Town
    /// </summary>
    /// <param name="entity">Injected <see cref="Town" /></param>
    /// <returns>Instance of <see cref="Task{Town}" /></returns>
    public Task<Town> AddTown(Town entity);

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
    ///     Reloads Town By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{BeachDto}" /></returns>
    public Task<TownDto> ReloadTownById(int @id);
}