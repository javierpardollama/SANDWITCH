using MediatR;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.ViewModels.Updates;

namespace Sandwitch.Application.Commands.Viento;

/// <summary>
/// Represents a <see cref="UpdateVientoCommand" /> class. Inherits <see cref="IRequest{ViewViento}" />
/// </summary>
public class UpdateVientoCommand : IRequest<ViewViento>
{
    /// <summary>
    /// Gets or Sets <see cref="ViewModel"/>
    /// </summary>
    public UpdateViento ViewModel { get; set; }
}