using Sandwitch.Domain.Entities;
using Sandwitch.Domain.ViewModels.Additions;
using Sandwitch.Domain.ViewModels.Filters;
using Sandwitch.Domain.ViewModels.Updates;

namespace Sandwitch.Domain.Managers;

/// <summary>
///     Represents a <see cref="IArenalManager" /> interface. Inherits <see cref="IBaseManager" />
/// </summary>
public interface IArenalManager : IBaseManager
{
    /// <summary>
    ///     Finds All Arenal
    /// </summary>
    /// <returns>Instance of <see cref="IList{Arenal}" /></returns>
    public Task<IList<Arenal>> FindAllArenal();

    /// <summary>
    ///     Finds Paginated Arenal
    /// </summary>
    /// <param name="viewModel">Injected <see cref="FilterPage" /></param>
    /// <returns>Instance of <see cref="Task{Page{Arenal}}" /></returns>
    public Task<Page<Arenal>> FindPaginatedArenal(FilterPage viewModel);

    /// <summary>
    ///     Finds All Historico By Arenal Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{IList{Historico}}" /></returns>
    public Task<IList<Historico>> FindAllHistoricoByArenalId(int id);

    /// <summary>
    ///     Finds Arenal By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Arenal}" /></returns>
    public Task<Arenal> FindArenalById(int id);

    /// <summary>
    ///     Finds Poblacion By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Poblacion}" /></returns>
    public Task<Poblacion> FindPoblacionById(int id);

    /// <summary>
    ///     Finds Bandera By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Bandera}" /></returns>
    public Task<Bandera> FindBanderaById(int id);

    /// <summary>
    ///     Removes Arenal By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    public Task RemoveArenalById(int id);

    /// <summary>
    ///     Updates Arenal
    /// </summary>
    /// <param name="viewModel">Injected <see cref="UpdateArenal" /></param>
    /// <returns>Instance of <see cref="Task{Arenal}" /></returns>
    public Task<Arenal> UpdateArenal(UpdateArenal viewModel);

    /// <summary>
    ///     Adds Arenal
    /// </summary>
    /// <param name="viewModel">Injected <see cref="AddArenal" /></param>
    /// <returns>Instance of <see cref="Task{Arenal}" /></returns>
    public Task<Arenal> AddArenal(AddArenal viewModel);

    /// <summary>
    ///     Adds Arenal Poblacion
    /// </summary>
    /// <param name="viewModel">Injected <see cref="AddArenal" /></param>
    /// <param name="entity">Injected <see cref="Arenal" /></param>
    public void AddArenalPoblacion(AddArenal viewModel, Arenal entity);

    /// <summary>
    ///     Adds Historico
    /// </summary>
    /// <param name="entity">Injected <see cref="Arenal" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    public Task AddHistorico(Arenal entity);

    /// <summary>
    ///     Updates Arenal Poblacion
    /// </summary>
    /// <param name="viewModel">Injected <see cref="UpdateArenal" /></param>
    /// <param name="entity">Injected <see cref="Arenal" /></param>
    public void UpdateArenalPoblacion(UpdateArenal viewModel, Arenal entity);

    /// <summary>
    ///     Updates Historico
    /// </summary>
    /// <param name="entity">Injected <see cref="Arenal" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    public Task UpdateHistorico(Arenal entity);

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <param name="viewModel">Injected <see cref="AddArenal" /></param>
    /// <returns>Instance of <see cref="Task{Arenal}" /></returns>
    public Task<Arenal> CheckName(AddArenal viewModel);

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <param name="viewModel">Injected <see cref="UpdateArenal" /></param>
    /// <returns>Instance of <see cref="Task{Arenal}" /></returns>
    public Task<Arenal> CheckName(UpdateArenal viewModel);
}