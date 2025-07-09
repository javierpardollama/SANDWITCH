using AutoMapper;
using MediatR;
using Sandwitch.Application.Queries.Poblacion;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Poblacion;

public class FindAllPoblacionHandler : IRequestHandler<FindAllPoblacionQuery, IList<ViewPoblacion>>
{
    private readonly IPoblacionManager Manager;
    private readonly IMapper Mapper;

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