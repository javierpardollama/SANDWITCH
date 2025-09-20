using AutoMapper;
using MediatR;
using Sandwitch.Application.Commands.Poblacion;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Poblacion;

/// <summary>
/// Represents a <see cref="AddPoblacionHandler"/>. Implements <see cref="IRequestHandler{AddPoblacionCommand, ViewPoblacion}"/>
/// </summary>
public class AddPoblacionHandler : IRequestHandler<AddPoblacionCommand, ViewPoblacion>
{
    private readonly IPoblacionManager Manager;
    private readonly IMapper Mapper;

    /// <summary>
    ///  Initializes a new Instance of <see cref="AddPoblacionHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IPoblacionManager"/></param>
    /// <param name="mapper">Injected <see cref="IMapper"/></param>
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