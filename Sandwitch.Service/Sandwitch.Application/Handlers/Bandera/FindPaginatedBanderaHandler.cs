using MediatR;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.Queries.Bandera;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Bandera;

/// <summary>
/// Represents a <see cref="FindPaginatedBanderaHandler"/>. Implements <see cref="IRequestHandler{FindPaginatedBanderaQuery, ViewPage{ViewBandera}}"/>
/// </summary>
public class FindPaginatedBanderaHandler : IRequestHandler<FindPaginatedBanderaQuery, ViewPage<ViewBandera>>
{
    private readonly IBanderaManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="FindPaginatedBanderaHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IBanderaManager"/></param>
    public FindPaginatedBanderaHandler(IBanderaManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="FindPaginatedBanderaQuery"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{ViewPage{ViewBandera}}"/></returns>
    public async Task<ViewPage<ViewBandera>> Handle(FindPaginatedBanderaQuery request,
        CancellationToken cancellationToken)
    {
        var @page = await Manager.FindPaginatedBandera(request.ViewModel.Index, request.ViewModel.Size);

        return @page.ToPageViewModel();       
    }
}