using MediatR;
using Microsoft.AspNetCore.Authorization;
using ModelContextProtocol.Server;
using Sandwitch.Application.Commands.Wind;
using Sandwitch.Application.Queries.Wind;
using Sandwitch.Application.ViewModels.Additions;
using Sandwitch.Application.ViewModels.Filters;
using Sandwitch.Application.ViewModels.Updates;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Service.Tools.V2;

/// <summary>
///     Represents a <see cref="WindTool" /> class.
/// </summary>
/// <param name="mediator">Injected <see cref="IMediator" /></param>
[McpServerToolType]
[Authorize("McpApi")]
public class WindTool(IMediator mediator)
{
    /// <summary>
    ///     Updates Wind
    /// </summary>
    /// <param name="viewModel">Injected <see cref="AddHistoric" /></param>
    /// <returns>A <see cref="Task{T}"/> whose result is a <see cref="ViewWind"/>.</returns>
    [McpServerTool(
        Name = "updatewind",
        Title = "Updates Wind"
    )]
    public async Task<ViewWind> UpdateWind(UpdateWind viewModel)
    {
        return await mediator.Send(new UpdateWindCommand { ViewModel = viewModel });
    }

    /// <summary>
    ///     Finds All Wind
    /// </summary>
    /// <returns>A <see cref="Task{T}"/> whose result is a <see cref="IList{T}"/> of <see cref="ViewCatalog"/>.</returns>
    [McpServerTool(
        Name = "findallwind",
        Title = "Finds All Winds"
    )]
    public async Task<IList<ViewCatalog>> FindAllWind()
    {
        return await mediator.Send(new FindAllWindQuery());
    }

    /// <summary>
    ///     Finds Paginated Wind
    /// </summary>
    /// <param name="viewModel">Injected <see cref="FilterPage" /></param>
    /// <returns>A <see cref="Task{T}"/> whose result is a <see cref="ViewPage{T}"/> of <see cref="ViewWind"/>.</returns>
    [McpServerTool(
        Name = "findpaginatedwind",
        Title = "Finds All Winds Paginated"
    )]
    public async Task<ViewPage<ViewWind>> FindPaginatedWind(FilterPage viewModel)
    {
        return await mediator.Send(new FindPaginatedWindQuery { ViewModel = viewModel });
    }

    /// <summary>
    ///     Finds All Historic By Wind Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>A <see cref="Task{T}"/> whose result is a <see cref="IList{T}"/> of <see cref="ViewHistoric"/>.</returns>
    [McpServerTool(
        Name = "findallhistoricbywindid",
        Title = "Finds All Historics By Wind Id"
    )]
    public async Task<IList<ViewHistoric>> FindAllHistoricByWindId(int id)
    {
        return await mediator.Send(new FindAllHistoricByWindIdQuery { Id = id });
    }

    /// <summary>
    ///     Adds Wind
    /// </summary>
    /// <param name="viewModel">Injected <see cref="AddWind" /></param>
    /// <returns>A <see cref="Task{T}"/> whose result is a <see cref="ViewWind"/>.</returns>
    [McpServerTool(
        Name = "addwind",
        Title = "Adds Wind"
    )]
    public async Task<ViewWind> AddWind(AddWind viewModel)
    {
        return await mediator.Send(new AddWindCommand { ViewModel = viewModel });
    }

    /// <summary>
    ///     Removes Wind By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    [McpServerTool(
        Name = "removewindbyid",
        Title = "Removes Wind By Id"
    )]
    public async Task RemoveWindById(int id)
    {
        await mediator.Send(new RemoveWindByIdCommand { Id = id });
    }
}