using Sandwitch.Domain.Dtos;
using Sandwitch.Domain.Entities;

namespace Sandwitch.Domain.Managers;

/// <summary>
///     Represents a <see cref="IVientoManager" /> interface. Inherits <see cref="IBaseManager" />
/// </summary>
public interface IVientoManager : IBaseManager
{
    /// <summary>
    ///     Finds All Viento
    /// </summary>
    /// <returns>Instance of <see cref="Task{IList{CatalogDto}}" /></returns>
    public Task<IList<CatalogDto>> FindAllViento();

    /// <summary>
    ///     Finds Paginated Viento
    /// </summary>
    /// <param name="index">Injected <see cref="int" /></param>
    /// <param name="size">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{PageDto{VientoDto}}" /></returns>
    public Task<PageDto<VientoDto>> FindPaginatedViento(int @index, int @size);

    /// <summary>
    ///     Finds All Historico By Poblacion Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{IList{HistoricoDto}}" /></returns>
    public Task<IList<HistoricoDto>> FindAllHistoricoByVientoId(int id);

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