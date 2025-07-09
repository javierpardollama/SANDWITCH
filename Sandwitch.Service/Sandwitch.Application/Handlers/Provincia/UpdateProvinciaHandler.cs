using AutoMapper;
using MediatR;
using Sandwitch.Application.Commands.Provincia;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Provincia;

public class UpdateProvinciaHandler : IRequestHandler<UpdateProvinciaCommand, ViewProvincia>
{
    private readonly IProvinciaManager Manager;
    private readonly IMapper Mapper;

    public UpdateProvinciaHandler(IProvinciaManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
    }

    public async Task<ViewProvincia> Handle(UpdateProvinciaCommand request, CancellationToken cancellationToken)
    {
        var result = await Manager.UpdateProvincia(request.ViewModel);

        return Mapper.Map<ViewProvincia>(result);
    }
}