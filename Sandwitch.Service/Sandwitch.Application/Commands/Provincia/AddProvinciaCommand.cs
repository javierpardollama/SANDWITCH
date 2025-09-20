using MediatR;
using Sandwitch.Domain.ViewModels.Additions;
using Sandwitch.Domain.ViewModels.Views;

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