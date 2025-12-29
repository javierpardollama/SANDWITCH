using MediatR;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.Queries.Beach;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Beach;

/// <summary>
/// Represents a <see cref="AddBeachHandler"/>. Implements <see cref="IRequestHandler{FindAllBeachQuery, IList{ViewCatalog}}"/>
/// </summary>
public class FindAllBeachHandler : IRequestHandler<FindAllBeachQuery, IList<ViewCatalog>>
{
    private readonly IBeachManager Manager;   

    /// <summary>
    ///  Initializes a new Instance of <see cref="FindAllBeachHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IBeachManager"/></param>    
    public FindAllBeachHandler(IBeachManager manager)
    {
        Manager = manager;       
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="FindAllBeachQuery"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{IList{ViewCatalog}}"/></returns>
    public async Task<IList<ViewCatalog>> Handle(FindAllBeachQuery request, CancellationToken cancellationToken)
    {
        var dtos = await Manager.FindAllBeach();       

        return [.. dtos.Select(x => x.ToViewModel())];
    }
}