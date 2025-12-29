using MediatR;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Application.Queries.Flag;

public class FindAllHistoricByFlagIdQuery : IRequest<IList<ViewHistoric>>
{
    public int Id { get; set; }
}