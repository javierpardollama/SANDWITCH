using MediatR;
using Sandwitch.Domain.ViewModels.Additions;
using Sandwitch.Domain.ViewModels.Views;

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