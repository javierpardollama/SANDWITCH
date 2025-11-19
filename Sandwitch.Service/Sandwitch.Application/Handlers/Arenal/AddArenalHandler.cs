using MediatR;
using Sandwitch.Application.Commands.Arenal;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;
using Entities = Sandwitch.Domain.Entities;

namespace Sandwitch.Application.Handlers.Arenal;

/// <summary>
/// Represents a <see cref="AddArenalHandler"/>. Implements <see cref="IRequestHandler{AddArenalCommand, ViewArenal}"/>
/// </summary>
public class AddArenalHandler : IRequestHandler<AddArenalCommand, ViewArenal>
{
    private readonly IArenalManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="AddArenalHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IArenalManager"/></param>
   public AddArenalHandler(IArenalManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="AddArenalCommand"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{ViewArenal}"/></returns>
    public async Task<ViewArenal> Handle(AddArenalCommand request, CancellationToken cancellationToken)
    {
        Entities.Arenal @entity = new()
        {
            Name = request.ViewModel.Name.Trim(),
            ArenalPoblaciones = [],
            Historicos = []
        };

        var @arenal = await Manager.AddArenal(@entity);

        var poblaciones = await Manager.FindAllPoblacionByIds(request.ViewModel.PoblacionesId);

        await Manager.AddArenalPoblacion(poblaciones, @arenal);

        await Manager.AddHistorico(@arenal);

        var @dto = await Manager.ReloadArenalById(@arenal.Id);

        return @dto.ToViewModel();       
    }
}