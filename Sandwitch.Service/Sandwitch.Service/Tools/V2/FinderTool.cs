using MediatR;
using ModelContextProtocol.Server;
using Sandwitch.Application.Queries.Finder;
using Sandwitch.Application.ViewModels.Filters;
using Sandwitch.Application.ViewModels.Finders;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Service.Tools.V2;

/// <summary>
///     Represents a <see cref="FinderTool" /> class.
/// </summary>
/// <param name="mediator">Injected <see cref="IMediator" /></param>
[McpServerToolType]
public class FinderTool(IMediator mediator)
{
    /// <summary>
    ///     Finds All Finder
    /// </summary>
    /// <returns>A <see cref="Task{T}"/> whose result is a <see cref="IList{T}"/> of <see cref="ViewFinder"/>.</returns>
    [McpServerTool(
        Name = "findallfinder",
        Title = "Returns all Beaches"
    )]
    public async Task<IList<ViewFinder>> FindAllFinder()
    {
        return await mediator.Send(new FindAllFinderQuery());
    }

    /// <summary>
    ///     Finds All Beach By Finder Id
    /// </summary>
    /// <param name="viewModel">Injected <see cref="FilterPage" /></param>
    /// <returns>A <see cref="Task{T}"/> whose result is a <see cref="IList{T}"/> of <see cref="ViewBeach"/>.</returns>
    [McpServerTool(
        Name = "findallbeachbyfinderid",
        Title = "Returns All Beaches For A Given Finder Id"
    )]
    public async Task<IList<ViewBeach>> FindAllBeachByFinderId(FinderBeach viewModel)
    {
        return await mediator.Send(new FindAllBeachByFinderIdQuery { ViewModel = viewModel });
    }
}