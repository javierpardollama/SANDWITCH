using Sandwitch.Domain.Entities;
using Sandwitch.Domain.ViewModels.Finders;

namespace Sandwitch.Domain.Managers;

/// <summary>
///     Represents a <see cref="IBuscadorManager" /> interface. Inherits <see cref="IBaseManager" />
/// </summary>
public interface IBuscadorManager : IBaseManager
{
    /// <summary>
    ///     Finds All Buscador
    /// </summary>
    /// <returns>Instance of <see cref="Task{IList{Buscador}}" /></returns>
    public Task<IList<Buscador>> FindAllBuscador();

    /// <summary>
    ///     Finds All Arenal By Buscador Id
    /// </summary>
    /// <param name="viewModel">Injected <see cref="FinderArenal" /></param>
    /// <returns>Instance of <see cref="Task{IList{Arenal}}" /></returns>
    public Task<IList<Arenal>> FindAllArenalByBuscadorId(FinderArenal viewModel);
}