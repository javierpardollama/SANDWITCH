using MediatR;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Queries.Bandera;

public class FindAllHistoricoByBanderaIdQuery : IRequest<IList<ViewHistorico>>
{
    public int Id { get; set; }
}