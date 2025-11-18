using MediatR;
using Sandwitch.Application.Commands.Provincia;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;
using Entities = Sandwitch.Domain.Entities;

namespace Sandwitch.Application.Handlers.Provincia;

/// <summary>
/// Represents a <see cref="AddProvinciaHandler"/>. Implements <see cref="IRequestHandler{AddProvinciaCommand, ViewProvincia}"/>
/// </summary>
public class AddProvinciaHandler : IRequestHandler<AddProvinciaCommand, ViewProvincia>
{
    private readonly IProvinciaManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="AddProvinciaHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IProvinciaManager"/></param>
    public AddProvinciaHandler(IProvinciaManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="AddProvinciaCommand"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{ViewProvincia}"/></returns>
    public async Task<ViewProvincia> Handle(AddProvinciaCommand request, CancellationToken cancellationToken)
    {
        var @provincia = new Entities.Provincia
        {
            Name = request.ViewModel.Name,
            ImageUri = request.ViewModel.ImageUri,
        };

        var @entity = await Manager.AddProvincia(provincia);

        var @dto = await Manager.ReloadProvinciaById(@entity.Id);

        return @dto.ToViewModel();
    }
}