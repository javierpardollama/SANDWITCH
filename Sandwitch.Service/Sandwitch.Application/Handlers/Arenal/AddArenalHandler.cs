using AutoMapper;
using MediatR;
using Sandwitch.Application.Commands.Arenal;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Arenal;

public class AddArenalHandler : IRequestHandler<AddArenalCommand, ViewArenal>
{
    private readonly IArenalManager Manager;
    private readonly IMapper Mapper;

    public AddArenalHandler(IArenalManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
    }

    public async Task<ViewArenal> Handle(AddArenalCommand request, CancellationToken cancellationToken)
    {
        var result = await Manager.AddArenal(request.ViewModel);

        return Mapper.Map<ViewArenal>(result);
    }
}