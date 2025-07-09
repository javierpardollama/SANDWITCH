using AutoMapper;
using MediatR;
using Sandwitch.Application.Queries.Arenal;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Arenal;

public class FindAllArenalHandler : IRequestHandler<FindAllArenalQuery, IList<ViewArenal>>
{
    private readonly IArenalManager Manager;
    private readonly IMapper Mapper;

    public FindAllArenalHandler(IArenalManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
    }

    public async Task<IList<ViewArenal>> Handle(FindAllArenalQuery request, CancellationToken cancellationToken)
    {
        var result = await Manager.FindAllArenal();

        return Mapper.Map<IList<ViewArenal>>(result);
    }
}