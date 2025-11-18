using MediatR;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.Queries.Bandera;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Bandera;

/// <summary>
/// Represents a <see cref="FindAllBanderaHandler"/>. Implements <see cref="IRequestHandler{FindAllBanderaQuery,  IList{ViewBandera}}"/>
/// </summary>
public class FindAllBanderaHandler : IRequestHandler<FindAllBanderaQuery, IList<ViewCatalog>>
{
    private readonly IBanderaManager Manager;   

    /// <summary>
    ///  Initializes a new Instance of <see cref="FindAllBanderaHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IBanderaManager"/></param>
    public FindAllBanderaHandler(IBanderaManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="FindAllBanderaQuery"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{IList{ViewCatalog}}"/></returns>
    public async Task<IList<ViewCatalog>> Handle(FindAllBanderaQuery request, CancellationToken cancellationToken)
    {
        var dtos = await Manager.FindAllBandera();

        return [.. dtos.Select(x => x.ToViewModel())];
    }
}