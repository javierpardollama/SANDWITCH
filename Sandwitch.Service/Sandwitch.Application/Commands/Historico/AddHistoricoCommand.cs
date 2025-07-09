using MediatR;
using Sandwitch.Domain.ViewModels.Additions;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Commands.Historico;

public class AddHistoricoCommand : IRequest<ViewHistorico>
{
    public AddHistorico ViewModel { get; set; }
}