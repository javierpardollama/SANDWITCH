using MediatR;
using Sandwitch.Application.Commands.Provincia;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;
using Entities = Sandwitch.Domain.Entities;

namespace Sandwitch.Application.Handlers.Provincia;

/// <summary>
/// Represents a <see cref="UpdateProvinciaHandler"/>. Implements <see cref="IRequestHandler{UpdateProvinciaCommand, ViewProvincia}"/>
/// </summary>
public class UpdateProvinciaHandler : IRequestHandler<UpdateProvinciaCommand, ViewProvincia>
{
    private readonly IProvinciaManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="UpdateProvinciaHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IProvinciaManager"/></param>
    /// <param name="mapper">Injected <see cref="IMapper"/></param>
    public UpdateProvinciaHandler(IProvinciaManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="UpdateProvinciaCommand"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{ViewProvincia}"/></returns>
    public async Task<ViewProvincia> Handle(UpdateProvinciaCommand request, CancellationToken cancellationToken)
    {
        var @provincia = new Entities.Provincia
        {
            Id = request.ViewModel.Id,
            Name = request.ViewModel.Name,
            ImageUri = request.ViewModel.ImageUri,
        };

        var @entity = await Manager.UpdateProvincia(@provincia);

        var @dto = await Manager.ReloadProvinciaById(@entity.Id);

        return @dto.ToViewModel();
    }
}