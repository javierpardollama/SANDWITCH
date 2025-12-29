using MediatR;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.Queries.Town;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Town;

/// <summary>
/// Represents a <see cref="FindAllTownHandler"/>. Implements <see cref="IRequestHandler{FindAllTownQuery, IList{ViewCatalog}}"/>
/// </summary>
public class FindAllTownHandler : IRequestHandler<FindAllTownQuery, IList<ViewCatalog>>
{
    private readonly ITownManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="FindAllTownHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="ITownManager"/></param>
    /// <param name="mapper">Injected <see cref="IMapper"/></param>
    public FindAllTownHandler(ITownManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="FindAllTownQuery"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{IList{ViewTown}}"/></returns>
    public async Task<IList<ViewCatalog>> Handle(FindAllTownQuery request, CancellationToken cancellationToken)
    {
        var dtos = await Manager.FindAllTown();

        return [.. dtos.Select(x => x.ToViewModel())];
    }
}