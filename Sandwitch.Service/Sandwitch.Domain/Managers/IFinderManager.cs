using Sandwitch.Domain.Dtos;

namespace Sandwitch.Domain.Managers;

/// <summary>
///     Represents a <see cref="IFinderManager" /> interface. Inherits <see cref="IBaseManager" />
/// </summary>
public interface IFinderManager : IBaseManager
{
    /// <summary>
    ///     Finds All Finder
    /// </summary>
    /// <returns>Instance of <see cref="Task{IList{FinderDto}}" /></returns>
    public Task<IList<FinderDto>> FindAllFinder();

    /// <summary>
    ///     Finds All Beach By Finder Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <param name="group">Injected <see cref="string" /></param>
    /// <returns>Instance of <see cref="Task{IList{BeachDto}}" /></returns>
    public Task<IList<BeachDto>> FindAllBeachByFinderId(int @id, string @group);
}