using MediatR;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.Queries.Town;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Town;

/// <summary>
/// Represents a <see cref="FindPaginatedTownHandler"/>. Implements <see cref="IRequestHandler{FindPaginatedTownQuery, ViewPage{ViewTown}}"/>
/// </summary>
public class FindPaginatedTownHandler : IRequestHandler<FindPaginatedTownQuery, ViewPage<ViewTown>>
{
    private readonly ITownManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="FindPaginatedTownHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="ITownManager"/></param>
    public FindPaginatedTownHandler(ITownManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="FindPaginatedTownQuery"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{ViewPage{ViewTown}}"/></returns>
    public async Task<ViewPage<ViewTown>> Handle(FindPaginatedTownQuery request,
        CancellationToken cancellationToken)
    {
        var @page = await Manager.FindPaginatedTown(request.ViewModel.Index, request.ViewModel.Size);

        return @page.ToPageViewModel();
    }
}