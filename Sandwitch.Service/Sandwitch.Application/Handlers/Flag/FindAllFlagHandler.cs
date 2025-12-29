using MediatR;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.Queries.Flag;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Flag;

/// <summary>
/// Represents a <see cref="FindAllFlagHandler"/>. Implements <see cref="IRequestHandler{FindAllFlagQuery,  IList{ViewFlag}}"/>
/// </summary>
public class FindAllFlagHandler : IRequestHandler<FindAllFlagQuery, IList<ViewCatalog>>
{
    private readonly IFlagManager Manager;   

    /// <summary>
    ///  Initializes a new Instance of <see cref="FindAllFlagHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IFlagManager"/></param>
    public FindAllFlagHandler(IFlagManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="FindAllFlagQuery"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{IList{ViewCatalog}}"/></returns>
    public async Task<IList<ViewCatalog>> Handle(FindAllFlagQuery request, CancellationToken cancellationToken)
    {
        var dtos = await Manager.FindAllFlag();

        return [.. dtos.Select(x => x.ToViewModel())];
    }
}