using MediatR;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.Queries.Provincia;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Provincia;

/// <summary>
/// Represents a <see cref="FindAllProvinciaHandler"/>. Implements <see cref="IRequestHandler{FindAllProvinciaQuery, IList{ViewProvincia}}"/>
/// </summary>
public class FindAllProvinciaHandler : IRequestHandler<FindAllProvinciaQuery, IList<ViewCatalog>>
{
    private readonly IProvinciaManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="FindAllProvinciaHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IProvinciaManager"/></param>
    public FindAllProvinciaHandler(IProvinciaManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="FindAllProvinciaQuery"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{List{ViewCatalog}}"/></returns>
    public async Task<IList<ViewCatalog>> Handle(FindAllProvinciaQuery request, CancellationToken cancellationToken)
    {
        var dtos = await Manager.FindAllProvincia();

        return [.. dtos.Select(x => x.ToViewModel())];
    }
}