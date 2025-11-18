using MediatR;
using Sandwitch.Application.ViewModels.Filters;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Application.Queries.Provincia;

public class FindPaginatedProvinciaQuery : IRequest<ViewPage<ViewProvincia>>
{
    public FilterPage ViewModel { get; set; }
}