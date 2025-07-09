using AutoMapper;
using MediatR;
using Sandwitch.Application.Commands.Viento;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Viento;

public class UpdateVientoHandler : IRequestHandler<UpdateVientoCommand, ViewViento>
{
    private readonly IVientoManager Manager;
    private readonly IMapper Mapper;

    public UpdateVientoHandler(IVientoManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
    }

    public async Task<ViewViento> Handle(UpdateVientoCommand request, CancellationToken cancellationToken)
    {
        var result = await Manager.UpdateViento(request.ViewModel);

        return Mapper.Map<ViewViento>(result);
    }
}