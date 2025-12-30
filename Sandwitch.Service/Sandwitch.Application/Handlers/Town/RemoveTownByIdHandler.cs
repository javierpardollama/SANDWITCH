using MediatR;
using Sandwitch.Application.Commands.Town;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Town;

/// <summary>
/// Represents a <see cref="RemoveTownByIdHandler"/>. Implements <see cref="IRequestHandler{RemoveTownByIdCommand}"/>
/// </summary>
public class RemoveTownByIdHandler : IRequestHandler<RemoveTownByIdCommand>
{
    private readonly ITownManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="RemoveTownByIdHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="ITownManager"/></param>
    public RemoveTownByIdHandler(ITownManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="RemoveTownByIdCommand"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task"/></returns>
    public async Task Handle(RemoveTownByIdCommand request, CancellationToken cancellationToken)
    {
        await Manager.RemoveTownById(request.Id);
    }
}