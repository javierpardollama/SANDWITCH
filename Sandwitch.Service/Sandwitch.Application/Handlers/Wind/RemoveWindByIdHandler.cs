using MediatR;
using Sandwitch.Application.Commands.Wind;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Wind;

/// <summary>
/// Represents a <see cref="RemoveWindByIdHandler"/>. Implements <see cref="IRequestHandler{RemoveWindByIdCommand}"/>
/// </summary>
public class RemoveWindByIdHandler : IRequestHandler<RemoveWindByIdCommand>
{
    private readonly IWindManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="RemoveWindByIdHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IWindManager"/></param>
    public RemoveWindByIdHandler(IWindManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="RemoveWindByIdCommand"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task"/></returns>
    public async Task Handle(RemoveWindByIdCommand request, CancellationToken cancellationToken)
    {
        await Manager.RemoveWindById(request.Id);
    }
}