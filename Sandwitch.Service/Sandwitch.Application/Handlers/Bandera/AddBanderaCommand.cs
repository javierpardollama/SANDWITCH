using AutoMapper;
using MediatR;
using Sandwitch.Application.Commands.Bandera;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Handlers.Bandera;

public class AddBanderaHandler : IRequestHandler<AddBanderaCommand, ViewBandera>
{
    private readonly IBanderaManager Manager;
    private readonly IMapper Mapper;

    public AddBanderaHandler(IBanderaManager manager, IMapper mapper)
    {
        Manager = manager;
        Mapper = mapper;
    }

    public async Task<ViewBandera> Handle(AddBanderaCommand request, CancellationToken cancellationToken)
    {
        var result = await Manager.AddBandera(request.ViewModel);

        return Mapper.Map<ViewBandera>(result);
    }
}