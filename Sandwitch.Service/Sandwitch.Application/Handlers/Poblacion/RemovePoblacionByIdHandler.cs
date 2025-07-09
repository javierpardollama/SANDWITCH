using AutoMapper;
using MediatR;
using Sandwitch.Application.Commands.Poblacion;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Poblacion;

public class RemovePoblacionByIdHandler : IRequestHandler<RemovePoblacionByIdCommand>
{
    private readonly IPoblacionManager Manager;
    private readonly IMapper Mapper;

    public RemovePoblacionByIdHandler(IPoblacionManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
    }

    public async Task Handle(RemovePoblacionByIdCommand request, CancellationToken cancellationToken)
    {
        await Manager.RemovePoblacionById(request.Id);
    }
}