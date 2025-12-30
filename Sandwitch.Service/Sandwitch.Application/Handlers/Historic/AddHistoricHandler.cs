using MediatR;
using Sandwitch.Application.Commands.Historic;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;
using Entities = Sandwitch.Domain.Entities;

namespace Sandwitch.Application.Handlers.Historic;

/// <summary>
/// Represents a <see cref="AddHistoricHandler"/>. Implements <see cref="IRequestHandler{AddHistoricCommand, ViewHistoric}"/>
/// </summary>
public class AddHistoricHandler : IRequestHandler<AddHistoricCommand, ViewHistoric>
{
    private readonly IHistoricManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="AddHistoricHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IHistoricManager"/></param>       
    public AddHistoricHandler(IHistoricManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="AddHistoricCommand"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{ViewHistoric}"/></returns>
    public async Task<ViewHistoric> Handle(AddHistoricCommand request, CancellationToken cancellationToken)
    {
        var @Historic = new Entities.Historic()
        {
            BeachId = request.ViewModel.BeachId,
            FlagId = request.ViewModel.FlagId,
            WindId = request.ViewModel.WindId,
            Speed = request.ViewModel.Speed,
            LowSeaDawn = request.ViewModel.LowSeaDawn,
            LowSeaSunset = request.ViewModel.LowSeaSunset,
            HighSeaDawn = request.ViewModel.HighSeaDawn,
            HighSeaSunset = request.ViewModel.HighSeaSunset,
            Temperature = request.ViewModel.Temperature
        };

        var @entity = await Manager.AddHistoric(@Historic);

        var @dto = await Manager.ReloadHistoricById(@entity.Id);

        return @dto.ToViewModel();
    }
}
