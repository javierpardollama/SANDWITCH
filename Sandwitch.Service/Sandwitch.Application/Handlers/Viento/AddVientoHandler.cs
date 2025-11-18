using MediatR;
using Microsoft.AspNetCore.Identity;
using Sandwitch.Application.Commands.Viento;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;
using Entities = Sandwitch.Domain.Entities;

namespace Sandwitch.Application.Handlers.Viento;

/// <summary>
/// Represents a <see cref="AddVientoHandler"/>. Implements <see cref="IRequestHandler{AddVientoCommand, ViewViento}"/>
/// </summary>
public class AddVientoHandler : IRequestHandler<AddVientoCommand, ViewViento>
{
    private readonly IVientoManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="AddVientoHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IVientoManager"/></param>
    public AddVientoHandler(IVientoManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="AddVientoCommand"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{ViewViento}"/></returns>
    public async Task<ViewViento> Handle(AddVientoCommand request, CancellationToken cancellationToken)
    {
        var @viento = new Entities.Viento
        {
            Name = request.ViewModel.Name,
            ImageUri = request.ViewModel.ImageUri,
        };

        var @entity = await Manager.AddViento(viento);

        var @dto = await Manager.ReloadVientoById(@entity.Id);

        return @dto.ToViewModel();       
    }
}