using AutoMapper;
using MediatR;
using Sandwitch.Application.Queries.Arenal;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Arenal;

public class FindAllHistoricoByArenalIdHandler : IRequestHandler<FindAllHistoricoByArenalIdQuery, IList<ViewHistorico>>
{
    private readonly IArenalManager Manager;
    private readonly IMapper Mapper;

    public FindAllHistoricoByArenalIdHandler(IArenalManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
    }

    public async Task<IList<ViewHistorico>> Handle(FindAllHistoricoByArenalIdQuery request,
        CancellationToken cancellationToken)
    {
        var result = await Manager.FindAllHistoricoByArenalId(request.Id);

        return Mapper.Map<IList<ViewHistorico>>(result);
    }
}