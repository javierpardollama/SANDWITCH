using AutoMapper;
using MediatR;
using Sandwitch.Application.Queries.Bandera;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Bandera;

/// <summary>
/// Represents a <see cref="FindAllHistoricoByBanderaIdHandler"/>. Implements <see cref="IRequestHandler{FindAllHistoricoByBanderaIdQuery, IList{ViewHistorico}}"/>
/// </summary>
public class FindAllHistoricoByBanderaIdHandler : IRequestHandler<FindAllHistoricoByBanderaIdQuery, IList<ViewHistorico>>
{
    private readonly IBanderaManager Manager;
    private readonly IMapper Mapper;

    /// <summary>
    ///  Initializes a new Instance of <see cref="FindAllHistoricoByBanderaIdHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IBanderaManager"/></param>
    /// <param name="mapper">Injected <see cref="IMapper"/></param>
    public FindAllHistoricoByBanderaIdHandler(IBanderaManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="FindAllHistoricoByBanderaIdQuery"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{IList{ViewHistorico}}"/></returns>
    public async Task<IList<ViewHistorico>> Handle(FindAllHistoricoByBanderaIdQuery request,
        CancellationToken cancellationToken)
    {
        var result = await Manager.FindAllHistoricoByBanderaId(request.Id);

        return Mapper.Map<IList<ViewHistorico>>(result);
    }
}