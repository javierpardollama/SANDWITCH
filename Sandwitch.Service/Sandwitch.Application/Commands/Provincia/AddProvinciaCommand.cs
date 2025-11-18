using MediatR;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.ViewModels.Additions;

namespace Sandwitch.Application.Commands.Provincia;

/// <summary>
/// Represents a <see cref="AddProvinciaCommand" /> class. Inherits <see cref="IRequest{ViewProvincia}" />
/// </summary>
public class AddProvinciaCommand : IRequest<ViewProvincia>
{
    /// <summary>
    /// Gets or Sets <see cref="ViewModel"/>
    /// </summary>
    public AddProvincia ViewModel { get; set; }
}