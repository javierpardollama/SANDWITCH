using MediatR;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.Queries.Bandera;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Viento;

/// <summary>
/// Represents a <see cref="FindAllHistoricoByVientoIdHandler"/>. Implements <see cref="IRequestHandler{FindAllHistoricoByBanderaIdQuery, IList{ViewHistorico}}"/>
/// </summary>
public class FindAllHistoricoByVientoIdHandler : IRequestHandler<FindAllHistoricoByBanderaIdQuery, IList<ViewHistorico>>
{
    private readonly IVientoManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="FindAllHistoricoByVientoIdHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IVientoManager"/></param>
    public FindAllHistoricoByVientoIdHandler(IVientoManager manager)
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
        var dtos = await Manager.FindAllHistoricoByVientoId(request.Id);

        return [.. dtos.Select(x => x.ToViewModel())];
    }
}