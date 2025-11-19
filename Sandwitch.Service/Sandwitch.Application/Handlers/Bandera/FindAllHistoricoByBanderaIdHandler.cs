using MediatR;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.Queries.Bandera;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Bandera;

/// <summary>
/// Represents a <see cref="FindAllHistoricoByBanderaIdHandler"/>. Implements <see cref="IRequestHandler{FindAllHistoricoByBanderaIdQuery, IList{ViewHistorico}}"/>
/// </summary>
public class FindAllHistoricoByBanderaIdHandler : IRequestHandler<FindAllHistoricoByBanderaIdQuery, IList<ViewHistorico>>
{
    private readonly IBanderaManager Manager;
    /// <summary>
    ///  Initializes a new Instance of <see cref="FindAllHistoricoByBanderaIdHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IBanderaManager"/></param>
    public FindAllHistoricoByBanderaIdHandler(IBanderaManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="FindAllHistoricoByBanderaIdQuery"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{IList{ViewHistorico}}"/></returns>
    public async Task<IList<ViewHistorico>> Handle(FindAllHistoricoByBanderaIdQuery request,
        CancellationToken cancellationToken)
    {
        var dtos = await Manager.FindAllHistoricoByBanderaId(request.Id);

        return [.. dtos.Select(x => x.ToViewModel())];
    }
}