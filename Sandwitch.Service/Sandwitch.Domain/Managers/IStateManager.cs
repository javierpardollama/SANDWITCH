using Sandwitch.Domain.Dtos;
using Sandwitch.Domain.Entities;

namespace Sandwitch.Domain.Managers;

/// <summary>
///     Represents a <see cref="IStateManager" /> interface. Inherits <see cref="IBaseManager" />
/// </summary>
public interface IStateManager : IBaseManager
{
    /// <summary>
    ///     Finds All State
    /// </summary>
    /// <returns>Instance of <see cref="Task{IList{CatalogDto}}" /></returns>
    public Task<IList<CatalogDto>> FindAllState();

    /// <summary>
    ///     Finds Paginated State
    /// </summary>
    /// <param name="index">Injected <see cref="int" /></param>
    /// <param name="size">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{PageDto{StateDto}}" /></returns>
    public Task<PageDto<StateDto>> FindPaginatedState(int @index, int @size);

    /// <summary>
    ///     Finds State By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{State}" /></returns>
    public Task<State> FindStateById(int @id);

    /// <summary>
    ///     Removes State By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    public Task RemoveStateById(int @id);

    /// <summary>
    ///     Updates State
    /// </summary>
    /// <param name="entity">Injected <see cref="State" /></param>
    /// <returns>Instance of <see cref="Task{State}" /></returns>
    public Task<State> UpdateState(State @entity);

    /// <summary>
    ///     Adds State
    /// </summary>
    /// <param name="entity">Injected <see cref="State" /></param>
    /// <returns>Instance of <see cref="Task{State}" /></returns>
    public Task<State> AddState(State @entity);

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
    ///     Reloads State By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{StateDto}" /></returns>
    public Task<StateDto> ReloadStateById(int @id);
}