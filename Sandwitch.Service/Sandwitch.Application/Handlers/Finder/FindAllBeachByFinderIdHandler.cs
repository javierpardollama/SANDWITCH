using MediatR;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.Queries.Finder;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Finder;

/// <summary>
/// Represents a <see cref="FindAllBeachByFinderIdHandler"/>. Implements <see cref="IRequestHandler{FindAllBeachByFinderIdQuery, IList{ViewBeach}}"/>
/// </summary>
public class FindAllBeachByFinderIdHandler : IRequestHandler<FindAllBeachByFinderIdQuery, IList<ViewBeach>>
{
    private readonly IFinderManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="FindAllBeachByFinderIdHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IFinderManager"/></param>
    public FindAllBeachByFinderIdHandler(IFinderManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="FindAllBeachByFinderIdQuery"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{IList{ViewBeach}}"/></returns>
    public async Task<IList<ViewBeach>> Handle(FindAllBeachByFinderIdQuery request,
        CancellationToken cancellationToken)
    {
        var dtos = await Manager.FindAllBeachByFinderId(request.ViewModel.Id, request.ViewModel.Group);

        return [.. dtos.Select(x => x.ToViewModel())];
    }
}