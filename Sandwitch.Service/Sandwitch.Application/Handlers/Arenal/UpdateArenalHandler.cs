using AutoMapper;
using MediatR;
using Sandwitch.Application.Commands.Arenal;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Arenal;

/// <summary>
/// Represents a <see cref="UpdateArenalHandler"/>. Implements <see cref="IRequestHandler{UpdateArenalCommand, ViewArenal}"/>
/// </summary>
public class UpdateArenalHandler : IRequestHandler<UpdateArenalCommand, ViewArenal>
{
    private readonly IArenalManager Manager;
    private readonly IMapper Mapper;

    /// <summary>
    ///  Initializes a new Instance of <see cref="UpdateArenalHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IArenalManager"/></param>
    /// <param name="mapper">Injected <see cref="IMapper"/></param>
    public UpdateArenalHandler(IArenalManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
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