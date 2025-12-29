using Sandwitch.Domain.Dtos;
using Sandwitch.Domain.Entities;

namespace Sandwitch.Domain.Managers;

/// <summary>
///     Represents a <see cref="IBeachManager" /> interface. Inherits <see cref="IBaseManager" />
/// </summary>
public interface IBeachManager : IBaseManager
{
    /// <summary>
    ///     Finds All Beach
    /// </summary>
    /// <returns>Instance of <see cref="Task{IList{CatalogDto}}" /></returns>
    public Task<IList<CatalogDto>> FindAllBeach();

    /// <summary>
    ///     Finds Paginated Beach
    /// </summary>
    /// <param name="index">Injected <see cref="int" /></param>
    /// <param name="size">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{PageDto{BeachDto}}" /></returns>
    public Task<PageDto<BeachDto>> FindPaginatedBeach(int @index, int @size);

    /// <summary>
    ///     Finds All Historic By Beach Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{IList{HistoricDto}}" /></returns>
    public Task<IList<HistoricDto>> FindAllHistoricByBeachId(int @id);

    /// <summary>
    ///     Finds Beach By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Beach}" /></returns>
    public Task<Beach> FindBeachById(int @id);

    /// <summary>
    ///     Finds Town By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Town}" /></returns>
    public Task<Town> FindTownById(int @id);

    /// <summary>
    ///     Finds Flag By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Flag}" /></returns>
    public Task<Flag> FindFlagById(int @id);

    /// <summary>
    ///     Removes Beach By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    public Task RemoveBeachById(int @id);

    /// <summary>
    ///     Updates Beach
    /// </summary>
    /// <param name="entity">Injected <see cref="Beach" /></param>
    /// <returns>Instance of <see cref="Task{Beach}" /></returns>
    public Task<Beach> UpdateBeach(Beach @entity);

    /// <summary>
    ///     Adds Beach
    /// </summary>
    /// <param name="entity">Injected <see cref="Beach" /></param>
    /// <returns>Instance of <see cref="Task{Beach}" /></returns>
    public Task<Beach> AddBeach(Beach @entity);

    /// <summary>
    ///     Adds Beach Town
    /// </summary>
    /// <param name="Townes">Injected <see cref="List{Town}" /></param>
    /// <param name="entity">Injected <see cref="Beach" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    public Task AddBeachTown(List<Town> @Townes, Beach @entity);

    /// <summary>
    ///     Adds Historic
    /// </summary>
    /// <param name="entity">Injected <see cref="Beach" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    public Task AddHistoric(Beach entity);

    /// <summary>
    /// Finds All Town By Ids
    /// </summary>
    /// <param name="ids">Injected <see cref="ICollection{int}"/></param>
    /// <returns>Instance of <see cref="Task{List{Town}}"/></returns>
    public Task<List<Town>> FindAllTownByIds(ICollection<int> @ids);

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
    ///     Reloads Beach By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{BeachDto}" /></returns>
    public Task<BeachDto> ReloadBeachById(int @id);
}