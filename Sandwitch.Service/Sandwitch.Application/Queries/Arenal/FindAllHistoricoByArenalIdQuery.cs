using MediatR;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Application.Queries.Arenal;

public class FindAllHistoricoByArenalIdQuery : IRequest<IList<ViewHistorico>>
{
    public int Id { get; set; }
}