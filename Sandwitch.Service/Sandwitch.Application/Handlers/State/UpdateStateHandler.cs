using MediatR;
using Sandwitch.Application.Commands.State;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;
using Entities = Sandwitch.Domain.Entities;

namespace Sandwitch.Application.Handlers.State;

/// <summary>
/// Represents a <see cref="UpdateStateHandler"/>. Implements <see cref="IRequestHandler{UpdateStateCommand, ViewState}"/>
/// </summary>
public class UpdateStateHandler : IRequestHandler<UpdateStateCommand, ViewState>
{
    private readonly IStateManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="UpdateStateHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IStateManager"/></param>
    /// <param name="mapper">Injected <see cref="IMapper"/></param>
    public UpdateStateHandler(IStateManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="UpdateStateCommand"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{ViewState}"/></returns>
    public async Task<ViewState> Handle(UpdateStateCommand request, CancellationToken cancellationToken)
    {
        var @State = new Entities.State
        {
            Id = request.ViewModel.Id,
            Name = request.ViewModel.Name,
            ImageUri = request.ViewModel.ImageUri,
        };

        var @entity = await Manager.UpdateState(@State);

        var @dto = await Manager.ReloadStateById(@entity.Id);

        return @dto.ToViewModel();
    }
}