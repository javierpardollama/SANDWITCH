using AutoMapper;
using MediatR;
using Sandwitch.Application.Queries.Arenal;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Arenal;

public class FindPaginatedArenalHandler : IRequestHandler<FindPaginatedArenalQuery, ViewPage<ViewArenal>>
{
    private readonly IArenalManager Manager;
    private readonly IMapper Mapper;

    public FindPaginatedArenalHandler(IArenalManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
    }

    public async Task<ViewPage<ViewArenal>> Handle(FindPaginatedArenalQuery request,
        CancellationToken cancellationToken)
    {
        var result = await Manager.FindPaginatedArenal(request.ViewModel);

        return Mapper.Map<ViewPage<ViewArenal>>(result);
    }
}