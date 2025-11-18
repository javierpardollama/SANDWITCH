using MediatR;
using Sandwitch.Application.ViewModels.Filters;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Application.Queries.Viento;

public class FindPaginatedVientoQuery : IRequest<ViewPage<ViewViento>>
{
    public FilterPage ViewModel { get; set; }
}