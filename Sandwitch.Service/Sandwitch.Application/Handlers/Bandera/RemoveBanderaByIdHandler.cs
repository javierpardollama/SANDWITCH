using MediatR;
using Sandwitch.Application.Commands.Bandera;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Bandera;

/// <summary>
/// Represents a <see cref="RemoveBanderaByIdHandler"/>. Implements <see cref="IRequestHandler{RemoveBanderaByIdCommand}"/>
/// </summary>
public class RemoveBanderaByIdHandler : IRequestHandler<RemoveBanderaByIdCommand>
{
    private readonly IBanderaManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="RemoveBanderaByIdHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IBanderaManager"/></param>
    public RemoveBanderaByIdHandler(IBanderaManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="RemoveBanderaByIdCommand"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task"/></returns>
    public async Task Handle(RemoveBanderaByIdCommand request, CancellationToken cancellationToken)
    {
        await Manager.RemoveBanderaById(request.Id);
    }
}