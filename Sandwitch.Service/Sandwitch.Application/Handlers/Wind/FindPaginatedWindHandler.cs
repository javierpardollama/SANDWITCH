using MediatR;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.Queries.Wind;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Wind;

/// <summary>
/// Represents a <see cref="FindPaginatedWindHandler"/>. Implements <see cref="IRequestHandler{FindPaginatedWindQuery, ViewPage{ViewWind}}"/>
/// </summary>
public class FindPaginatedWindHandler : IRequestHandler<FindPaginatedWindQuery, ViewPage<ViewWind>>
{
    private readonly IWindManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="FindPaginatedWindHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IWindManager"/></param>
    public FindPaginatedWindHandler(IWindManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="FindPaginatedWindQuery"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{ViewPage{ViewWind}}"/></returns>
    public async Task<ViewPage<ViewWind>> Handle(FindPaginatedWindQuery request,
        CancellationToken cancellationToken)
    {
        var page = await Manager.FindPaginatedWind(request.ViewModel.Index, request.ViewModel.Size);

        return @page.ToPageViewModel();
    }
}