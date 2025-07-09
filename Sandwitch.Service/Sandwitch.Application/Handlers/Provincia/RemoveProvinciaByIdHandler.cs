using AutoMapper;
using MediatR;
using Sandwitch.Application.Commands.Provincia;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Provincia;

public class RemoveProvinciaByIdHandler : IRequestHandler<RemoveProvinciaByIdCommand>
{
    private readonly IProvinciaManager Manager;
    private readonly IMapper Mapper;

    public RemoveProvinciaByIdHandler(IProvinciaManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
    }

    public async Task Handle(RemoveProvinciaByIdCommand request, CancellationToken cancellationToken)
    {
        await Manager.RemoveProvinciaById(request.Id);
    }
}