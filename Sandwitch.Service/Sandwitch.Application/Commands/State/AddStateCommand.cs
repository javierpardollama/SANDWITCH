using MediatR;
using Sandwitch.Application.ViewModels.Additions;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Application.Commands.State;

/// <summary>
/// Represents a <see cref="AddStateCommand" /> class. Inherits <see cref="IRequest{ViewState}" />
/// </summary>
public class AddStateCommand : IRequest<ViewState>
{
    /// <summary>
    /// Gets or Sets <see cref="ViewModel"/>
    /// </summary>
    public AddState ViewModel { get; set; }
}