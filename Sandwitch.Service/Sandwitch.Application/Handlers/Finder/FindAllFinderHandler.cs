using MediatR;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.Queries.Finder;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Finder;

/// <summary>
/// Represents a <see cref="FindAllFinderHandler"/>. Implements <see cref="IRequestHandler{FindAllFinderQuery, IList{ViewFinder}}"/>
/// </summary>
public class FindAllFinderHandler : IRequestHandler<FindAllFinderQuery, IList<ViewFinder>>
{
    private readonly IFinderManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="FindAllFinderHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IFinderManager"/></param>    
    public FindAllFinderHandler(IFinderManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="FindAllFinderQuery"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{IList{ViewFinder}}"/></returns>
    public async Task<IList<ViewFinder>> Handle(FindAllFinderQuery request, CancellationToken cancellationToken)
    {
        var dtos = await Manager.FindAllFinder();

        return [.. dtos.Select(x => x.ToViewModel())];
    }
}