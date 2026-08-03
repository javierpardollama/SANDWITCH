using MediatR;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Application.Queries.Beach;

public class FindAllHistoricByBeachIdQuery : IRequest<IList<ViewHistoric>>
{
    public int Id { get; set; }
}