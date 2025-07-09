using AutoMapper;
using MediatR;
using Sandwitch.Application.Queries.Poblacion;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Poblacion;

public class FindPaginatedPoblacionHandler : IRequestHandler<FindPaginatedPoblacionQuery, ViewPage<ViewPoblacion>>
{
    private readonly IPoblacionManager Manager;
    private readonly IMapper Mapper;

    public FindPaginatedPoblacionHandler(IPoblacionManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
    }

    public async Task<ViewPage<ViewPoblacion>> Handle(FindPaginatedPoblacionQuery request,
        CancellationToken cancellationToken)
    {
        var result = await Manager.FindPaginatedPoblacion(request.ViewModel);

        return Mapper.Map<ViewPage<ViewPoblacion>>(result);
    }
}