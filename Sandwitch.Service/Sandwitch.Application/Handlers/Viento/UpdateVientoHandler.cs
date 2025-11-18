using MediatR;
using Sandwitch.Application.Commands.Viento;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;
using Entities = Sandwitch.Domain.Entities;

namespace Sandwitch.Application.Handlers.Viento;

/// <summary>
/// Represents a <see cref="UpdateVientoHandler"/>. Implements <see cref="IRequestHandler{UpdateVientoCommand, ViewViento}"/>
/// </summary>
public class UpdateVientoHandler : IRequestHandler<UpdateVientoCommand, ViewViento>
{
    private readonly IVientoManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="UpdateVientoHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IVientoManager"/></param>
    public UpdateVientoHandler(IVientoManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="UpdateVientoCommand"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{ViewViento}"/></returns>
    public async Task<ViewViento> Handle(UpdateVientoCommand request, CancellationToken cancellationToken)
    {
        var @viento = new Entities.Viento
        {
            Name = request.ViewModel.Name,
            ImageUri = request.ViewModel.ImageUri,
            Id = request.ViewModel.Id,
        };

        var @entity = await Manager.UpdateViento(viento);

        var @dto = await Manager.ReloadVientoById(@entity.Id);

        return @dto.ToViewModel();
    }
}