using MediatR;
using Sandwitch.Application.Commands.Town;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;
using Entities = Sandwitch.Domain.Entities;

namespace Sandwitch.Application.Handlers.Town;

/// <summary>
/// Represents a <see cref="AddTownHandler"/>. Implements <see cref="IRequestHandler{AddTownCommand, ViewTown}"/>
/// </summary>
public class AddTownHandler : IRequestHandler<AddTownCommand, ViewTown>
{
    private readonly ITownManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="AddTownHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="ITownManager"/></param>
    public AddTownHandler(ITownManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="AddTownCommand"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{ViewTown}"/></returns>
    public async Task<ViewTown> Handle(AddTownCommand request, CancellationToken cancellationToken)
    {
        var @Town = new Entities.Town
        {
            Name = request.ViewModel.Name,
            ImageUri = request.ViewModel.ImageUri,    
            StateId = request.ViewModel.StateId,
        };

        var @entity = await Manager.AddTown(@Town);

        var @dto = await Manager.ReloadTownById(@entity.Id);

        return @dto.ToViewModel();
    }
}