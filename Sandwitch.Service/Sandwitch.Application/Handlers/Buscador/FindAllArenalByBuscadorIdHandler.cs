using MediatR;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.Queries.Buscador;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Buscador;

/// <summary>
/// Represents a <see cref="FindAllArenalByBuscadorIdHandler"/>. Implements <see cref="IRequestHandler{FindAllArenalByBuscadorIdQuery, IList{ViewArenal}}"/>
/// </summary>
public class FindAllArenalByBuscadorIdHandler : IRequestHandler<FindAllArenalByBuscadorIdQuery, IList<ViewArenal>>
{
    private readonly IBuscadorManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="FindAllArenalByBuscadorIdHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IBuscadorManager"/></param>
    public FindAllArenalByBuscadorIdHandler(IBuscadorManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="FindAllArenalByBuscadorIdQuery"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{IList{ViewArenal}}"/></returns>
    public async Task<IList<ViewArenal>> Handle(FindAllArenalByBuscadorIdQuery request,
        CancellationToken cancellationToken)
    {
        var dtos = await Manager.FindAllArenalByBuscadorId(request.ViewModel.Id, request.ViewModel.Group);

        return [.. dtos.Select(x => x.ToViewModel())];
    }
}