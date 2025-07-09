using MediatR;
using Sandwitch.Domain.ViewModels.Filters;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Queries.Poblacion;

public class FindPaginatedPoblacionQuery : IRequest<ViewPage<ViewPoblacion>>
{
    public FilterPage ViewModel { get; set; }
}