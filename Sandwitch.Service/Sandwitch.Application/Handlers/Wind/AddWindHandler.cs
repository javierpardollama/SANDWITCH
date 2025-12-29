using MediatR;
using Microsoft.AspNetCore.Identity;
using Sandwitch.Application.Commands.Wind;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;
using Entities = Sandwitch.Domain.Entities;

namespace Sandwitch.Application.Handlers.Wind;

/// <summary>
/// Represents a <see cref="AddWindHandler"/>. Implements <see cref="IRequestHandler{AddWindCommand, ViewWind}"/>
/// </summary>
public class AddWindHandler : IRequestHandler<AddWindCommand, ViewWind>
{
    private readonly IWindManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="AddWindHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IWindManager"/></param>
    public AddWindHandler(IWindManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="AddWindCommand"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{ViewWind}"/></returns>
    public async Task<ViewWind> Handle(AddWindCommand request, CancellationToken cancellationToken)
    {
        var @Wind = new Entities.Wind
        {
            Name = request.ViewModel.Name,
            ImageUri = request.ViewModel.ImageUri,
        };

        var @entity = await Manager.AddWind(Wind);

        var @dto = await Manager.ReloadWindById(@entity.Id);

        return @dto.ToViewModel();       
    }
}