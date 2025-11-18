using MediatR;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.Queries.Arenal;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Arenal;

/// <summary>
/// Represents a <see cref="AddArenalHandler"/>. Implements <see cref="IRequestHandler{FindAllHistoricoByArenalIdQuery, IList{ViewHistorico}}"/>
/// </summary>
public class FindAllHistoricoByArenalIdHandler : IRequestHandler<FindAllHistoricoByArenalIdQuery, IList<ViewHistorico>>
{
    private readonly IArenalManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="FindAllHistoricoByArenalIdHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IArenalManager"/></param>
    public FindAllHistoricoByArenalIdHandler(IArenalManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="FindAllHistoricoByArenalIdQuery"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{IList{ViewHistorico}}"/></returns>
    public async Task<IList<ViewHistorico>> Handle(FindAllHistoricoByArenalIdQuery request,
        CancellationToken cancellationToken)
    {
        var dtos = await Manager.FindAllHistoricoByArenalId(request.Id);

        return [.. dtos.Select(x => x.ToViewModel())];
    }
}