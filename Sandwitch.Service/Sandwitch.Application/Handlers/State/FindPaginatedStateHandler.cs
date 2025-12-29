using MediatR;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.Queries.State;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.State;

/// <summary>
/// Represents a <see cref="FindPaginatedStateHandler"/>. Implements <see cref="IRequestHandler{FindPaginatedStateQuery, ViewPage{ViewState}}"/>
/// </summary>
public class FindPaginatedStateHandler : IRequestHandler<FindPaginatedStateQuery, ViewPage<ViewState>>
{
    private readonly IStateManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="FindPaginatedStateHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IStateManager"/></param>
    public FindPaginatedStateHandler(IStateManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="FindPaginatedStateQuery"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{ViewPage{ViewState}}"/></returns>
    public async Task<ViewPage<ViewState>> Handle(FindPaginatedStateQuery request,
        CancellationToken cancellationToken)
    {
        var @page = await Manager.FindPaginatedState(request.ViewModel.Index, request.ViewModel.Size);

        return @page.ToPageViewModel();
    }
}