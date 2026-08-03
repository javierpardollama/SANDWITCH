using MediatR;
using ModelContextProtocol.Server;
using Sandwitch.Application.Commands.Town;
using Sandwitch.Application.Queries.Town;
using Sandwitch.Application.ViewModels.Additions;
using Sandwitch.Application.ViewModels.Filters;
using Sandwitch.Application.ViewModels.Updates;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Service.Tools.V1;

/// <summary>
///     Represents a <see cref="TownTool" /> class.
/// </summary>
/// <param name="mediator">Injected <see cref="IMediator" /></param>
[McpServerToolType]
public class TownTool(IMediator mediator)
{
    /// <summary>
    ///     Updates Town
    /// </summary>
    /// <param name="viewModel">Injected <see cref="UpdateTown" /></param>
    /// <returns>Instance of <see cref="Task{ViewTown}" /></returns>
    [McpServerTool]
    public async Task<ViewTown> UpdateTown(UpdateTown viewModel)
    {
        return await mediator.Send(new UpdateTownCommand { ViewModel = viewModel });
    }

    /// <summary>
    ///     Finds All Town
    /// </summary>
    /// <returns>A <see cref="Task{T}"/> whose result is a <see cref="IList{T}"/> of <see cref="ViewCatalog"/>.</returns>
    [McpServerTool]
    public async Task<IList<ViewCatalog>> FindAllTown()
    {
        return await mediator.Send(new FindAllTownQuery());
    }

    /// <summary>
    ///     Finds Paginated Town
    /// </summary>
    /// <param name="viewModel">Injected <see cref="FilterPage" /></param>
    /// <returns>A <see cref="Task{T}"/> whose result is a <see cref="ViewPage{T}"/> of <see cref="ViewTown"/>.</returns>
    [McpServerTool]
    public async Task<ViewPage<ViewTown>> FindPaginatedTown(FilterPage viewModel)
    {
        return await mediator.Send(new FindPaginatedTownQuery { ViewModel = viewModel });
    }

    /// <summary>
    ///     Adds Town
    /// </summary>
    /// <param name="viewModel">Injected <see cref="AddTown" /></param>
    /// <returns>Instance of <see cref="Task{ViewTown}" /></returns>
    [McpServerTool]
    public async Task<ViewTown> AddTown(AddTown viewModel)
    {
        return await mediator.Send(new AddTownCommand { ViewModel = viewModel });
    }

    /// <summary>
    ///     Removes Town By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    [McpServerTool]
    public async Task RemoveTownById(int id)
    {
        await mediator.Send(new RemoveTownByIdCommand { Id = id });
    }
}