using MediatR;
using Sandwitch.Application.Commands.Bandera;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Bandera;

public class RemoveBanderaByIdHandler : IRequestHandler<RemoveBanderaByIdCommand>
{
    private readonly IBanderaManager Manager;

    public RemoveBanderaByIdHandler(IBanderaManager manager)
    {
        Manager = manager;
    }

    public async Task Handle(RemoveBanderaByIdCommand request, CancellationToken cancellationToken)
    {
        await Manager.RemoveBanderaById(request.Id);
    }
}