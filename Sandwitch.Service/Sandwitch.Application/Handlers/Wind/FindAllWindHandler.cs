using MediatR;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.Queries.Wind;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Wind;

/// <summary>
/// Represents a <see cref="FindAllWindHandler"/>. Implements <see cref="IRequestHandler{FindAllWindQuery, IList{ViewCatalog}}"/>
/// </summary>
public class FindAllWindHandler : IRequestHandler<FindAllWindQuery, IList<ViewCatalog>>
{
    private readonly IWindManager Manager;   

    /// <summary>
    ///  Initializes a new Instance of <see cref="FindAllWindHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IWindManager"/></param>
    public FindAllWindHandler(IWindManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="FindAllWindQuery"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{IList{ViewWind}}"/></returns>
    public async Task<IList<ViewCatalog>> Handle(FindAllWindQuery request, CancellationToken cancellationToken)
    {
        var dtos = await Manager.FindAllWind();

        return [.. dtos.Select(x => x.ToViewModel())];
    }
}