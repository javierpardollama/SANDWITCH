using MediatR;
using Microsoft.AspNetCore.Authorization;
using ModelContextProtocol.Server;
using Sandwitch.Application.Commands.State;
using Sandwitch.Application.Queries.State;
using Sandwitch.Application.ViewModels.Additions;
using Sandwitch.Application.ViewModels.Filters;
using Sandwitch.Application.ViewModels.Updates;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Service.Tools.V1;

/// <summary>
///     Represents a <see cref="StateTool" /> class.
/// </summary>
/// <param name="mediator">Injected <see cref="IMediator" /></param>
[McpServerToolType]
[Authorize(Policy = "McpApi")]
public class StateTool(IMediator mediator)
{
    /// <summary>
    ///     Updates State
    /// </summary>
    /// <param name="viewModel">Injected <see cref="UpdateState" /></param>
    /// <returns>A <see cref="Task{T}"/> whose result is a <see cref="ViewState"/>.</returns>
    [McpServerTool(
        Name = "updatestate",
        Title = "Updates State"
    )]
    public async Task<ViewState> UpdateState(UpdateState viewModel)
    {
        return await mediator.Send(new UpdateStateCommand { ViewModel = viewModel });
    }

    /// <summary>
    ///     Finds All State
    /// </summary>
    /// <returns>A <see cref="Task{T}"/> whose result is a <see cref="IList{T}"/> of <see cref="ViewCatalog"/>.</returns>
    [McpServerTool(
        Name = "findallstate",
        Title = "Finds All States"
    )]
    public async Task<IList<ViewCatalog>> FindAllState()
    {
        return await mediator.Send(new FindAllStateQuery());
    }

    /// <summary>
    ///     Finds Paginated State
    /// </summary>
    /// <param name="viewModel">Injected <see cref="FilterPage" /></param>
    /// <returns>A <see cref="Task{T}"/> whose result is a <see cref="ViewPage{T}"/> of <see cref="ViewState"/>.</returns>
    [McpServerTool(
        Name = "findpaginatedstate",
        Title = "Finds All States Paginated"
    )]
    public async Task<ViewPage<ViewState>> FindPaginatedState(FilterPage viewModel)
    {
        return await mediator.Send(new FindPaginatedStateQuery { ViewModel = viewModel });
    }

    /// <summary>
    ///     Adds State
    /// </summary>
    /// <param name="viewModel">Injected <see cref="AddState" /></param>
    /// <returns>A <see cref="Task{T}"/> whose result is a <see cref="ViewState"/>.</returns>
    [McpServerTool(
        Name = "addstate",
        Title = "Adds State"
    )]
    public async Task<ViewState> AddState(AddState viewModel)
    {
        return await mediator.Send(new AddStateCommand { ViewModel = viewModel });
    }

    /// <summary>
    ///     Removes State By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>A <see cref="Task{T}"/> whose result is a <see cref="IList{T}"/> of <see cref="ViewCatalog"/>.</returns>
    [McpServerTool(
        Name = "removestatebyid",
        Title = "Removes State By Id"
    )]
    public async Task RemoveStateById(int id)
    {
        await mediator.Send(new RemoveStateByIdCommand { Id = id });
    }
}