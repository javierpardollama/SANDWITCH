using MediatR;
using Sandwitch.Application.ViewModels.Updates;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Application.Commands.State;

/// <summary>
/// Represents a <see cref="UpdateStateCommand" /> class. Inherits <see cref="IRequest{ViewState}" />
/// </summary>
public class UpdateStateCommand : IRequest<ViewState>
{
    /// <summary>
    /// Gets or Sets <see cref="ViewModel"/>
    /// </summary>
    public UpdateState ViewModel { get; set; }
}