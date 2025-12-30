using MediatR;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.Queries.Flag;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Flag;

/// <summary>
/// Represents a <see cref="FindPaginatedFlagHandler"/>. Implements <see cref="IRequestHandler{FindPaginatedFlagQuery, ViewPage{ViewFlag}}"/>
/// </summary>
public class FindPaginatedFlagHandler : IRequestHandler<FindPaginatedFlagQuery, ViewPage<ViewFlag>>
{
    private readonly IFlagManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="FindPaginatedFlagHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IFlagManager"/></param>
    public FindPaginatedFlagHandler(IFlagManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="FindPaginatedFlagQuery"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{ViewPage{ViewFlag}}"/></returns>
    public async Task<ViewPage<ViewFlag>> Handle(FindPaginatedFlagQuery request,
        CancellationToken cancellationToken)
    {
        var @page = await Manager.FindPaginatedFlag(request.ViewModel.Index, request.ViewModel.Size);

        return @page.ToPageViewModel();       
    }
}