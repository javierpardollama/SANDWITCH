using MediatR;
using Sandwitch.Application.Commands.Bandera;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;
using Entities = Sandwitch.Domain.Entities;

namespace Sandwitch.Application.Handlers.Bandera;

/// <summary>
/// Represents a <see cref="AddBanderaHandler"/>. Implements <see cref="IRequestHandler{AddBanderaCommand, ViewBandera}"/>
/// </summary>
public class AddBanderaHandler : IRequestHandler<AddBanderaCommand, ViewBandera>
{
    private readonly IBanderaManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="AddBanderaHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IBanderaManager"/></param>
    public AddBanderaHandler(IBanderaManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="AddBanderaCommand"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{ViewBandera}"/></returns>
    public async Task<ViewBandera> Handle(AddBanderaCommand request, CancellationToken cancellationToken)
    {
        var @bandera = new Entities.Bandera
        {
            Name = request.ViewModel.Name,
            ImageUri = request.ViewModel.ImageUri,
        };

        var @entity = await Manager.AddBandera(@bandera);

        var @dto = await Manager.ReloadBanderaById(@entity.Id);

        return @dto.ToViewModel();
    }
}