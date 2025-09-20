using MediatR;
using Sandwitch.Domain.ViewModels.Updates;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Commands.Provincia;

/// <summary>
/// Represents a <see cref="UpdateProvinciaCommand" /> class. Inherits <see cref="IRequest{ViewProvincia}" />
/// </summary>
public class UpdateProvinciaCommand : IRequest<ViewProvincia>
{
    /// <summary>
    /// Gets or Sets <see cref="ViewModel"/>
    /// </summary>
    public UpdateProvincia ViewModel { get; set; }
}