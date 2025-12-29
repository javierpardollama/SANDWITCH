using MediatR;
using Sandwitch.Application.Commands.Flag;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;
using Entities = Sandwitch.Domain.Entities;

namespace Sandwitch.Application.Handlers.Flag;

/// <summary>
/// Represents a <see cref="AddFlagHandler"/>. Implements <see cref="IRequestHandler{AddFlagCommand, ViewFlag}"/>
/// </summary>
public class AddFlagHandler : IRequestHandler<AddFlagCommand, ViewFlag>
{
    private readonly IFlagManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="AddFlagHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IFlagManager"/></param>
    public AddFlagHandler(IFlagManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="AddFlagCommand"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{ViewFlag}"/></returns>
    public async Task<ViewFlag> Handle(AddFlagCommand request, CancellationToken cancellationToken)
    {
        var @Flag = new Entities.Flag
        {
            Name = request.ViewModel.Name,
            ImageUri = request.ViewModel.ImageUri,
        };

        var @entity = await Manager.AddFlag(@Flag);

        var @dto = await Manager.ReloadFlagById(@entity.Id);

        return @dto.ToViewModel();
    }
}