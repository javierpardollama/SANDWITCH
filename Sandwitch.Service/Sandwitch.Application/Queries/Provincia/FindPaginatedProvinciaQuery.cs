using MediatR;
using Sandwitch.Application.ViewModels.Filters;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Application.Queries.State;

public class FindPaginatedStateQuery : IRequest<ViewPage<ViewState>>
{
    public FilterPage ViewModel { get; set; }
}