using AutoMapper;
using MediatR;
using Sandwitch.Application.Queries.Buscador;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Buscador;

/// <summary>
/// Represents a <see cref="FindAllArenalByBuscadorIdHandler"/>. Implements <see cref="IRequestHandler{FindAllArenalByBuscadorIdQuery, IList{ViewArenal}}"/>
/// </summary>
public class FindAllArenalByBuscadorIdHandler : IRequestHandler<FindAllArenalByBuscadorIdQuery, IList<ViewArenal>>
{
    private readonly IBuscadorManager Manager;
    private readonly IMapper Mapper;

    /// <summary>
    ///  Initializes a new Instance of <see cref="FindAllArenalByBuscadorIdHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IBuscadorManager"/></param>
    /// <param name="mapper">Injected <see cref="IMapper"/></param>
    public FindAllArenalByBuscadorIdHandler(IBuscadorManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
    }

    /// <summary>
    /// Handles
    /// </summary>
    /// <param name="request">Injected <see cref="FindAllArenalByBuscadorIdQuery"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{IList{ViewArenal}}"/></returns>
    public async Task<IList<ViewArenal>> Handle(FindAllArenalByBuscadorIdQuery request,
        CancellationToken cancellationToken)
    {
        var result = await Manager.FindAllArenalByBuscadorId(request.ViewModel);

        return Mapper.Map<IList<ViewArenal>>(result);
    }
}