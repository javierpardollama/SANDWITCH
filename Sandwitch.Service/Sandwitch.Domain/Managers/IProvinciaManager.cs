using Sandwitch.Domain.Entities;
using Sandwitch.Domain.ViewModels.Additions;
using Sandwitch.Domain.ViewModels.Filters;
using Sandwitch.Domain.ViewModels.Updates;

namespace Sandwitch.Domain.Managers;

/// <summary>
///     Represents a <see cref="IProvinciaManager" /> interface. Inherits <see cref="IBaseManager" />
/// </summary>
public interface IProvinciaManager : IBaseManager
{
    /// <summary>
    ///     Finds All Provincia
    /// </summary>
    /// <returns>Instance of <see cref="Task{IList{Provincia}}" /></returns>
    public Task<IList<Provincia>> FindAllProvincia();

    /// <summary>
    ///     Finds Paginated Provincia
    /// </summary>
    /// <param name="viewModel">Injected <see cref="FilterPage" /></param>
    /// <returns>Instance of <see cref="Task{Page{Provincia}}" /></returns>
    public Task<Page<Provincia>> FindPaginatedProvincia(FilterPage viewModel);

    /// <summary>
    ///     Finds Provincia By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Provincia}" /></returns>
    public Task<Provincia> FindProvinciaById(int id);

    /// <summary>
    ///     Removes Provincia By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    public Task RemoveProvinciaById(int id);

    /// <summary>
    ///     Updates Provincia
    /// </summary>
    /// <param name="viewModel">Injected <see cref="UpdateProvincia" /></param>
    /// <returns>Instance of <see cref="Task{Provincia}" /></returns>
    public Task<Provincia> UpdateProvincia(UpdateProvincia viewModel);

    /// <summary>
    ///     Adds Provincia
    /// </summary>
    /// <param name="viewModel">Injected <see cref="AddProvincia" /></param>
    /// <returns>Instance of <see cref="Task{Provincia}" /></returns>
    public Task<Provincia> AddProvincia(AddProvincia viewModel);

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <param name="viewModel">Injected <see cref="AddProvincia" /></param>
    /// <returns>Instance of <see cref="Task{Provincia}" /></returns>
    public Task<Provincia> CheckName(AddProvincia viewModel);

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <param name="viewModel">Injected <see cref="AddProvincia" /></param>
    /// <returns>Instance of <see cref="Task{Provincia}" /></returns>
    public Task<Provincia> CheckName(UpdateProvincia viewModel);
}