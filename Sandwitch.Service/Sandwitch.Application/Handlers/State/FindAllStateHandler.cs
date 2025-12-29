using MediatR;
using Sandwitch.Application.Profiles;
using Sandwitch.Application.Queries.State;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Managers;

namespace Sandwitch.Application.Handlers.State;

/// <summary>
/// Represents a <see cref="FindAllStateHandler"/>. Implements <see cref="IRequestHandler{FindAllStateQuery, IList{ViewState}}"/>
/// </summary>
public class FindAllStateHandler : IRequestHandler<FindAllStateQuery, IList<ViewCatalog>>
{
    private readonly IStateManager Manager;

    /// <summary>
    ///  Initializes a new Instance of <see cref="FindAllStateHandler" />
    /// </summary>
    /// <param name="manager">Injected <see cref="IStateManager"/></param>
    public FindAllStateHandler(IStateManager manager)
    {
        Manager = manager;
    }

    /// <summary>
    /// Handles Request
    /// </summary>
    /// <param name="request">Injected <see cref="FindAllStateQuery"/></param>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken"/></param>
    /// <returns>Instance of <see cref="Task{List{ViewCatalog}}"/></returns>
    public async Task<IList<ViewCatalog>> Handle(FindAllStateQuery request, CancellationToken cancellationToken)
    {
        var dtos = await Manager.FindAllState();

        return [.. dtos.Select(x => x.ToViewModel())];
    }
}