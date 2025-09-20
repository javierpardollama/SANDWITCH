using AutoMapper;
using MediatR;
using Sandwitch.Application.Commands.Poblacion;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Poblacion;

/// <summary>
/// Represents a <see cref="UpdatePoblacionHandler"/>. Implements <see cref="IRequestHandler{UpdatePoblacionCommand, ViewPoblacion}"/>
/// </summary>
public class UpdatePoblacionHandler : IRequestHandler<UpdatePoblacionCommand, ViewPoblacion>
{
    private readonly IPoblacionManager Manager;
    private readonly IMapper Mapper;

    /// <summary>
    ///  Initializes a new Instance of <see cref="UpdatePoblacionHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IPoblacionManager"/></param>
    /// <param name="mapper">Injected <see cref="IMapper"/></param>
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