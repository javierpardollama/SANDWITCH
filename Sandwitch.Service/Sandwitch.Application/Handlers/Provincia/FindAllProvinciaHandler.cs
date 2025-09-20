using AutoMapper;
using MediatR;
using Sandwitch.Application.Queries.Provincia;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Provincia;

/// <summary>
/// Represents a <see cref="FindAllProvinciaHandler"/>. Implements <see cref="IRequestHandler{FindAllProvinciaQuery, IList{ViewProvincia}}"/>
/// </summary>
public class FindAllProvinciaHandler : IRequestHandler<FindAllProvinciaQuery, IList<ViewProvincia>>
{
    private readonly IProvinciaManager Manager;
    private readonly IMapper Mapper;

    /// <summary>
    ///  Initializes a new Instance of <see cref="FindAllProvinciaHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IProvinciaManager"/></param>
    /// <param name="mapper">Injected <see cref="IMapper"/></param>
    public FindAllProvinciaHandler(IProvinciaManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
    }

    /// <summary>
    /// Handles
    /// </summary>
    /// <param name="request">Injected <see cref="FindAllProvinciaQuery"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{List{ViewProvincia}}"/></returns>
    public async Task<IList<ViewProvincia>> Handle(FindAllProvinciaQuery request, CancellationToken cancellationToken)
    {
        var result = await Manager.FindAllProvincia();

        return Mapper.Map<IList<ViewProvincia>>(result);
    }
}