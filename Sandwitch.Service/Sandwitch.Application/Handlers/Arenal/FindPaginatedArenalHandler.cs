using AutoMapper;
using MediatR;
using Sandwitch.Application.Queries.Arenal;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Arenal;

/// <summary>
/// Represents a <see cref="FindPaginatedArenalHandler"/>. Implements <see cref="IRequestHandler{FindPaginatedArenalQuery, ViewPage{ViewArenal}}"/>
/// </summary>
public class FindPaginatedArenalHandler : IRequestHandler<FindPaginatedArenalQuery, ViewPage<ViewArenal>>
{
    private readonly IArenalManager Manager;
    private readonly IMapper Mapper;

    /// <summary>
    ///  Initializes a new Instance of <see cref="FindPaginatedArenalHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IArenalManager"/></param>
    /// <param name="mapper">Injected <see cref="IMapper"/></param>
    public FindPaginatedArenalHandler(IArenalManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
    }

    /// <summary>
    /// Handles
    /// </summary>
    /// <param name="request">Injected <see cref="FindPaginatedArenalQuery"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{ViewPage{ViewArenal}}"/></returns>
    public async Task<ViewPage<ViewArenal>> Handle(FindPaginatedArenalQuery request,
        CancellationToken cancellationToken)
    {
        var result = await Manager.FindPaginatedArenal(request.ViewModel);

        return Mapper.Map<ViewPage<ViewArenal>>(result);
    }
}