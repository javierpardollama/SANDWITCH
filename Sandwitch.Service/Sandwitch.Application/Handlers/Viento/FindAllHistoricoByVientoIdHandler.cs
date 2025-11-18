using AutoMapper;
using MediatR;
using Sandwitch.Application.Queries.Bandera;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.Viento;

/// <summary>
/// Represents a <see cref="FindAllHistoricoByVientoIdHandler"/>. Implements <see cref="IRequestHandler{FindAllHistoricoByBanderaIdQuery, IList{ViewHistorico}}"/>
/// </summary>
public class FindAllHistoricoByVientoIdHandler : IRequestHandler<FindAllHistoricoByBanderaIdQuery, IList<ViewHistorico>>
{
    private readonly IVientoManager Manager;
    private readonly IMapper Mapper;

    /// <summary>
    ///  Initializes a new Instance of <see cref="FindAllHistoricoByVientoIdHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IVientoManager"/></param>
    /// <param name="mapper">Injected <see cref="IMapper"/></param>
    public FindAllHistoricoByVientoIdHandler(IVientoManager manager, IMapper mapper)
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
        var result = await Manager.FindAllHistoricoByVientoId(request.Id);

        return Mapper.Map<IList<ViewHistorico>>(result);
    }
}