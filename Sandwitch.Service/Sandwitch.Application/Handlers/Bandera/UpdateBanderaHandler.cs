using AutoMapper;
using MediatR;
using Sandwitch.Application.Commands.Bandera;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Bandera;

/// <summary>
/// Represents a <see cref="UpdateBanderaHandler"/>. Implements <see cref="IRequestHandler{UpdateBanderaCommand, ViewBandera}"/>
/// </summary>
public class UpdateBanderaHandler : IRequestHandler<UpdateBanderaCommand, ViewBandera>
{
    private readonly IBanderaManager Manager;
    private readonly IMapper Mapper;

    /// <summary>
    ///  Initializes a new Instance of <see cref="UpdateBanderaHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IBanderaManager"/></param>
    /// <param name="mapper">Injected <see cref="IMapper"/></param>
    public UpdateBanderaHandler(IBanderaManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
    }

    public async Task<ViewBandera> Handle(UpdateBanderaCommand request, CancellationToken cancellationToken)
    {
        var result = await Manager.UpdateBandera(request.ViewModel);

        return Mapper.Map<ViewBandera>(result);
    }
}