using MediatR;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.ViewModels.Additions;

namespace Sandwitch.Application.Commands.Viento;

/// <summary>
/// Represents a <see cref="AddVientoCommand" /> class. Inherits <see cref="IRequest{ViewViento}" />
/// </summary>
public class AddVientoCommand : IRequest<ViewViento>
{
    /// <summary>
    /// Gets or Sets <see cref="ViewModel"/>
    /// </summary>
    public AddViento ViewModel { get; set; }
}