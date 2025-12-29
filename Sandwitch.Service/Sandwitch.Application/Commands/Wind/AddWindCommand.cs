using MediatR;
using Sandwitch.Application.ViewModels.Additions;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Application.Commands.Wind;

/// <summary>
/// Represents a <see cref="AddWindCommand" /> class. Inherits <see cref="IRequest{ViewWind}" />
/// </summary>
public class AddWindCommand : IRequest<ViewWind>
{
    /// <summary>
    /// Gets or Sets <see cref="ViewModel"/>
    /// </summary>
    public AddWind ViewModel { get; set; }
}