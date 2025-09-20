using AutoMapper;
using MediatR;
using Sandwitch.Application.Queries.Viento;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Viento;

/// <summary>
/// Represents a <see cref="FindAllVientoHandler"/>. Implements <see cref="IRequestHandler{FindAllVientoQuery, IList{ViewViento}}"/>
/// </summary>
public class FindAllVientoHandler : IRequestHandler<FindAllVientoQuery, IList<ViewViento>>
{
    private readonly IVientoManager Manager;
    private readonly IMapper Mapper;

    /// <summary>
    ///  Initializes a new Instance of <see cref="FindAllVientoHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IVientoManager"/></param>
    /// <param name="mapper">Injected <see cref="IMapper"/></param>
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