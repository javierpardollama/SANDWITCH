using AutoMapper;
using MediatR;
using Sandwitch.Application.Commands.Viento;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Viento;

/// <summary>
/// Represents a <see cref="UpdateVientoHandler"/>. Implements <see cref="IRequestHandler{UpdateVientoCommand, ViewViento}"/>
/// </summary>
public class UpdateVientoHandler : IRequestHandler<UpdateVientoCommand, ViewViento>
{
    private readonly IVientoManager Manager;
    private readonly IMapper Mapper;

    /// <summary>
    ///  Initializes a new Instance of <see cref="UpdateVientoHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IVientoManager"/></param>
    /// <param name="mapper">Injected <see cref="IMapper"/></param>
    public UpdateVientoHandler(IVientoManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
    }

    /// <summary>
    /// Handles
    /// </summary>
    /// <param name="request">Injected <see cref="UpdateVientoCommand"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{ViewViento}"/></returns>
    public async Task<ViewViento> Handle(UpdateVientoCommand request, CancellationToken cancellationToken)
    {
        var result = await Manager.UpdateViento(request.ViewModel);

        return Mapper.Map<ViewViento>(result);
    }
}