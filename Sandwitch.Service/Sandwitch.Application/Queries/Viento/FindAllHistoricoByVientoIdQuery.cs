using MediatR;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Application.Queries.Viento;

public class FindAllHistoricoByVientoIdQuery : IRequest<IList<ViewHistorico>>
{
    public int Id { get; set; }
}