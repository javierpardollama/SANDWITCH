using Sandwitch.Domain.Dtos;
using Sandwitch.Domain.Entities;

namespace Sandwitch.Domain.Managers;

/// <summary>
///     Represents a <see cref="IBanderaManager" /> interface. Inherits <see cref="IBaseManager" />
/// </summary>
public interface IBanderaManager : IBaseManager
{
    /// <summary>
    ///     Finds All Bandera
    /// </summary>
    /// <returns>Instance of <see cref="Task{IList{CatalogDto}}" /></returns>
    public Task<IList<CatalogDto>> FindAllBandera();

    /// <summary>
    ///     Finds Paginated Bandera
    /// </summary>
    /// <param name="index">Injected <see cref="int" /></param>
    /// <param name="size">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{PageDto{BanderaDto}}" /></returns>
    public Task<PageDto<BanderaDto>> FindPaginatedBandera(int @index, int @size);

    /// <summary>
    ///     Finds All Historico By Poblacion Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{IList{HistoricoDto}}" /></returns>
    public Task<IList<HistoricoDto>> FindAllHistoricoByBanderaId(int id);

    /// <summary>
    ///     Finds Bandera By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Bandera}" /></returns>
    public Task<Bandera> FindBanderaById(int id);

    /// <summary>
    ///     Removes Bandera By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    public Task RemoveBanderaById(int id);

    /// <summary>
    ///     Updates Bandera
    /// </summary>
    /// <param name="viewModel">Injected <see cref="UpdateBandera" /></param>
    /// <returns>Instance of <see cref="Task{ViewBandera}" /></returns>
    public Task<Bandera> UpdateBandera(UpdateBandera viewModel);

    /// <summary>
    ///     Adds Bandera
    /// </summary>
    /// <param name="viewModel">Injected <see cref="AddBandera" /></param>
    /// <returns>Instance of <see cref="Task{Bandera}" /></returns>
    public Task<Bandera> AddBandera(AddBandera viewModel);

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <param name="viewModel">Injected <see cref="AddBandera" /></param>
    /// <returns>Instance of <see cref="Task{Bandera}" /></returns>
    public Task<Bandera> CheckName(AddBandera viewModel);

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <param name="viewModel">Injected <see cref="UpdateBandera" /></param>
    /// <returns>Instance of <see cref="Task{Bandera}" /></returns>
    public Task<Bandera> CheckName(UpdateBandera viewModel);
}