using MediatR;
using Sandwitch.Application.ViewModels.Additions;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Application.Commands.Arenal;

/// <summary>
/// Represents a <see cref="AddArenalCommand" /> class. Inherits <see cref="IRequest{ViewArenal}" />
/// </summary>
public class AddArenalCommand : IRequest<ViewArenal>
{
    /// <summary>
    /// Gets or Sets <see cref="ViewModel"/>
    /// </summary>
    public AddArenal ViewModel { get; set; }
}