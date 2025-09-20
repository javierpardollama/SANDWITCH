using AutoMapper;
using MediatR;
using Sandwitch.Application.Commands.Provincia;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Provincia;

/// <summary>
/// Represents a <see cref="AddProvinciaHandler"/>. Implements <see cref="IRequestHandler{AddProvinciaCommand, ViewProvincia}"/>
/// </summary>
public class AddProvinciaHandler : IRequestHandler<AddProvinciaCommand, ViewProvincia>
{
    private readonly IProvinciaManager Manager;
    private readonly IMapper Mapper;

    /// <summary>
    ///  Initializes a new Instance of <see cref="AddProvinciaHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IProvinciaManager"/></param>
    /// <param name="mapper">Injected <see cref="IMapper"/></param>
    public AddProvinciaHandler(IProvinciaManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
    }

    /// <summary>
    /// Handles
    /// </summary>
    /// <param name="request">Injected <see cref="AddProvinciaCommand"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{ViewProvincia}"/></returns>
    public async Task<ViewProvincia> Handle(AddProvinciaCommand request, CancellationToken cancellationToken)
    {
        var result = await Manager.AddProvincia(request.ViewModel);

        return Mapper.Map<ViewProvincia>(result);
    }
}