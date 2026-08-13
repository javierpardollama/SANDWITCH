using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using ModelContextProtocol.Server;
using Sandwitch.Application.Commands.Beach;
using Sandwitch.Application.Queries.Beach;
using Sandwitch.Application.ViewModels.Additions;
using Sandwitch.Application.ViewModels.Filters;
using Sandwitch.Application.ViewModels.Updates;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Service.Tools.V1;

/// <summary>
///     Represents a <see cref="BeachTool" /> class.
/// </summary>
/// <param name="mediator">Injected <see cref="IMediator" /></param>
[McpServerToolType]
[Authorize("McpApi")]
[EnableCors("McpApi")]
public class BeachTool(IMediator mediator)
{
    /// <summary>
    ///     Updates Beach
    /// </summary>
    /// <param name="viewModel">Injected <see cref="UpdateBeach" /></param>
    /// <returns>A <see cref="Task{T}"/> whose result is a <see cref="ViewBeach"/>.</returns>
    [McpServerTool(
        Name = "updatebeach",
        Title = "Updates Beach"
    )]
    public async Task<ViewBeach> UpdateBeach(UpdateBeach viewModel)
    {
        return await mediator.Send(new UpdateBeachCommand { ViewModel = viewModel });
    }

    /// <summary>
    ///     Finds All Beach
    /// </summary>
    /// <returns>A <see cref="Task{T}"/> whose result is a <see cref="IList{T}"/> of <see cref="ViewCatalog"/>.</returns>
    [McpServerTool(
        Name = "findallbeach",
        Title = "Finds All Beaches"
    )]
    public async Task<IList<ViewCatalog>> FindAllBeach()
    {
        return await mediator.Send(new FindAllBeachQuery());
    }

    /// <summary>
    ///     Finds Paginated Beach
    /// </summary>
    /// <param name="viewModel">Injected <see cref="FilterPage" /></param>
    /// <returns>A <see cref="Task{T}"/> whose result is a <see cref="ViewPage{T}"/> of <see cref="ViewBeach"/>.</returns>
    [McpServerTool(
        Name = "findpaginatedbeach",
        Title = "Finds All Beaches Paginated"
    )]
    public async Task<ViewPage<ViewBeach>> FindPaginatedBeach(FilterPage viewModel)
    {
        return await mediator.Send(new FindPaginatedBeachQuery { ViewModel = viewModel });
    }

    /// <summary>
    ///     Finds All Historic By Beach Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>A <see cref="Task{T}"/> whose result is a <see cref="IList{T}"/> of <see cref="ViewHistoric"/>.</returns>
    [McpServerTool(
        Name = "findallhistoricbybeachid",
        Title = "Finds All Historics By Beach Id"
    )]
    public async Task<IList<ViewHistoric>> FindAllHistoricByBeachId(int id)
    {
        return await mediator.Send(new FindAllHistoricByBeachIdQuery { Id = id });
    }

    /// <summary>
    ///     Adds Beach
    /// </summary>
    /// <param name="viewModel">Injected <see cref="AddBeach" /></param>
    /// <returns>A <see cref="Task{T}"/> whose result is a <see cref="ViewBeach"/>.</returns>
    [McpServerTool(
        Name = "addbeach",
        Title = " Adds Beach"
    )]
    public async Task<ViewBeach> AddBeach(AddBeach viewModel)
    {
        return await mediator.Send(new AddBeachCommand { ViewModel = viewModel });
    }

    /// <summary>
    ///     Removes Beach By Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    [McpServerTool(
        Name = "removebeachbyid",
        Title = "Removes Beach By Id"
    )]
    public async Task RemoveBeachById(int id)
    {
        await mediator.Send(new RemoveBeachByIdCommand { Id = id });
    }
}