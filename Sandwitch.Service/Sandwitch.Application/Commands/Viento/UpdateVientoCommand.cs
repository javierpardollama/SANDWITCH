using MediatR;
using Sandwitch.Domain.ViewModels.Updates;
using Sandwitch.Domain.ViewModels.Views;

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