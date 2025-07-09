using MediatR;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Queries.Viento;

public class FindAllHistoricoByVientoIdQuery : IRequest<IList<ViewHistorico>>
{
    public int Id { get; set; }
}