using MediatR;
using Sandwitch.Application.ViewModels.Filters;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Application.Queries.Flag;

public class FindPaginatedFlagQuery : IRequest<ViewPage<ViewFlag>>
{
    public FilterPage ViewModel { get; set; }
}