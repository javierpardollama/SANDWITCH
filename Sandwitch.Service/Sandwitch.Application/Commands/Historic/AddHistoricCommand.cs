using MediatR;
using Sandwitch.Application.ViewModels.Additions;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Application.Commands.Historic;

/// <summary>
/// Represents a <see cref="AddHistoricCommand" /> class. Inherits <see cref="IRequest{ViewHistoric}" />
/// </summary>
public class AddHistoricCommand : IRequest<ViewHistoric>
{
    /// <summary>
    /// Gets or Sets <see cref="ViewModel"/>
    /// </summary>
    public AddHistoric ViewModel { get; set; }
}