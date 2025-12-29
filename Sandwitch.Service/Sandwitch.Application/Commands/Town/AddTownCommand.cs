using MediatR;
using Sandwitch.Application.ViewModels.Additions;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Application.Commands.Town;

/// <summary>
/// Represents a <see cref="AddTownCommand" /> class. Inherits <see cref="IRequest{ViewTown}" />
/// </summary>
public class AddTownCommand : IRequest<ViewTown>
{
    /// <summary>
    /// Gets or Sets <see cref="ViewModel"/>
    /// </summary>
    public AddTown ViewModel { get; set; }
}