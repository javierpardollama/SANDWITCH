using MediatR;
using Sandwitch.Domain.ViewModels.Filters;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Queries.Bandera;

public class FindPaginatedBanderaQuery : IRequest<ViewPage<ViewBandera>>
{
    public FilterPage ViewModel { get; set; }
}