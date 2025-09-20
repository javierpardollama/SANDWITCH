using AutoMapper;
using MediatR;
using Sandwitch.Application.Queries.Provincia;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Provincia;

/// <summary>
/// Represents a <see cref="FindPaginatedProvinciaHandler"/>. Implements <see cref="IRequestHandler{FindPaginatedProvinciaQuery, ViewPage{ViewProvincia}}"/>
/// </summary>
public class FindPaginatedProvinciaHandler : IRequestHandler<FindPaginatedProvinciaQuery, ViewPage<ViewProvincia>>
{
    private readonly IProvinciaManager Manager;
    private readonly IMapper Mapper;

    /// <summary>
    ///  Initializes a new Instance of <see cref="FindPaginatedProvinciaHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IProvinciaManager"/></param>
    /// <param name="mapper">Injected <see cref="IMapper"/></param>
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