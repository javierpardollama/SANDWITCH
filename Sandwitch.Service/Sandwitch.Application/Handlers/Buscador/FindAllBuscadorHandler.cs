using MediatR;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.Queries.Buscador;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Buscador;

/// <summary>
/// Represents a <see cref="FindAllBuscadorHandler"/>. Implements <see cref="IRequestHandler{FindAllBuscadorQuery, IList{ViewBuscador}}"/>
/// </summary>
public class FindAllBuscadorHandler : IRequestHandler<FindAllBuscadorQuery, IList<ViewBuscador>>
{
    private readonly IBuscadorManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="FindAllBuscadorHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IBuscadorManager"/></param>    
    public FindAllBuscadorHandler(IBuscadorManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="FindAllBuscadorQuery"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{IList{ViewBuscador}}"/></returns>
    public async Task<IList<ViewBuscador>> Handle(FindAllBuscadorQuery request, CancellationToken cancellationToken)
    {
        var dtos = await Manager.FindAllBuscador();

        return [.. dtos.Select(x => x.ToViewModel())];
    }
}