using AutoMapper;
using MediatR;
using Sandwitch.Application.Queries.Bandera;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Bandera;

/// <summary>
/// Represents a <see cref="FindPaginatedBanderaHandler"/>. Implements <see cref="IRequestHandler{FindPaginatedBanderaQuery, ViewPage{ViewBandera}}"/>
/// </summary>
public class FindPaginatedBanderaHandler : IRequestHandler<FindPaginatedBanderaQuery, ViewPage<ViewBandera>>
{
    private readonly IBanderaManager Manager;
    private readonly IMapper Mapper;

    /// <summary>
    ///  Initializes a new Instance of <see cref="FindPaginatedBanderaHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IBanderaManager"/></param>
    /// <param name="mapper">Injected <see cref="IMapper"/></param>
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