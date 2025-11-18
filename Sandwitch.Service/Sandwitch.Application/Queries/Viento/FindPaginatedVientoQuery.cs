using MediatR;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.ViewModels.Filters;

namespace Sandwitch.Application.Queries.Viento;

public class FindPaginatedVientoQuery : IRequest<ViewPage<ViewViento>>
{
    public FilterPage ViewModel { get; set; }
}