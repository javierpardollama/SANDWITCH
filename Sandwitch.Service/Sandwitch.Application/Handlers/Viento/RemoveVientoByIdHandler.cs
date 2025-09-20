using AutoMapper;
using MediatR;
using Sandwitch.Application.Commands.Viento;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Viento;

/// <summary>
/// Represents a <see cref="RemoveVientoByIdHandler"/>. Implements <see cref="IRequestHandler{RemoveVientoByIdCommand}"/>
/// </summary>
public class RemoveVientoByIdHandler : IRequestHandler<RemoveVientoByIdCommand>
{
    private readonly IVientoManager Manager;
    private readonly IMapper Mapper;

    /// <summary>
    ///  Initializes a new Instance of <see cref="RemoveVientoByIdHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IVientoManager"/></param>
    /// <param name="mapper">Injected <see cref="IMapper"/></param>
    public RemoveVientoByIdHandler(IVientoManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
    }

    /// <summary>
    /// Handles
    /// </summary>
    /// <param name="request">Injected <see cref="RemoveVientoByIdCommand"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task"/></returns>
    public async Task Handle(RemoveVientoByIdCommand request, CancellationToken cancellationToken)
    {
        await Manager.RemoveVientoById(request.Id);
    }
}