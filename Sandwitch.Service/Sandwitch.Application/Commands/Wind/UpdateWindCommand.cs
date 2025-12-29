using MediatR;
using Sandwitch.Application.ViewModels.Updates;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Application.Commands.Wind;

/// <summary>
/// Represents a <see cref="UpdateWindCommand" /> class. Inherits <see cref="IRequest{ViewWind}" />
/// </summary>
public class UpdateWindCommand : IRequest<ViewWind>
{
    /// <summary>
    /// Gets or Sets <see cref="ViewModel"/>
    /// </summary>
    public UpdateWind ViewModel { get; set; }
}