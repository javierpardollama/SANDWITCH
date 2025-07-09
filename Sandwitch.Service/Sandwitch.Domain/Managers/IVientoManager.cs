using Sandwitch.Domain.Entities;
using Sandwitch.Domain.ViewModels.Additions;
using Sandwitch.Domain.ViewModels.Filters;
using Sandwitch.Domain.ViewModels.Updates;

namespace Sandwitch.Domain.Managers;

/// <summary>
///     Represents a <see cref="IVientoManager" /> interface. Inherits <see cref="IBaseManager" />
/// </summary>
public interface IVientoManager : IBaseManager
{
    /// <summary>
    ///     Finds All Viento
    /// </summary>
    /// <returns>Instance of <see cref="Task{IList{Viento}}" /></returns>
    public Task<IList<Viento>> FindAllViento();

    /// <summary>
    ///     Finds Paginated Viento
    /// </summary>
    /// <param name="viewModel">Injected <see cref="FilterPage" /></param>
    /// <returns>Instance of <see cref="Task{Page{Viento}}" /></returns>
    public Task<Page<Viento>> FindPaginatedViento(FilterPage viewModel);

    /// <summary>
    ///     Finds All Historico By Poblacion Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{IList{Historico}}" /></returns>
    public Task<IList<Historico>> FindAllHistoricoByVientoId(int id);

    /// <summary>
    ///     Finds Viento By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Viento}" /></returns>
    public Task<Viento> FindVientoById(int id);

    /// <summary>
    ///     Removes Viento By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    public Task RemoveVientoById(int id);

    /// <summary>
    ///     Updates Viento
    /// </summary>
    /// <param name="viewModel">Injected <see cref="UpdateViento" /></param>
    /// <returns>Instance of <see cref="Task{Viento}" /></returns>
    public Task<Viento> UpdateViento(UpdateViento viewModel);

    /// <summary>
    ///     Adds Viento
    /// </summary>
    /// <param name="viewModel">Injected <see cref="AddViento" /></param>
    /// <returns>Instance of <see cref="Task{ViewViento}" /></returns>
    public Task<Viento> AddViento(AddViento viewModel);

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <param name="viewModel">Injected <see cref="AddViento" /></param>
    /// <returns>Instance of <see cref="Task{Viento}" /></returns>
    public Task<Viento> CheckName(AddViento viewModel);

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <param name="viewModel">Injected <see cref="UpdateViento" /></param>
    /// <returns>Instance of <see cref="Task{Viento}" /></returns>
    public Task<Viento> CheckName(UpdateViento viewModel);
}