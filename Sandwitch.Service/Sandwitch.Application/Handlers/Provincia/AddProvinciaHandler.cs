using AutoMapper;
using MediatR;
using Sandwitch.Application.Commands.Provincia;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Provincia;

public class AddProvinciaHandler : IRequestHandler<AddProvinciaCommand, ViewProvincia>
{
    private readonly IProvinciaManager Manager;
    private readonly IMapper Mapper;

    public AddProvinciaHandler(IProvinciaManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
    }

    public async Task<ViewProvincia> Handle(AddProvinciaCommand request, CancellationToken cancellationToken)
    {
        var result = await Manager.AddProvincia(request.ViewModel);

        return Mapper.Map<ViewProvincia>(result);
    }
}