using MediatR;
using Sandwitch.Application.Commands.Poblacion;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;
using Entities = Sandwitch.Domain.Entities;

namespace Sandwitch.Application.Handlers.Poblacion;

/// <summary>
/// Represents a <see cref="UpdatePoblacionHandler"/>. Implements <see cref="IRequestHandler{UpdatePoblacionCommand, ViewPoblacion}"/>
/// </summary>
public class UpdatePoblacionHandler : IRequestHandler<UpdatePoblacionCommand, ViewPoblacion>
{
    private readonly IPoblacionManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="UpdatePoblacionHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IPoblacionManager"/></param>
    /// <param name="mapper">Injected <see cref="IMapper"/></param>
    public UpdatePoblacionHandler(IPoblacionManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="UpdatePoblacionCommand"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{ViewPoblacion}"/></returns>
    public async Task<ViewPoblacion> Handle(UpdatePoblacionCommand request, CancellationToken cancellationToken)
    {
        var @poblacion = new Entities.Poblacion
        {
            Id = request.ViewModel.Id,
            Name = request.ViewModel.Name,
            ImageUri = request.ViewModel.ImageUri,
        };

        var @entity = await Manager.UpdatePoblacion(@poblacion);

        var @dto = await Manager.ReloadPoblacionById(@entity.Id);

        return @dto.ToViewModel();
    }
}