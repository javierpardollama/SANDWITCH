using AutoMapper;
using MediatR;
using Sandwitch.Application.Commands.Poblacion;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Poblacion;

public class UpdatePoblacionHandler : IRequestHandler<UpdatePoblacionCommand, ViewPoblacion>
{
    private readonly IPoblacionManager Manager;
    private readonly IMapper Mapper;

    public UpdatePoblacionHandler(IPoblacionManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
    }

    public async Task<ViewPoblacion> Handle(UpdatePoblacionCommand request, CancellationToken cancellationToken)
    {
        var result = await Manager.UpdatePoblacion(request.ViewModel);

        return Mapper.Map<ViewPoblacion>(result);
    }
}