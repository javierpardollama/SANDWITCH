using MediatR;
using Sandwitch.Application.Commands.Beach;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;
using Entities = Sandwitch.Domain.Entities;

namespace Sandwitch.Application.Handlers.Beach;

/// <summary>
/// Represents a <see cref="UpdateBeachHandler"/>. Implements <see cref="IRequestHandler{UpdateBeachCommand, ViewBeach}"/>
/// </summary>
public class UpdateBeachHandler : IRequestHandler<UpdateBeachCommand, ViewBeach>
{
    private readonly IBeachManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="UpdateBeachHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IBeachManager"/></param>
    public UpdateBeachHandler(IBeachManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="UpdateBeachCommand"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{ViewBeach}"/></returns>
    public async Task<ViewBeach> Handle(UpdateBeachCommand request, CancellationToken cancellationToken)
    {
        Entities.Beach @entity = new()
        {
            Id = request.ViewModel.Id,
            Name = request.ViewModel.Name.Trim(),
            BeachTowns = [],
            Historics = []
        };

        var @Beach = await Manager.UpdateBeach(@entity);

        var Townes = await Manager.FindAllTownByIds(request.ViewModel.TownesId);

        await Manager.AddBeachTown(Townes, @Beach);

        await Manager.AddHistoric(@Beach);

        var @dto = await Manager.ReloadBeachById(@Beach.Id);

        return @dto.ToViewModel();
    }
}