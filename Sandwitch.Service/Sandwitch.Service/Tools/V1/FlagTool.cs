using MediatR;
using ModelContextProtocol.Server;
using Sandwitch.Application.Commands.Flag;
using Sandwitch.Application.Queries.Flag;
using Sandwitch.Application.ViewModels.Additions;
using Sandwitch.Application.ViewModels.Filters;
using Sandwitch.Application.ViewModels.Updates;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Service.Tools.V1;

/// <summary>
///     Represents a <see cref="FlagTool" /> class.
/// </summary>
/// <param name="mediator">Injected <see cref="IMediator" /></param>
[McpServerToolType]
public class FlagTool(IMediator mediator) 
{
    /// <summary>
    ///     Updates Flag
    /// </summary>
    /// <param name="viewModel">Injected <see cref="AddHistoric" /></param>
    /// <returns>A <see cref="Task{T}"/> whose result is a <see cref="ViewFlag"/>.</returns>
    [McpServerTool]
    public async Task<ViewFlag> UpdateFlag(UpdateFlag viewModel)
    {
        return await mediator.Send(new UpdateFlagCommand { ViewModel = viewModel });
    }

    /// <summary>
    ///     Finds All Flag
    /// </summary>
    /// <returns>A <see cref="Task{T}"/> whose result is a <see cref="IList{T}"/> of <see cref="ViewCatalog"/>.</returns>
    [McpServerTool]
    public async Task<IList<ViewCatalog>> FindAllFlag()
    {
        return await mediator.Send(new FindAllFlagQuery());
    }

    /// <summary>
    ///     Finds Paginated Flag
    /// </summary>
    /// <param name="viewModel">Injected <see cref="FilterPage" /></param>
    /// <returns>A <see cref="Task{T}"/> whose result is a <see cref="ViewPage{T}"/> of <see cref="ViewFlag"/>.</returns>
    [McpServerTool]
    public async Task<ViewPage<ViewFlag>> FindPaginatedFlag(FilterPage viewModel)
    {
        return await mediator.Send(new FindPaginatedFlagQuery { ViewModel = viewModel });
    }

    /// <summary>
    ///     Finds All Historic By Flag Id
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>A <see cref="Task{T}"/> whose result is a <see cref="IList{T}"/> of <see cref="ViewHistoric"/>.</returns>
    [McpServerTool]
    public async Task<IList<ViewHistoric>> FindAllHistoricByFlagId(int id)
    {
        return await mediator.Send(new FindAllHistoricByFlagIdQuery { Id = id });
    }

    /// <summary>
    ///     Adds Flag
    /// </summary>
    /// <param name="viewModel">Injected <see cref="AddFlag" /></param>
    /// <returns>A <see cref="Task{T}"/> whose result is a <see cref="ViewFlag"/>.</returns>
    [McpServerTool]
    public async Task<ViewFlag> AddFlag(AddFlag viewModel)
    {
        return await mediator.Send(new AddFlagCommand { ViewModel = viewModel });
    }

    /// <summary>
    ///     Removes Flag ById
    /// </summary>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task" /></returns>
    [McpServerTool]
    public async Task RemoveFlagById(int id)
    {
        await mediator.Send(new RemoveFlagByIdCommand { Id = id });
    }
}