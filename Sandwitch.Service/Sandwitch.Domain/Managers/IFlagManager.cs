using Sandwitch.Domain.Dtos;
using Sandwitch.Domain.Entities;

namespace Sandwitch.Domain.Managers;

/// <summary>
///     Represents a <see cref="IFlagManager" /> interface. Inherits <see cref="IBaseManager" />
/// </summary>
public interface IFlagManager : IBaseManager
{
    /// <summary>
    ///     Finds All Flag
    /// </summary>
    /// <returns>Instance of <see cref="Task{IList{CatalogDto}}" /></returns>
    public Task<IList<CatalogDto>> FindAllFlag();

    /// <summary>
    ///     Finds Paginated Flag
    /// </summary>
    /// <param name="index">Injected <see cref="int" /></param>
    /// <param name="size">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{PageDto{FlagDto}}" /></returns>
    public Task<PageDto<FlagDto>> FindPaginatedFlag(int @index, int @size);

    /// <summary>
    ///     Finds All Historic By Town Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{IList{HistoricDto}}" /></returns>
    public Task<IList<HistoricDto>> FindAllHistoricByFlagId(int @id);

    /// <summary>
    ///     Finds Flag By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Flag}" /></returns>
    public Task<Flag> FindFlagById(int @id);

    /// <summary>
    ///     Removes Flag By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    public Task RemoveFlagById(int @id);

    /// <summary>
    ///     Updates Flag
    /// </summary>
    /// <param name="entity">Injected <see cref="Flag" /></param>
    /// <returns>Instance of <see cref="Task{ViewFlag}" /></returns>
    public Task<Flag> UpdateFlag(Flag @entity);

    /// <summary>
    ///     Adds Flag
    /// </summary>
    /// <param name="entity">Injected <see cref="Flag" /></param>
    /// <returns>Instance of <see cref="Task{Flag}" /></returns>
    public Task<Flag> AddFlag(Flag @entity);

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <param name="name">Injected <see cref="string" /></param>
    /// <returns>Instance of <see cref="Task{Banbooldera}" /></returns>
    public Task<bool> CheckName(string @name);

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <param name="name">Injected <see cref="string" /></param>
    /// <returns>Instance of <see cref="Task{bool}" /></returns>
    public Task<bool> CheckName(int @id, string @name);

    /// <summary>
    ///     Reloads Flag By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{FlagDto}" /></returns>
    public Task<FlagDto> ReloadFlagById(int @id);
}