using AutoMapper;
using MediatR;
using Sandwitch.Application.Commands.Arenal;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Arenal;

/// <summary>
/// Represents a <see cref="UpdateArenalHandler"/>. Implements <see cref="IRequestHandler{UpdateArenalCommand, ViewArenal}"/>
/// </summary>
public class UpdateArenalHandler : IRequestHandler<UpdateArenalCommand, ViewArenal>
{
    private readonly IArenalManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="UpdateArenalHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IArenalManager"/></param>
    public UpdateArenalHandler(IArenalManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="UpdateArenalCommand"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{ViewArenal}"/></returns>
    public async Task<ViewArenal> Handle(UpdateArenalCommand request, CancellationToken cancellationToken)
    {
        var result = await Manager.UpdateArenal(request.ViewModel);

        return Mapper.Map<ViewArenal>(result);
    }
}