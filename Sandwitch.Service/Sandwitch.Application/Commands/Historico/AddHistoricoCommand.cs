using MediatR;
using Sandwitch.Domain.ViewModels.Additions;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Commands.Historico;

/// <summary>
/// Represents a <see cref="AddHistoricoCommand" /> class. Inherits <see cref="IRequest{ViewHistorico}" />
/// </summary>
public class AddHistoricoCommand : IRequest<ViewHistorico>
{
    /// <summary>
    /// Gets or Sets <see cref="ViewModel"/>
    /// </summary>
    public AddHistorico ViewModel { get; set; }
}