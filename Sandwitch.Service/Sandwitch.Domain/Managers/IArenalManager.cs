using Sandwitch.Domain.Dtos;
using Sandwitch.Domain.Entities;

namespace Sandwitch.Domain.Managers;

/// <summary>
///     Represents a <see cref="IArenalManager" /> interface. Inherits <see cref="IBaseManager" />
/// </summary>
public interface IArenalManager : IBaseManager
{
    /// <summary>
    ///     Finds All Arenal
    /// </summary>
    /// <returns>Instance of <see cref="Task{IList{CatalogDto}}" /></returns>
    public Task<IList<CatalogDto>> FindAllArenal();

    /// <summary>
    ///     Finds Paginated Arenal
    /// </summary>
    /// <param name="index">Injected <see cref="int" /></param>
    /// <param name="size">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{PageDto{ArenalDto}}" /></returns>
    public Task<PageDto<ArenalDto>> FindPaginatedArenal(int @index, int @size);

    /// <summary>
    ///     Finds All Historico By Arenal Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{IList{HistoricoDto}}" /></returns>
    public Task<IList<HistoricoDto>> FindAllHistoricoByArenalId(int @id);

    /// <summary>
    ///     Finds Arenal By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Arenal}" /></returns>
    public Task<Arenal> FindArenalById(int @id);

    /// <summary>
    ///     Finds Poblacion By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Poblacion}" /></returns>
    public Task<Poblacion> FindPoblacionById(int @id);

    /// <summary>
    ///     Finds Bandera By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{Bandera}" /></returns>
    public Task<Bandera> FindBanderaById(int @id);

    /// <summary>
    ///     Removes Arenal By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    public Task RemoveArenalById(int @id);

    /// <summary>
    ///     Updates Arenal
    /// </summary>
    /// <param name="entity">Injected <see cref="Arenal" /></param>
    /// <returns>Instance of <see cref="Task{Arenal}" /></returns>
    public Task<Arenal> UpdateArenal(Arenal @entity);

    /// <summary>
    ///     Adds Arenal
    /// </summary>
    /// <param name="entity">Injected <see cref="Arenal" /></param>
    /// <returns>Instance of <see cref="Task{Arenal}" /></returns>
    public Task<Arenal> AddArenal(Arenal @entity);

    /// <summary>
    ///     Adds Arenal Poblacion
    /// </summary>
    /// <param name="poblaciones">Injected <see cref="List{Poblacion}" /></param>
    /// <param name="entity">Injected <see cref="Arenal" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    public Task AddArenalPoblacion(List<Poblacion> @poblaciones, Arenal @entity);

    /// <summary>
    ///     Adds Historico
    /// </summary>
    /// <param name="entity">Injected <see cref="Arenal" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    public Task AddHistorico(Arenal entity);

    /// <summary>
    /// Finds All Poblacion By Ids
    /// </summary>
    /// <param name="ids">Injected <see cref="ICollection{int}"/></param>
    /// <returns>Instance of <see cref="Task{List{Poblacion}}"/></returns>
    Task<List<Poblacion>> FindAllPoblacionByIds(ICollection<int> @ids);

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <param name="name">Injected <see cref="string" /></param>
    /// <returns>Instance of <see cref="Task{bool}" /></returns>
    public Task<bool> CheckName(string @name);

    /// <summary>
    ///     Checks Name
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <param name="name">Injected <see cref="string" /></param>
    /// <returns>Instance of <see cref="Task{bool}" /></returns>
    public Task<bool> CheckName(int @id, string @name);

    /// <summary>
    ///     Reloads Arenal By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{ArenalDto}" /></returns>
    public Task<ArenalDto> ReloadArenalById(int @id);
}