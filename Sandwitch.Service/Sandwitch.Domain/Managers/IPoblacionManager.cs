using Sandwitch.Domain.Entities;
using Sandwitch.Domain.ViewModels.Additions;
using Sandwitch.Domain.ViewModels.Filters;
using Sandwitch.Domain.ViewModels.Updates;

namespace Sandwitch.Domain.Managers;

/// <summary>
///     Represents a <see cref="IPoblacionManager" /> interface. Inherits <see cref="IBaseManager" />
/// </summary>
public interface IPoblacionManager : IBaseManager
{
    /// <summary>
    ///     Finds All Poblacion
    /// </summary>
    /// <returns>Instance of <see cref="Task{IList{Poblacion}}" /></returns>
    public Task<IList<Poblacion>> FindAllPoblacion();

    /// <summary>
    ///     Finds Paginated Poblacion
    /// </summary>
    /// <param name="viewModel">Injected <see cref="FilterPage" /></param>
    /// <returns>Instance of <see cref="Task{Page{Poblacion}}" /></returns>
    public Task<Page<Poblacion>> FindPaginatedPoblacion(FilterPage viewModel);

    /// <summary>
    ///     Finds Poblacion By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Poblacion}" /></returns>
    public Task<Poblacion> FindPoblacionById(int id);

    /// <summary>
    ///     Finds Provincia By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Provincia}" /></returns>
    public Task<Provincia> FindProvinciaById(int id);

    /// <summary>
    ///     Removes Poblacion By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    public Task RemovePoblacionById(int id);

    /// <summary>
    ///     Updates Poblacion
    /// </summary>
    /// <param name="viewModel">Injected <see cref="UpdatePoblacion" /></param>
    /// <returns>Instance of <see cref="Task{Poblacion}" /></returns>
    public Task<Poblacion> UpdatePoblacion(UpdatePoblacion viewModel);

    /// <summary>
    ///     Adds Poblacion
    /// </summary>
    /// <param name="viewModel">Injected <see cref="AddPoblacion" /></param>
    /// <returns>Instance of <see cref="Task{Poblacion}" /></returns>
    public Task<Poblacion> AddPoblacion(AddPoblacion viewModel);

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <param name="viewModel">Injected <see cref="AddPoblacion" /></param>
    /// <returns>Instance of <see cref="Task{Poblacion}" /></returns>
    Task<Poblacion> CheckName(AddPoblacion viewModel);

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <param name="viewModel">Injected <see cref="AddPoblacion" /></param>
    /// <returns>Instance of <see cref="Task{Poblacion}" /></returns>
    Task<Poblacion> CheckName(UpdatePoblacion viewModel);
}