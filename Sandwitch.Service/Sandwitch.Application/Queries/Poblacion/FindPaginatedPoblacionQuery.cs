using MediatR;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.ViewModels.Filters;

namespace Sandwitch.Application.Queries.Poblacion;

public class FindPaginatedPoblacionQuery : IRequest<ViewPage<ViewPoblacion>>
{
    public FilterPage ViewModel { get; set; }
}