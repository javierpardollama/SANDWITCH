using AutoMapper;
using MediatR;
using Sandwitch.Application.Queries.Viento;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Viento;

public class FindAllVientoHandler : IRequestHandler<FindAllVientoQuery, IList<ViewViento>>
{
    private readonly IVientoManager Manager;
    private readonly IMapper Mapper;

    public FindAllVientoHandler(IVientoManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
    }

    public async Task<IList<ViewViento>> Handle(FindAllVientoQuery request, CancellationToken cancellationToken)
    {
        var result = await Manager.FindAllViento();

        return Mapper.Map<IList<ViewViento>>(result);
    }
}