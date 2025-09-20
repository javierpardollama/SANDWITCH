using AutoMapper;
using MediatR;
using Sandwitch.Application.Queries.Viento;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Viento;

/// <summary>
/// Represents a <see cref="FindPaginatedVientoHandler"/>. Implements <see cref="IRequestHandler{FindPaginatedVientoQuery, ViewPage{ViewViento}}"/>
/// </summary>
public class FindPaginatedVientoHandler : IRequestHandler<FindPaginatedVientoQuery, ViewPage<ViewViento>>
{
    private readonly IVientoManager Manager;
    private readonly IMapper Mapper;

    /// <summary>
    ///  Initializes a new Instance of <see cref="FindPaginatedVientoHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IVientoManager"/></param>
    /// <param name="mapper">Injected <see cref="IMapper"/></param>
    public FindPaginatedVientoHandler(IVientoManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="FindPaginatedVientoQuery"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{ViewPage{ViewViento}}"/></returns>
    public async Task<ViewPage<ViewViento>> Handle(FindPaginatedVientoQuery request,
        CancellationToken cancellationToken)
    {
        var result = await Manager.FindPaginatedViento(request.ViewModel);

        return Mapper.Map<ViewPage<ViewViento>>(result);
    }
}