using AutoMapper;
using MediatR;
using Sandwitch.Application.Commands.Arenal;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Arenal;

/// <summary>
/// Represents a <see cref="AddArenalHandler"/>. Implements <see cref="IRequestHandler{AddArenalCommand, ViewArenal}"/>
/// </summary>
public class AddArenalHandler : IRequestHandler<AddArenalCommand, ViewArenal>
{
    private readonly IArenalManager Manager;
    private readonly IMapper Mapper;

    /// <summary>
    ///  Initializes a new Instance of <see cref="AddArenalHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IArenalManager"/></param>
    /// <param name="mapper">Injected <see cref="IMapper"/></param>
   public AddArenalHandler(IArenalManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="AddArenalCommand"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{ViewArenal}"/></returns>
    public async Task<ViewArenal> Handle(AddArenalCommand request, CancellationToken cancellationToken)
    {
        var result = await Manager.AddArenal(request.ViewModel);

        return Mapper.Map<ViewArenal>(result);
    }
}