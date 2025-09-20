using AutoMapper;
using MediatR;
using Sandwitch.Application.Queries.Buscador;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Buscador;

/// <summary>
/// Represents a <see cref="FindAllBuscadorHandler"/>. Implements <see cref="IRequestHandler{FindAllBuscadorQuery, IList{ViewBuscador}}"/>
/// </summary>
public class FindAllBuscadorHandler : IRequestHandler<FindAllBuscadorQuery, IList<ViewBuscador>>
{
    private readonly IBuscadorManager Manager;
    private readonly IMapper Mapper;

    /// <summary>
    ///  Initializes a new Instance of <see cref="FindAllBuscadorHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IBuscadorManager"/></param>
    /// <param name="mapper">Injected <see cref="IMapper"/></param>
    public FindAllBuscadorHandler(IBuscadorManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="FindAllBuscadorQuery"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{IList{ViewBuscador}}"/></returns>
    public async Task<IList<ViewBuscador>> Handle(FindAllBuscadorQuery request, CancellationToken cancellationToken)
    {
        var result = await Manager.FindAllBuscador();

        return Mapper.Map<IList<ViewBuscador>>(result);
    }
}