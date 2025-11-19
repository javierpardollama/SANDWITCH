using MediatR;
using Sandwitch.Application.Commands.Arenal;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;
using Entities = Sandwitch.Domain.Entities;

namespace Sandwitch.Application.Handlers.Arenal;

/// <summary>
/// Represents a <see cref="UpdateArenalHandler"/>. Implements <see cref="IRequestHandler{UpdateArenalCommand, ViewArenal}"/>
/// </summary>
public class UpdateArenalHandler : IRequestHandler<UpdateArenalCommand, ViewArenal>
{
    private readonly IArenalManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="UpdateArenalHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IArenalManager"/></param>
    public UpdateArenalHandler(IArenalManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="UpdateArenalCommand"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{ViewArenal}"/></returns>
    public async Task<ViewArenal> Handle(UpdateArenalCommand request, CancellationToken cancellationToken)
    {
        Entities.Arenal @entity = new()
        {
            Id = request.ViewModel.Id,
            Name = request.ViewModel.Name.Trim(),
            ArenalPoblaciones = [],
            Historicos = []
        };

        var @arenal = await Manager.UpdateArenal(@entity);

        var poblaciones = await Manager.FindAllPoblacionByIds(request.ViewModel.PoblacionesId);

        await Manager.AddArenalPoblacion(poblaciones, @arenal);

        await Manager.AddHistorico(@arenal);

        var @dto = await Manager.ReloadArenalById(@arenal.Id);

        return @dto.ToViewModel();
    }
}