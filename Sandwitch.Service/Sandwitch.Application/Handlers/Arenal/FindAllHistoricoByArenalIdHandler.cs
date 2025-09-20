using AutoMapper;
using MediatR;
using Sandwitch.Application.Queries.Arenal;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Arenal;

/// <summary>
/// Represents a <see cref="AddArenalHandler"/>. Implements <see cref="IRequestHandler{FindAllHistoricoByArenalIdQuery, IList{ViewHistorico}}"/>
/// </summary>
public class FindAllHistoricoByArenalIdHandler : IRequestHandler<FindAllHistoricoByArenalIdQuery, IList<ViewHistorico>>
{
    private readonly IArenalManager Manager;
    private readonly IMapper Mapper;

    /// <summary>
    ///  Initializes a new Instance of <see cref="FindAllHistoricoByArenalIdHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IArenalManager"/></param>
    /// <param name="mapper">Injected <see cref="IMapper"/></param>
    public FindAllHistoricoByArenalIdHandler(IArenalManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
    }

    /// <summary>
    /// Handles
    /// </summary>
    /// <param name="request">Injected <see cref="FindAllHistoricoByArenalIdQuery"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{IList{ViewHistorico}}"/></returns>
    public async Task<IList<ViewHistorico>> Handle(FindAllHistoricoByArenalIdQuery request,
        CancellationToken cancellationToken)
    {
        var result = await Manager.FindAllHistoricoByArenalId(request.Id);

        return Mapper.Map<IList<ViewHistorico>>(result);
    }
}