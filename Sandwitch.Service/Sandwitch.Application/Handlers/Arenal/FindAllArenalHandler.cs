using AutoMapper;
using MediatR;
using Sandwitch.Application.Queries.Arenal;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Arenal;

/// <summary>
/// Represents a <see cref="AddArenalHandler"/>. Implements <see cref="IRequestHandler{FindAllArenalQuery, IList{ViewArenal}}"/>
/// </summary>
public class FindAllArenalHandler : IRequestHandler<FindAllArenalQuery, IList<ViewArenal>>
{
    private readonly IArenalManager Manager;
    private readonly IMapper Mapper;

    /// <summary>
    ///  Initializes a new Instance of <see cref="FindAllArenalHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IArenalManager"/></param>
    /// <param name="mapper">Injected <see cref="IMapper"/></param>
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