using MediatR;
using Sandwitch.Application.Commands.Beach;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;
using Entities = Sandwitch.Domain.Entities;

namespace Sandwitch.Application.Handlers.Beach;

/// <summary>
/// Represents a <see cref="AddBeachHandler"/>. Implements <see cref="IRequestHandler{AddBeachCommand, ViewBeach}"/>
/// </summary>
public class AddBeachHandler : IRequestHandler<AddBeachCommand, ViewBeach>
{
    private readonly IBeachManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="AddBeachHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IBeachManager"/></param>
   public AddBeachHandler(IBeachManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="AddBeachCommand"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{ViewBeach}"/></returns>
    public async Task<ViewBeach> Handle(AddBeachCommand request, CancellationToken cancellationToken)
    {
        Entities.Beach @entity = new()
        {
            Name = request.ViewModel.Name.Trim(),
            BeachTowns = [],
            Historics = []
        };

        var @Beach = await Manager.AddBeach(@entity);

        var Townes = await Manager.FindAllTownByIds(request.ViewModel.TownsId);

        await Manager.AddBeachTown(Townes, @Beach);

        await Manager.AddHistoric(@Beach);

        var @dto = await Manager.ReloadBeachById(@Beach.Id);

        return @dto.ToViewModel();       
    }
}