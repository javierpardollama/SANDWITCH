using MediatR;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.ViewModels.Filters;

namespace Sandwitch.Application.Queries.Bandera;

public class FindPaginatedBanderaQuery : IRequest<ViewPage<ViewBandera>>
{
    public FilterPage ViewModel { get; set; }
}