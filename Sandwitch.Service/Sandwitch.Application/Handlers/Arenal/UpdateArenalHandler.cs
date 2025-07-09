using AutoMapper;
using MediatR;
using Sandwitch.Application.Commands.Arenal;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Arenal;

public class UpdateArenalHandler : IRequestHandler<UpdateArenalCommand, ViewArenal>
{
    private readonly IArenalManager Manager;
    private readonly IMapper Mapper;

    public UpdateArenalHandler(IArenalManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
    }

    public async Task<ViewArenal> Handle(UpdateArenalCommand request, CancellationToken cancellationToken)
    {
        var result = await Manager.UpdateArenal(request.ViewModel);

        return Mapper.Map<ViewArenal>(result);
    }
}