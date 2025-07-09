using AutoMapper;
using MediatR;
using Sandwitch.Application.Queries.Provincia;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Provincia;

public class FindPaginatedProvinciaHandler : IRequestHandler<FindPaginatedProvinciaQuery, ViewPage<ViewProvincia>>
{
    private readonly IProvinciaManager Manager;
    private readonly IMapper Mapper;

    public FindPaginatedProvinciaHandler(IProvinciaManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
    }

    public async Task<ViewPage<ViewProvincia>> Handle(FindPaginatedProvinciaQuery request,
        CancellationToken cancellationToken)
    {
        var result = await Manager.FindPaginatedProvincia(request.ViewModel);

        return Mapper.Map<ViewPage<ViewProvincia>>(result);
    }
}