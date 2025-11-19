using MediatR;
using Sandwitch.Application.Commands.Historico;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;
using Entities = Sandwitch.Domain.Entities;

namespace Sandwitch.Application.Handlers.Historico;

/// <summary>
/// Represents a <see cref="AddHistoricoHandler"/>. Implements <see cref="IRequestHandler{AddHistoricoCommand, ViewHistorico}"/>
/// </summary>
public class AddHistoricoHandler : IRequestHandler<AddHistoricoCommand, ViewHistorico>
{
    private readonly IHistoricoManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="AddHistoricoHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IHistoricoManager"/></param>       
    public AddHistoricoHandler(IHistoricoManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="AddHistoricoCommand"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{ViewHistorico}"/></returns>
    public async Task<ViewHistorico> Handle(AddHistoricoCommand request, CancellationToken cancellationToken)
    {
        var @historico = new Entities.Historico()
        {
            ArenalId = request.ViewModel.ArenalId,
            BanderaId = request.ViewModel.BanderaId,
            VientoId = request.ViewModel.VientoId,
            Velocidad = request.ViewModel.Velocidad,
            BajaMarAlba = request.ViewModel.BajaMarAlba,
            BajaMarOcaso = request.ViewModel.BajaMarOcaso,
            AltaMarAlba = request.ViewModel.AltaMarAlba,
            AltaMarOcaso = request.ViewModel.AltaMarOcaso,
            Temperatura = request.ViewModel.Temperatura
        };

        var @entity = await Manager.AddHistorico(@historico);

        var @dto = await Manager.ReloadHistoricoById(@entity.Id);

        return @dto.ToViewModel();
    }
}
