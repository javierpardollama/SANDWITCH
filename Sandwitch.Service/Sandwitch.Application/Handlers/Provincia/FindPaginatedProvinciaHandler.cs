using MediatR;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.Queries.Provincia;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Provincia;

/// <summary>
/// Represents a <see cref="FindPaginatedProvinciaHandler"/>. Implements <see cref="IRequestHandler{FindPaginatedProvinciaQuery, ViewPage{ViewProvincia}}"/>
/// </summary>
public class FindPaginatedProvinciaHandler : IRequestHandler<FindPaginatedProvinciaQuery, ViewPage<ViewProvincia>>
{
    private readonly IProvinciaManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="FindPaginatedProvinciaHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IProvinciaManager"/></param>
    public FindPaginatedProvinciaHandler(IProvinciaManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="FindPaginatedProvinciaQuery"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{ViewPage{ViewProvincia}}"/></returns>
    public async Task<ViewPage<ViewProvincia>> Handle(FindPaginatedProvinciaQuery request,
        CancellationToken cancellationToken)
    {
        var @page = await Manager.FindPaginatedProvincia(request.ViewModel.Index, request.ViewModel.Size);

        return @page.ToPageViewModel();
    }
}