using MediatR;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.Queries.Beach;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Beach;

/// <summary>
/// Represents a <see cref="AddBeachHandler"/>. Implements <see cref="IRequestHandler{FindAllHistoricByBeachIdQuery, IList{ViewHistoric}}"/>
/// </summary>
public class FindAllHistoricByBeachIdHandler : IRequestHandler<FindAllHistoricByBeachIdQuery, IList<ViewHistoric>>
{
    private readonly IBeachManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="FindAllHistoricByBeachIdHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IBeachManager"/></param>
    public FindAllHistoricByBeachIdHandler(IBeachManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="FindAllHistoricByBeachIdQuery"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{IList{ViewHistoric}}"/></returns>
    public async Task<IList<ViewHistoric>> Handle(FindAllHistoricByBeachIdQuery request,
        CancellationToken cancellationToken)
    {
        var dtos = await Manager.FindAllHistoricByBeachId(request.Id);

        return [.. dtos.Select(x => x.ToViewModel())];
    }
}