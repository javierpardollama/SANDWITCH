using AutoMapper;
using MediatR;
using Sandwitch.Application.Queries.Poblacion;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Poblacion;

/// <summary>
/// Represents a <see cref="FindAllPoblacionHandler"/>. Implements <see cref="IRequestHandler{FindAllPoblacionQuery, IList{ViewPoblacion}}"/>
/// </summary>
public class FindAllPoblacionHandler : IRequestHandler<FindAllPoblacionQuery, IList<ViewPoblacion>>
{
    private readonly IPoblacionManager Manager;
    private readonly IMapper Mapper;

    /// <summary>
    ///  Initializes a new Instance of <see cref="FindAllPoblacionHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IPoblacionManager"/></param>
    /// <param name="mapper">Injected <see cref="IMapper"/></param>
    public FindAllPoblacionHandler(IPoblacionManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
    }

    public async Task<IList<ViewPoblacion>> Handle(FindAllPoblacionQuery request, CancellationToken cancellationToken)
    {
        var result = await Manager.FindAllPoblacion();

        return Mapper.Map<IList<ViewPoblacion>>(result);
    }
}