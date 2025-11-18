using MediatR;
using Sandwitch.Application.Commands.Poblacion;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;
using Entities = Sandwitch.Domain.Entities;

namespace Sandwitch.Application.Handlers.Poblacion;

/// <summary>
/// Represents a <see cref="AddPoblacionHandler"/>. Implements <see cref="IRequestHandler{AddPoblacionCommand, ViewPoblacion}"/>
/// </summary>
public class AddPoblacionHandler : IRequestHandler<AddPoblacionCommand, ViewPoblacion>
{
    private readonly IPoblacionManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="AddPoblacionHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IPoblacionManager"/></param>
    public AddPoblacionHandler(IPoblacionManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="AddPoblacionCommand"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{ViewPoblacion}"/></returns>
    public async Task<ViewPoblacion> Handle(AddPoblacionCommand request, CancellationToken cancellationToken)
    {
        var @poblacion = new Entities.Poblacion
        {
            Name = request.ViewModel.Name,
            ImageUri = request.ViewModel.ImageUri,    
            ProvinciaId = request.ViewModel.ProvinciaId,
        };

        var @entity = await Manager.AddPoblacion(@poblacion);

        var @dto = await Manager.ReloadPoblacionById(@entity.Id);

        return @dto.ToViewModel();
    }
}