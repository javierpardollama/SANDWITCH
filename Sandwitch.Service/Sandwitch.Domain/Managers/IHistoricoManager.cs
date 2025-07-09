using Sandwitch.Domain.Entities;
using Sandwitch.Domain.ViewModels.Additions;

namespace Sandwitch.Domain.Managers;

/// <summary>
///     Represents a <see cref="IBanderaManager" /> interface. Inherits <see cref="IBaseManager" />
/// </summary>
public interface IHistoricoManager : IBaseManager
{
    /// <summary>
    ///     Finds Arenal By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Arenal}" /></returns>
    public Task<Arenal> FindArenalById(int id);

    /// <summary>
    ///     Finds Bandera By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Bandera}" /></returns>
    public Task<Bandera> FindBanderaById(int id);

    /// <summary>
    ///     Adds Historico
    /// </summary>
    /// <param name="viewModel">Injected <see cref="AddHistorico" /></param>
    /// <returns>Instance of <see cref="Task{Historico}" /></returns>
    public Task<Historico> AddHistorico(AddHistorico viewModel);
}