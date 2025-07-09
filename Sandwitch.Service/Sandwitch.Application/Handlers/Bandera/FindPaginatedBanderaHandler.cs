using AutoMapper;
using MediatR;
using Sandwitch.Application.Queries.Bandera;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Bandera;

public class FindPaginatedBanderaHandler : IRequestHandler<FindPaginatedBanderaQuery, ViewPage<ViewBandera>>
{
    private readonly IBanderaManager Manager;
    private readonly IMapper Mapper;

    public FindPaginatedBanderaHandler(IBanderaManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
    }

    public async Task<ViewPage<ViewBandera>> Handle(FindPaginatedBanderaQuery request,
        CancellationToken cancellationToken)
    {
        var result = await Manager.FindPaginatedBandera(request.ViewModel);

        return Mapper.Map<ViewPage<ViewBandera>>(result);
    }
}