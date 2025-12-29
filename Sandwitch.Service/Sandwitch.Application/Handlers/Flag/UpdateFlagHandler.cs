using MediatR;
using Sandwitch.Application.Commands.Flag;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;
using Entities = Sandwitch.Domain.Entities;

namespace Sandwitch.Application.Handlers.Flag;

/// <summary>
/// Represents a <see cref="UpdateFlagHandler"/>. Implements <see cref="IRequestHandler{UpdateFlagCommand, ViewFlag}"/>
/// </summary>
public class UpdateFlagHandler : IRequestHandler<UpdateFlagCommand, ViewFlag>
{
    private readonly IFlagManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="UpdateFlagHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IFlagManager"/></param>
    public UpdateFlagHandler(IFlagManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="UpdateFlagCommand"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{ViewFlag}"/></returns>
    public async Task<ViewFlag> Handle(UpdateFlagCommand request, CancellationToken cancellationToken)
    {
        var @Flag = new Entities.Flag
        {
            Id = request.ViewModel.Id,
            Name = request.ViewModel.Name,
            ImageUri = request.ViewModel.ImageUri,
        };

        var @entity = await Manager.UpdateFlag(@Flag);

        var @dto = await Manager.ReloadFlagById(@entity.Id);

        return @dto.ToViewModel();
    }
}