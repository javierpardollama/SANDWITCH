using AutoMapper;
using MediatR;
using Sandwitch.Application.Queries.Buscador;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Buscador;

public class FindAllBuscadorHandler : IRequestHandler<FindAllBuscadorQuery, IList<ViewBuscador>>
{
    private readonly IBuscadorManager Manager;
    private readonly IMapper Mapper;

    public FindAllBuscadorHandler(IBuscadorManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
    }

    public async Task<IList<ViewBuscador>> Handle(FindAllBuscadorQuery request, CancellationToken cancellationToken)
    {
        var result = await Manager.FindAllBuscador();

        return Mapper.Map<IList<ViewBuscador>>(result);
    }
}