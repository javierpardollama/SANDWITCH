using MediatR;
using Sandwitch.Application.ViewModels.Additions;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Application.Commands.Beach;

/// <summary>
/// Represents a <see cref="AddBeachCommand" /> class. Inherits <see cref="IRequest{ViewBeach}" />
/// </summary>
public class AddBeachCommand : IRequest<ViewBeach>
{
    /// <summary>
    /// Gets or Sets <see cref="ViewModel"/>
    /// </summary>
    public AddBeach ViewModel { get; set; }
}