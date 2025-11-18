using MediatR;
using Sandwitch.Application.Commands.Bandera;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;
using Entities = Sandwitch.Domain.Entities;

namespace Sandwitch.Application.Handlers.Bandera;

/// <summary>
/// Represents a <see cref="UpdateBanderaHandler"/>. Implements <see cref="IRequestHandler{UpdateBanderaCommand, ViewBandera}"/>
/// </summary>
public class UpdateBanderaHandler : IRequestHandler<UpdateBanderaCommand, ViewBandera>
{
    private readonly IBanderaManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="UpdateBanderaHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IBanderaManager"/></param>
    public UpdateBanderaHandler(IBanderaManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="UpdateBanderaCommand"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{ViewBandera}"/></returns>
    public async Task<ViewBandera> Handle(UpdateBanderaCommand request, CancellationToken cancellationToken)
    {
        var @bandera = new Entities.Bandera
        {
            Id = request.ViewModel.Id,
            Name = request.ViewModel.Name,
            ImageUri = request.ViewModel.ImageUri,
        };

        var @entity = await Manager.UpdateBandera(@bandera);

        var @dto = await Manager.ReloadBanderaById(@entity.Id);

        return @dto.ToViewModel();
    }
}