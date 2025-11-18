using MediatR;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.Queries.Poblacion;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Poblacion;

/// <summary>
/// Represents a <see cref="FindPaginatedPoblacionHandler"/>. Implements <see cref="IRequestHandler{FindPaginatedPoblacionQuery, ViewPage{ViewPoblacion}}"/>
/// </summary>
public class FindPaginatedPoblacionHandler : IRequestHandler<FindPaginatedPoblacionQuery, ViewPage<ViewPoblacion>>
{
    private readonly IPoblacionManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="FindPaginatedPoblacionHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IPoblacionManager"/></param>
    public FindPaginatedPoblacionHandler(IPoblacionManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="FindPaginatedPoblacionQuery"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{ViewPage{ViewPoblacion}}"/></returns>
    public async Task<ViewPage<ViewPoblacion>> Handle(FindPaginatedPoblacionQuery request,
        CancellationToken cancellationToken)
    {
        var @page = await Manager.FindPaginatedPoblacion(request.ViewModel.Index, request.ViewModel.Size);

        return @page.ToPageViewModel();
    }
}