using MediatR;
using Sandwitch.Application.Commands.State;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;
using Entities = Sandwitch.Domain.Entities;

namespace Sandwitch.Application.Handlers.State;

/// <summary>
/// Represents a <see cref="AddStateHandler"/>. Implements <see cref="IRequestHandler{AddStateCommand, ViewState}"/>
/// </summary>
public class AddStateHandler : IRequestHandler<AddStateCommand, ViewState>
{
    private readonly IStateManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="AddStateHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IStateManager"/></param>
    public AddStateHandler(IStateManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="AddStateCommand"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{ViewState}"/></returns>
    public async Task<ViewState> Handle(AddStateCommand request, CancellationToken cancellationToken)
    {
        var @State = new Entities.State
        {
            Name = request.ViewModel.Name,
            ImageUri = request.ViewModel.ImageUri,
        };

        var @entity = await Manager.AddState(State);

        var @dto = await Manager.ReloadStateById(@entity.Id);

        return @dto.ToViewModel();
    }
}