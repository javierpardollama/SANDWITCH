using MediatR;
using Sandwitch.Application.ViewModels.Additions;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Application.Commands.Flag;

/// <summary>
/// Represents a <see cref="AddFlagCommand" /> class. Inherits <see cref="IRequest{ViewFlag}" />
/// </summary>
public class AddFlagCommand : IRequest<ViewFlag>
{
    /// <summary>
    /// Gets or Sets <see cref="ViewModel"/>
    /// </summary>
    public AddFlag ViewModel { get; set; }
}