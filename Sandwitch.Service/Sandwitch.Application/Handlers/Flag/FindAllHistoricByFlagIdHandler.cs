using MediatR;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.Queries.Flag;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Flag;

/// <summary>
/// Represents a <see cref="FindAllHistoricByFlagIdHandler"/>. Implements <see cref="IRequestHandler{FindAllHistoricByFlagIdQuery, IList{ViewHistoric}}"/>
/// </summary>
public class FindAllHistoricByFlagIdHandler : IRequestHandler<FindAllHistoricByFlagIdQuery, IList<ViewHistoric>>
{
    private readonly IFlagManager Manager;
    /// <summary>
    ///  Initializes a new Instance of <see cref="FindAllHistoricByFlagIdHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IFlagManager"/></param>
    public FindAllHistoricByFlagIdHandler(IFlagManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="FindAllHistoricByFlagIdQuery"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{IList{ViewHistoric}}"/></returns>
    public async Task<IList<ViewHistoric>> Handle(FindAllHistoricByFlagIdQuery request,
        CancellationToken cancellationToken)
    {
        var dtos = await Manager.FindAllHistoricByFlagId(request.Id);

        return [.. dtos.Select(x => x.ToViewModel())];
    }
}