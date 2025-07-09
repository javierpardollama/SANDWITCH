using AutoMapper;
using MediatR;
using Sandwitch.Application.Commands.Viento;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Viento;

public class RemoveVientoByIdHandler : IRequestHandler<RemoveVientoByIdCommand>
{
    private readonly IVientoManager Manager;
    private readonly IMapper Mapper;

    public RemoveVientoByIdHandler(IVientoManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
    }

    public async Task Handle(RemoveVientoByIdCommand request, CancellationToken cancellationToken)
    {
        await Manager.RemoveVientoById(request.Id);
    }
}