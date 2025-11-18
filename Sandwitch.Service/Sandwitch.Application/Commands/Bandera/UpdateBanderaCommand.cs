using MediatR;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.ViewModels.Updates;

namespace Sandwitch.Application.Commands.Bandera;

/// <summary>
/// Represents a <see cref="UpdateBanderaCommand" /> class. Inherits <see cref="IRequest{ViewBandera}" />
/// </summary>
public class UpdateBanderaCommand : IRequest<ViewBandera>
{
    /// <summary>
    /// Gets or Sets <see cref="ViewModel"/>
    /// </summary>
    public UpdateBandera ViewModel { get; set; }
}