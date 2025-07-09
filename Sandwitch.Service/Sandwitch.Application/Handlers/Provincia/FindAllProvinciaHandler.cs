using AutoMapper;
using MediatR;
using Sandwitch.Application.Queries.Provincia;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Provincia;

public class FindAllProvinciaHandler : IRequestHandler<FindAllProvinciaQuery, IList<ViewProvincia>>
{
    private readonly IProvinciaManager Manager;
    private readonly IMapper Mapper;

    public FindAllProvinciaHandler(IProvinciaManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
    }

    public async Task<IList<ViewProvincia>> Handle(FindAllProvinciaQuery request, CancellationToken cancellationToken)
    {
        var result = await Manager.FindAllProvincia();

        return Mapper.Map<IList<ViewProvincia>>(result);
    }
}