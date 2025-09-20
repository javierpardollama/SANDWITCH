using AutoMapper;
using MediatR;
using Sandwitch.Application.Commands.Provincia;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Provincia;

/// <summary>
/// Represents a <see cref="UpdateProvinciaHandler"/>. Implements <see cref="IRequestHandler{UpdateProvinciaCommand, ViewProvincia}"/>
/// </summary>
public class UpdateProvinciaHandler : IRequestHandler<UpdateProvinciaCommand, ViewProvincia>
{
    private readonly IProvinciaManager Manager;
    private readonly IMapper Mapper;

    /// <summary>
    ///  Initializes a new Instance of <see cref="UpdateProvinciaHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IProvinciaManager"/></param>
    /// <param name="mapper">Injected <see cref="IMapper"/></param>
    public UpdateProvinciaHandler(IProvinciaManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="UpdateProvinciaCommand"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{ViewProvincia}"/></returns>
    public async Task<ViewProvincia> Handle(UpdateProvinciaCommand request, CancellationToken cancellationToken)
    {
        var result = await Manager.UpdateProvincia(request.ViewModel);

        return Mapper.Map<ViewProvincia>(result);
    }
}