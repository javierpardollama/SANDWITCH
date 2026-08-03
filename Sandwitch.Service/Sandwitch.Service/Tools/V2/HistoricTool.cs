using MediatR;
using ModelContextProtocol.Server;
using Sandwitch.Application.Commands.Historic;
using Sandwitch.Application.ViewModels.Additions;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Service.Tools.V2;

/// <summary>
///     Represents a <see cref="HistoricTool" /> class.
/// </summary>
/// <param name="mediator">Injected <see cref="IMediator" /></param>
[McpServerToolType]
public class HistoricTool(IMediator mediator)
{
    /// <summary>
    ///     Adds Historic
    /// </summary>
    /// <param name="viewModel">Injected <see cref="AddHistoric" /></param>
    /// <returns>Instance of <see cref="Task{ViewHistoric}" /></returns>
    [McpServerTool(
        Name = "addhistoric",
        Title = ""
    )]
    public async Task<ViewHistoric> AddHistoric(AddHistoric viewModel)
    {
        return await mediator.Send(new AddHistoricCommand { ViewModel = viewModel });
    }
}