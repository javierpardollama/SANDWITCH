using MediatR;
using Sandwitch.Application.Commands.Wind;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;
using Entities = Sandwitch.Domain.Entities;

namespace Sandwitch.Application.Handlers.Wind;

/// <summary>
/// Represents a <see cref="UpdateWindHandler"/>. Implements <see cref="IRequestHandler{UpdateWindCommand, ViewWind}"/>
/// </summary>
public class UpdateWindHandler : IRequestHandler<UpdateWindCommand, ViewWind>
{
    private readonly IWindManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="UpdateWindHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IWindManager"/></param>
    public UpdateWindHandler(IWindManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="UpdateWindCommand"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{ViewWind}"/></returns>
    public async Task<ViewWind> Handle(UpdateWindCommand request, CancellationToken cancellationToken)
    {
        var @Wind = new Entities.Wind
        {
            Name = request.ViewModel.Name,
            ImageUri = request.ViewModel.ImageUri,
            Id = request.ViewModel.Id,
        };

        var @entity = await Manager.UpdateWind(Wind);

        var @dto = await Manager.ReloadWindById(@entity.Id);

        return @dto.ToViewModel();
    }
}