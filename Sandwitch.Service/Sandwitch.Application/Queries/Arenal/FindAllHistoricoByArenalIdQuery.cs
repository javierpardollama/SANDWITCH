using MediatR;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Queries.Arenal;

public class FindAllHistoricoByArenalIdQuery : IRequest<IList<ViewHistorico>>
{
    public int Id { get; set; }
}