using MediatR;
using Sandwitch.Application.Commands.Town;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;
using Entities = Sandwitch.Domain.Entities;

namespace Sandwitch.Application.Handlers.Town;

/// <summary>
/// Represents a <see cref="UpdateTownHandler"/>. Implements <see cref="IRequestHandler{UpdateTownCommand, ViewTown}"/>
/// </summary>
public class UpdateTownHandler : IRequestHandler<UpdateTownCommand, ViewTown>
{
    private readonly ITownManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="UpdateTownHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="ITownManager"/></param>
    /// <param name="mapper">Injected <see cref="IMapper"/></param>
    public UpdateTownHandler(ITownManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="UpdateTownCommand"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{ViewTown}"/></returns>
    public async Task<ViewTown> Handle(UpdateTownCommand request, CancellationToken cancellationToken)
    {
        var @Town = new Entities.Town
        {
            Id = request.ViewModel.Id,
            Name = request.ViewModel.Name,
            ImageUri = request.ViewModel.ImageUri,
            StateId = request.ViewModel.Id,
        };

        var @entity = await Manager.UpdateTown(@Town);

        var @dto = await Manager.ReloadTownById(@entity.Id);

        return @dto.ToViewModel();
    }
}