using MediatR;
using Sandwitch.Application.ViewModels.Filters;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Application.Queries.Wind;

public class FindPaginatedWindQuery : IRequest<ViewPage<ViewWind>>
{
    public FilterPage ViewModel { get; set; }
}