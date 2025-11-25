using Sandwitch.Domain.Dtos;

namespace Sandwitch.Domain.Managers;

/// <summary>
///     Represents a <see cref="IBuscadorManager" /> interface. Inherits <see cref="IBaseManager" />
/// </summary>
public interface IBuscadorManager : IBaseManager
{
    /// <summary>
    ///     Finds All Buscador
    /// </summary>
    /// <returns>Instance of <see cref="Task{IList{BuscadorDto}}" /></returns>
    public Task<IList<BuscadorDto>> FindAllBuscador();

    /// <summary>
    ///     Finds All Arenal By Buscador Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <param name="group">Injected <see cref="string" /></param>
    /// <returns>Instance of <see cref="Task{IList{ArenalDto}}" /></returns>
    public Task<IList<ArenalDto>> FindAllArenalByBuscadorId(int @id, string @group);
}