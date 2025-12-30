using Sandwitch.Domain.Dtos;
using Sandwitch.Domain.Entities;

namespace Sandwitch.Domain.Managers;

/// <summary>
///     Represents a <see cref="IWindManager" /> interface. Inherits <see cref="IBaseManager" />
/// </summary>
public interface IWindManager : IBaseManager
{
    /// <summary>
    ///     Finds All Wind
    /// </summary>
    /// <returns>Instance of <see cref="Task{IList{CatalogDto}}" /></returns>
    public Task<IList<CatalogDto>> FindAllWind();

    /// <summary>
    ///     Finds Paginated Wind
    /// </summary>
    /// <param name="index">Injected <see cref="int" /></param>
    /// <param name="size">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{PageDto{WindDto}}" /></returns>
    public Task<PageDto<WindDto>> FindPaginatedWind(int @index, int @size);

    /// <summary>
    ///     Finds All Historic By Town Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{IList{HistoricDto}}" /></returns>
    public Task<IList<HistoricDto>> FindAllHistoricByWindId(int @id);

    /// <summary>
    ///     Finds Wind By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Wind}" /></returns>
    public Task<Wind> FindWindById(int @id);

    /// <summary>
    ///     Removes Wind By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    public Task RemoveWindById(int @id);

    /// <summary>
    ///     Updates Wind
    /// </summary>
    /// <param name="entity">Injected <see cref="Wind" /></param>
    /// <returns>Instance of <see cref="Task{Wind}" /></returns>
    public Task<Wind> UpdateWind(Wind @entity);

    /// <summary>
    ///     Adds Wind
    /// </summary>
    /// <param name="entity">Injected <see cref="Wind" /></param>
    /// <returns>Instance of <see cref="Task{Wind}" /></returns>
    public Task<Wind> AddWind(Wind @entity);

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
    ///     Reloads Wind By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{WindDto}" /></returns>
    public Task<WindDto> ReloadWindById(int @id);
}