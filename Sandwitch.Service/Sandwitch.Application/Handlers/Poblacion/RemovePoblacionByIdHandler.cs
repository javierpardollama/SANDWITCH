using AutoMapper;
using MediatR;
using Sandwitch.Application.Commands.Poblacion;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Poblacion;

/// <summary>
/// Represents a <see cref="RemovePoblacionByIdHandler"/>. Implements <see cref="IRequestHandler{RemovePoblacionByIdCommand}"/>
/// </summary>
public class RemovePoblacionByIdHandler : IRequestHandler<RemovePoblacionByIdCommand>
{
    private readonly IPoblacionManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="RemovePoblacionByIdHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IPoblacionManager"/></param>
    public RemovePoblacionByIdHandler(IPoblacionManager manager)
    {
        Manager = manager;
    }

    public async Task Handle(RemovePoblacionByIdCommand request, CancellationToken cancellationToken)
    {
        await Manager.RemovePoblacionById(request.Id);
    }
}