using AutoMapper;
using MediatR;
using Sandwitch.Application.Queries.Buscador;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Buscador;

public class FindAllArenalByBuscadorIdHandler : IRequestHandler<FindAllArenalByBuscadorIdQuery, IList<ViewArenal>>
{
    private readonly IBuscadorManager Manager;
    private readonly IMapper Mapper;

    public FindAllArenalByBuscadorIdHandler(IBuscadorManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
    }

    public async Task<IList<ViewArenal>> Handle(FindAllArenalByBuscadorIdQuery request,
        CancellationToken cancellationToken)
    {
        var result = await Manager.FindAllArenalByBuscadorId(request.ViewModel);

        return Mapper.Map<IList<ViewArenal>>(result);
    }
}