using AutoMapper;
using MediatR;
using Sandwitch.Application.Queries.Poblacion;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Poblacion;

/// <summary>
/// Represents a <see cref="FindPaginatedPoblacionHandler"/>. Implements <see cref="IRequestHandler{FindPaginatedPoblacionQuery, ViewPage{ViewPoblacion}}"/>
/// </summary>
public class FindPaginatedPoblacionHandler : IRequestHandler<FindPaginatedPoblacionQuery, ViewPage<ViewPoblacion>>
{
    private readonly IPoblacionManager Manager;
    private readonly IMapper Mapper;

    /// <summary>
    ///  Initializes a new Instance of <see cref="FindPaginatedPoblacionHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IPoblacionManager"/></param>
    /// <param name="mapper">Injected <see cref="IMapper"/></param>
    public FindPaginatedPoblacionHandler(IPoblacionManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
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
        var result = await Manager.FindPaginatedPoblacion(request.ViewModel);

        return Mapper.Map<ViewPage<ViewPoblacion>>(result);
    }
}