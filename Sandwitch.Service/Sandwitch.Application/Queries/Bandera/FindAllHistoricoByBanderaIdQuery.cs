using MediatR;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Application.Queries.Bandera;

public class FindAllHistoricoByBanderaIdQuery : IRequest<IList<ViewHistorico>>
{
    public int Id { get; set; }
}