using AutoMapper;
using MediatR;
using Sandwitch.Application.Queries.Viento;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Viento;

public class FindPaginatedVientoHandler : IRequestHandler<FindPaginatedVientoQuery, ViewPage<ViewViento>>
{
    private readonly IVientoManager Manager;
    private readonly IMapper Mapper;

    public FindPaginatedVientoHandler(IVientoManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
    }

    public async Task<ViewPage<ViewViento>> Handle(FindPaginatedVientoQuery request,
        CancellationToken cancellationToken)
    {
        var result = await Manager.FindPaginatedViento(request.ViewModel);

        return Mapper.Map<ViewPage<ViewViento>>(result);
    }
}