using Sandwitch.Domain.Dtos;
using Sandwitch.Domain.Entities;

namespace Sandwitch.Domain.Managers;

/// <summary>
///     Represents a <see cref="IFlagManager" /> interface. Inherits <see cref="IBaseManager" />
/// </summary>
public interface IHistoricManager : IBaseManager
{
    /// <summary>
    ///     Finds Beach By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Beach}" /></returns>
    public Task<Beach> FindBeachById(int @id);

    /// <summary>
    ///     Finds Flag By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Flag}" /></returns>
    public Task<Flag> FindFlagById(int @id);

    /// <summary>
    ///     Adds Historic
    /// </summary>
    /// <param name="entity">Injected <see cref="Historic" /></param>
    /// <returns>Instance of <see cref="Task{Historic}" /></returns>
    public Task<Historic> AddHistoric(Historic @entity);

    /// <summary>
    ///     Reloads Historic By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{HistoricDto}" /></returns>
    public Task<HistoricDto> ReloadHistoricById(int @id);
}