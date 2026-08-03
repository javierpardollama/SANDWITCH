using MediatR;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Application.Queries.Wind;

public class FindAllHistoricByWindIdQuery : IRequest<IList<ViewHistoric>>
{
    public int Id { get; set; }
}