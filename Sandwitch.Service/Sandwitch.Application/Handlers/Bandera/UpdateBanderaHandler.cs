using AutoMapper;
using MediatR;
using Sandwitch.Application.Commands.Bandera;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Bandera;

public class UpdateBanderaHandler : IRequestHandler<UpdateBanderaCommand, ViewBandera>
{
    private readonly IBanderaManager Manager;
    private readonly IMapper Mapper;

    public UpdateBanderaHandler(IBanderaManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
    }

    public async Task<ViewBandera> Handle(UpdateBanderaCommand request, CancellationToken cancellationToken)
    {
        var result = await Manager.UpdateBandera(request.ViewModel);

        return Mapper.Map<ViewBandera>(result);
    }
}