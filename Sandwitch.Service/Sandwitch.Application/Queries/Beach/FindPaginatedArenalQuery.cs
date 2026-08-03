using MediatR;
using Sandwitch.Application.ViewModels.Filters;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Application.Queries.Beach;

public class FindPaginatedBeachQuery : IRequest<ViewPage<ViewBeach>>
{
    public FilterPage ViewModel { get; set; }
}