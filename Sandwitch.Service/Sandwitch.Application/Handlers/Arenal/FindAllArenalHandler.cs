using MediatR;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.Queries.Arenal;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Arenal;

/// <summary>
/// Represents a <see cref="AddArenalHandler"/>. Implements <see cref="IRequestHandler{FindAllArenalQuery, IList{ViewCatalog}}"/>
/// </summary>
public class FindAllArenalHandler : IRequestHandler<FindAllArenalQuery, IList<ViewCatalog>>
{
    private readonly IArenalManager Manager;   

    /// <summary>
    ///  Initializes a new Instance of <see cref="FindAllArenalHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IArenalManager"/></param>    
    public FindAllArenalHandler(IArenalManager manager)
    {
        Manager = manager;       
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="FindAllArenalQuery"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{IList{ViewCatalog}}"/></returns>
    public async Task<IList<ViewCatalog>> Handle(FindAllArenalQuery request, CancellationToken cancellationToken)
    {
        var dtos = await Manager.FindAllArenal();       

        return [.. dtos.Select(x => x.ToViewModel())];
    }
}