using AutoMapper;
using MediatR;
using Sandwitch.Application.Queries.Bandera;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Bandera;

public class FindAllBanderaHandler : IRequestHandler<FindAllBanderaQuery, IList<ViewBandera>>
{
    private readonly IBanderaManager Manager;
    private readonly IMapper Mapper;

    public FindAllBanderaHandler(IBanderaManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
    }

    public async Task<IList<ViewBandera>> Handle(FindAllBanderaQuery request, CancellationToken cancellationToken)
    {
        var result = await Manager.FindAllBandera();

        return Mapper.Map<IList<ViewBandera>>(result);
    }
}