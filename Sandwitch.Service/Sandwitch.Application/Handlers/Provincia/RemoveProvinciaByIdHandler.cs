using MediatR;
using Sandwitch.Application.Commands.Provincia;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Provincia;

/// <summary>
/// Represents a <see cref="RemoveProvinciaByIdHandler"/>. Implements <see cref="IRequestHandler{RemoveProvinciaByIdCommand}"/>
/// </summary>
public class RemoveProvinciaByIdHandler : IRequestHandler<RemoveProvinciaByIdCommand>
{
    private readonly IProvinciaManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="RemoveProvinciaByIdHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IProvinciaManager"/></param>
    public RemoveProvinciaByIdHandler(IProvinciaManager manager)
    {
        Manager = manager;
    }

    public async Task Handle(RemoveProvinciaByIdCommand request, CancellationToken cancellationToken)
    {
        await Manager.RemoveProvinciaById(request.Id);
    }
}