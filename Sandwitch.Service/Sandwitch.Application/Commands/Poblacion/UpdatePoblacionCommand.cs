using MediatR;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.ViewModels.Updates;

namespace Sandwitch.Application.Commands.Poblacion;

/// <summary>
/// Represents a <see cref="UpdatePoblacionCommand" /> class. Inherits <see cref="IRequest{ViewPoblacion}" />
/// </summary>
public class UpdatePoblacionCommand : IRequest<ViewPoblacion>
{
    /// <summary>
    /// Gets or Sets <see cref="ViewModel"/>
    /// </summary>
    public UpdatePoblacion ViewModel { get; set; }
}