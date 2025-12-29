using MediatR;
using Sandwitch.Application.Commands.State;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.State;

/// <summary>
/// Represents a <see cref="RemoveStateByIdHandler"/>. Implements <see cref="IRequestHandler{RemoveStateByIdCommand}"/>
/// </summary>
public class RemoveStateByIdHandler : IRequestHandler<RemoveStateByIdCommand>
{
    private readonly IStateManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="RemoveStateByIdHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IStateManager"/></param>
    public RemoveStateByIdHandler(IStateManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="RemoveStateByIdCommand"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task"/></returns>
    public async Task Handle(RemoveStateByIdCommand request, CancellationToken cancellationToken)
    {
        await Manager.RemoveStateById(request.Id);
    }
}