using MediatR;
using Sandwitch.Application.ViewModels.Filters;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Application.Queries.Poblacion;

public class FindPaginatedPoblacionQuery : IRequest<ViewPage<ViewPoblacion>>
{
    public FilterPage ViewModel { get; set; }
}