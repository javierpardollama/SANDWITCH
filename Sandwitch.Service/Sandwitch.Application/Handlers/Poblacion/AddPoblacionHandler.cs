using AutoMapper;
using MediatR;
using Sandwitch.Application.Commands.Poblacion;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Poblacion;

public class AddPoblacionHandler : IRequestHandler<AddPoblacionCommand, ViewPoblacion>
{
    private readonly IPoblacionManager Manager;
    private readonly IMapper Mapper;

    public AddPoblacionHandler(IPoblacionManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
    }

    public async Task<ViewPoblacion> Handle(AddPoblacionCommand request, CancellationToken cancellationToken)
    {
        var result = await Manager.AddPoblacion(request.ViewModel);

        return Mapper.Map<ViewPoblacion>(result);
    }
}