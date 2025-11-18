using MediatR;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.ViewModels.Updates;

namespace Sandwitch.Application.Commands.Arenal;

/// <summary>
/// Represents a <see cref="UpdateArenalCommand" /> class. Inherits <see cref="IRequest{ViewArenal}" />
/// </summary>
public class UpdateArenalCommand : IRequest<ViewArenal>
{
    /// <summary>
    /// Gets or Sets <see cref="ViewModel"/>
    /// </summary>
    public UpdateArenal ViewModel { get; set; }
}