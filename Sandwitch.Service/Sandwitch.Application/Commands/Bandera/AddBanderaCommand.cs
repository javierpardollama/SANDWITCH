using MediatR;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.ViewModels.Additions;

namespace Sandwitch.Application.Commands.Bandera;

/// <summary>
/// Represents a <see cref="AddBanderaCommand" /> class. Inherits <see cref="IRequest{ViewBandera}" />
/// </summary>
public class AddBanderaCommand : IRequest<ViewBandera>
{
    /// <summary>
    /// Gets or Sets <see cref="ViewModel"/>
    /// </summary>
    public AddBandera ViewModel { get; set; }
}