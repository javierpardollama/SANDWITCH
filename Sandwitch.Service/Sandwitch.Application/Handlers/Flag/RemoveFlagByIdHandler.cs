using MediatR;
using Sandwitch.Application.Commands.Flag;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Flag;

/// <summary>
/// Represents a <see cref="RemoveFlagByIdHandler"/>. Implements <see cref="IRequestHandler{RemoveFlagByIdCommand}"/>
/// </summary>
public class RemoveFlagByIdHandler : IRequestHandler<RemoveFlagByIdCommand>
{
    private readonly IFlagManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="RemoveFlagByIdHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IFlagManager"/></param>
    public RemoveFlagByIdHandler(IFlagManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="RemoveFlagByIdCommand"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task"/></returns>
    public async Task Handle(RemoveFlagByIdCommand request, CancellationToken cancellationToken)
    {
        await Manager.RemoveFlagById(request.Id);
    }
}