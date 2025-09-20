using AutoMapper;
using MediatR;
using Sandwitch.Application.Commands.Bandera;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Bandera;

/// <summary>
/// Represents a <see cref="AddBanderaHandler"/>. Implements <see cref="IRequestHandler{AddBanderaCommand, ViewBandera}"/>
/// </summary>
public class AddBanderaHandler : IRequestHandler<AddBanderaCommand, ViewBandera>
{
    private readonly IBanderaManager Manager;
    private readonly IMapper Mapper;

    /// <summary>
    ///  Initializes a new Instance of <see cref="AddBanderaHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IBanderaManager"/></param>
    /// <param name="mapper">Injected <see cref="IMapper"/></param>
    public AddBanderaHandler(IBanderaManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="AddBanderaCommand"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{ViewBandera}"/></returns>
    public async Task<ViewBandera> Handle(AddBanderaCommand request, CancellationToken cancellationToken)
    {
        var result = await Manager.AddBandera(request.ViewModel);

        return Mapper.Map<ViewBandera>(result);
    }
}