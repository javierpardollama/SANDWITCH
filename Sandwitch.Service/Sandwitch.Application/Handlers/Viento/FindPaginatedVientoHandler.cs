using MediatR;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.Queries.Viento;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Viento;

/// <summary>
/// Represents a <see cref="FindPaginatedVientoHandler"/>. Implements <see cref="IRequestHandler{FindPaginatedVientoQuery, ViewPage{ViewViento}}"/>
/// </summary>
public class FindPaginatedVientoHandler : IRequestHandler<FindPaginatedVientoQuery, ViewPage<ViewViento>>
{
    private readonly IVientoManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="FindPaginatedVientoHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IVientoManager"/></param>
    public FindPaginatedVientoHandler(IVientoManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="FindPaginatedVientoQuery"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{ViewPage{ViewViento}}"/></returns>
    public async Task<ViewPage<ViewViento>> Handle(FindPaginatedVientoQuery request,
        CancellationToken cancellationToken)
    {
        var page = await Manager.FindPaginatedViento(request.ViewModel.Index, request.ViewModel.Size);

        return @page.ToPageViewModel();
    }
}