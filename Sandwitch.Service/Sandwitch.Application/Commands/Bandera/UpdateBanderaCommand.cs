using MediatR;
using Sandwitch.Domain.ViewModels.Updates;
using Sandwitch.Domain.ViewModels.Views;

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