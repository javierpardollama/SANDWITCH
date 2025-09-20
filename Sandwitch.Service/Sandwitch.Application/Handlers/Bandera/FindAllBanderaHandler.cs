using AutoMapper;
using MediatR;
using Sandwitch.Application.Queries.Bandera;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Bandera;

/// <summary>
/// Represents a <see cref="FindAllBanderaHandler"/>. Implements <see cref="IRequestHandler{FindAllBanderaQuery,  IList{ViewBandera}}"/>
/// </summary>
public class FindAllBanderaHandler : IRequestHandler<FindAllBanderaQuery, IList<ViewBandera>>
{
    private readonly IBanderaManager Manager;
    private readonly IMapper Mapper;

    /// <summary>
    ///  Initializes a new Instance of <see cref="FindAllBanderaHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IBanderaManager"/></param>
    /// <param name="mapper">Injected <see cref="IMapper"/></param>
    public FindAllBanderaHandler(IBanderaManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="FindAllBanderaQuery"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{IList{ViewBandera}}"/></returns>
    public async Task<IList<ViewBandera>> Handle(FindAllBanderaQuery request, CancellationToken cancellationToken)
    {
        var result = await Manager.FindAllBandera();

        return Mapper.Map<IList<ViewBandera>>(result);
    }
}