using MediatR;
using Sandwitch.Application.ViewModels.Filters;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Application.Queries.Bandera;

public class FindPaginatedBanderaQuery : IRequest<ViewPage<ViewBandera>>
{
    public FilterPage ViewModel { get; set; }
}