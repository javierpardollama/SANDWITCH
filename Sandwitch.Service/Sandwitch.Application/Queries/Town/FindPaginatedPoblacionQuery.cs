using MediatR;
using Sandwitch.Application.ViewModels.Filters;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Application.Queries.Town;

public class FindPaginatedTownQuery : IRequest<ViewPage<ViewTown>>
{
    public FilterPage ViewModel { get; set; }
}