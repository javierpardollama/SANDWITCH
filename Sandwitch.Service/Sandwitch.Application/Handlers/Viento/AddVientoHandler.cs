using AutoMapper;
using MediatR;
using Sandwitch.Application.Commands.Viento;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Viento;

/// <summary>
/// Represents a <see cref="AddVientoHandler"/>. Implements <see cref="IRequestHandler{AddVientoCommand, ViewViento}"/>
/// </summary>
public class AddVientoHandler : IRequestHandler<AddVientoCommand, ViewViento>
{
    private readonly IVientoManager Manager;
    private readonly IMapper Mapper;

    /// <summary>
    ///  Initializes a new Instance of <see cref="AddVientoHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IVientoManager"/></param>
    /// <param name="mapper">Injected <see cref="IMapper"/></param>
    public AddVientoHandler(IVientoManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
    }

    public async Task<ViewViento> Handle(AddVientoCommand request, CancellationToken cancellationToken)
    {
        var result = await Manager.AddViento(request.ViewModel);

        return Mapper.Map<ViewViento>(result);
    }
}