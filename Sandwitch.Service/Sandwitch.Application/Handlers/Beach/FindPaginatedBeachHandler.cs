using MediatR;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.Queries.Beach;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Beach;

/// <summary>
/// Represents a <see cref="FindPaginatedBeachHandler"/>. Implements <see cref="IRequestHandler{FindPaginatedBeachQuery, ViewPage{ViewBeach}}"/>
/// </summary>
public class FindPaginatedBeachHandler : IRequestHandler<FindPaginatedBeachQuery, ViewPage<ViewBeach>>
{
    private readonly IBeachManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="FindPaginatedBeachHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IBeachManager"/></param>
    /// <param name="mapper">Injected <see cref="IMapper"/></param>
    public FindPaginatedBeachHandler(IBeachManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="FindPaginatedBeachQuery"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{ViewPage{ViewBeach}}"/></returns>
    public async Task<ViewPage<ViewBeach>> Handle(FindPaginatedBeachQuery request,
        CancellationToken cancellationToken)
    {
        var page = await Manager.FindPaginatedBeach(request.ViewModel.Index, request.ViewModel.Size);

        return @page.ToPageViewModel();
    }
}