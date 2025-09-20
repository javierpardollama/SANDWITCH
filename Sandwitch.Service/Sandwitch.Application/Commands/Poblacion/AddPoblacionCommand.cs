using MediatR;
using Sandwitch.Domain.ViewModels.Additions;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Commands.Poblacion;

/// <summary>
/// Represents a <see cref="AddPoblacionCommand" /> class. Inherits <see cref="IRequest{ViewPoblacion}" />
/// </summary>
public class AddPoblacionCommand : IRequest<ViewPoblacion>
{
    /// <summary>
    /// Gets or Sets <see cref="ViewModel"/>
    /// </summary>
    public AddPoblacion ViewModel { get; set; }
}