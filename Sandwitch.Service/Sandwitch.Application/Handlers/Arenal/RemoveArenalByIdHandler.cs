using MediatR;
using Sandwitch.Application.Commands.Arenal;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Arenal;

public class RemoveArenalByIdHandler : IRequestHandler<RemoveArenalByIdCommand>
{
    private readonly IArenalManager Manager;

    public RemoveArenalByIdHandler(IArenalManager manager)
    {
        Manager = manager;
    }

    public async Task Handle(RemoveArenalByIdCommand request, CancellationToken cancellationToken)
    {
        await Manager.RemoveArenalById(request.Id);
    }
}