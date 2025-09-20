using MediatR;
using Sandwitch.Application.Commands.Arenal;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Arenal;

/// <summary>
/// Represents a <see cref="RemoveArenalByIdHandler"/>. Implements <see cref="IRequestHandler{RemoveArenalByIdCommand}"/>
/// </summary>
public class RemoveArenalByIdHandler : IRequestHandler<RemoveArenalByIdCommand>
{
    private readonly IArenalManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="RemoveArenalByIdHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IArenalManager"/></param>
    public RemoveArenalByIdHandler(IArenalManager manager)
    {
        Manager = manager;
    }

    public async Task Handle(RemoveArenalByIdCommand request, CancellationToken cancellationToken)
    {
        await Manager.RemoveArenalById(request.Id);
    }
}