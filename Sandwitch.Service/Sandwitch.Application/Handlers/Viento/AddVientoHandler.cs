using AutoMapper;
using MediatR;
using Sandwitch.Application.Commands.Viento;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Viento;

public class AddVientoHandler : IRequestHandler<AddVientoCommand, ViewViento>
{
    private readonly IVientoManager Manager;
    private readonly IMapper Mapper;

    public AddVientoHandler(IVientoManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
    }

    public async Task<ViewViento> Handle(AddVientoCommand request, CancellationToken cancellationToken)
    {
        var result = await Manager.AddViento(request.ViewModel);

        return Mapper.Map<ViewViento>(result);
    }
}