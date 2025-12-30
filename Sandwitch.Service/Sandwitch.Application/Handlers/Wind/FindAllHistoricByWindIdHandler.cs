using MediatR;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.Queries.Flag;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Wind;

/// <summary>
/// Represents a <see cref="FindAllHistoricByWindIdHandler"/>. Implements <see cref="IRequestHandler{FindAllHistoricByFlagIdQuery, IList{ViewHistoric}}"/>
/// </summary>
public class FindAllHistoricByWindIdHandler : IRequestHandler<FindAllHistoricByFlagIdQuery, IList<ViewHistoric>>
{
    private readonly IWindManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="FindAllHistoricByWindIdHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IWindManager"/></param>
    public FindAllHistoricByWindIdHandler(IWindManager manager)
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
        var dtos = await Manager.FindAllHistoricByWindId(request.Id);

        return [.. dtos.Select(x => x.ToViewModel())];
    }
}