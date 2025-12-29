using MediatR;
using Sandwitch.Application.ViewModels.Updates;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Application.Commands.Beach;

/// <summary>
/// Represents a <see cref="UpdateBeachCommand" /> class. Inherits <see cref="IRequest{ViewBeach}" />
/// </summary>
public class UpdateBeachCommand : IRequest<ViewBeach>
{
    /// <summary>
    /// Gets or Sets <see cref="ViewModel"/>
    /// </summary>
    public UpdateBeach ViewModel { get; set; }
}