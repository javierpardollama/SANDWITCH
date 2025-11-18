using MediatR;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.Queries.Poblacion;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Poblacion;

/// <summary>
/// Represents a <see cref="FindAllPoblacionHandler"/>. Implements <see cref="IRequestHandler{FindAllPoblacionQuery, IList{ViewCatalog}}"/>
/// </summary>
public class FindAllPoblacionHandler : IRequestHandler<FindAllPoblacionQuery, IList<ViewCatalog>>
{
    private readonly IPoblacionManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="FindAllPoblacionHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IPoblacionManager"/></param>
    /// <param name="mapper">Injected <see cref="IMapper"/></param>
    public FindAllPoblacionHandler(IPoblacionManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="FindAllPoblacionQuery"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{IList{ViewPoblacion}}"/></returns>
    public async Task<IList<ViewCatalog>> Handle(FindAllPoblacionQuery request, CancellationToken cancellationToken)
    {
        var dtos = await Manager.FindAllPoblacion();

        return [.. dtos.Select(x => x.ToViewModel())];
    }
}