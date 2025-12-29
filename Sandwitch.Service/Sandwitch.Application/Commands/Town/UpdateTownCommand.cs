using MediatR;
using Sandwitch.Application.ViewModels.Updates;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Application.Commands.Town;

/// <summary>
/// Represents a <see cref="UpdateTownCommand" /> class. Inherits <see cref="IRequest{ViewTown}" />
/// </summary>
public class UpdateTownCommand : IRequest<ViewTown>
{
    /// <summary>
    /// Gets or Sets <see cref="ViewModel"/>
    /// </summary>
    public UpdateTown ViewModel { get; set; }
}