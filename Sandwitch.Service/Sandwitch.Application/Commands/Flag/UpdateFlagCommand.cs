using MediatR;
using Sandwitch.Application.ViewModels.Updates;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Application.Commands.Flag;

/// <summary>
/// Represents a <see cref="UpdateFlagCommand" /> class. Inherits <see cref="IRequest{ViewFlag}" />
/// </summary>
public class UpdateFlagCommand : IRequest<ViewFlag>
{
    /// <summary>
    /// Gets or Sets <see cref="ViewModel"/>
    /// </summary>
    public UpdateFlag ViewModel { get; set; }
}