using MediatR;
using Sandwitch.Application.Commands.Beach;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Beach;

/// <summary>
/// Represents a <see cref="RemoveBeachByIdHandler"/>. Implements <see cref="IRequestHandler{RemoveBeachByIdCommand}"/>
/// </summary>
public class RemoveBeachByIdHandler : IRequestHandler<RemoveBeachByIdCommand>
{
    private readonly IBeachManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="RemoveBeachByIdHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IBeachManager"/></param>
    public RemoveBeachByIdHandler(IBeachManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="RemoveBeachByIdCommand"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task"/></returns>
    public async Task Handle(RemoveBeachByIdCommand request, CancellationToken cancellationToken)
    {
        await Manager.RemoveBeachById(request.Id);
    }
}