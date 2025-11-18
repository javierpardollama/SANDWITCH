using MediatR;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.Queries.Viento;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Viento;

/// <summary>
/// Represents a <see cref="FindAllVientoHandler"/>. Implements <see cref="IRequestHandler{FindAllVientoQuery, IList{ViewCatalog}}"/>
/// </summary>
public class FindAllVientoHandler : IRequestHandler<FindAllVientoQuery, IList<ViewCatalog>>
{
    private readonly IVientoManager Manager;   

    /// <summary>
    ///  Initializes a new Instance of <see cref="FindAllVientoHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IVientoManager"/></param>
    public FindAllVientoHandler(IVientoManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="FindAllVientoQuery"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{IList{ViewViento}}"/></returns>
    public async Task<IList<ViewCatalog>> Handle(FindAllVientoQuery request, CancellationToken cancellationToken)
    {
        var dtos = await Manager.FindAllViento();

        return [.. dtos.Select(x => x.ToViewModel())];
    }
}