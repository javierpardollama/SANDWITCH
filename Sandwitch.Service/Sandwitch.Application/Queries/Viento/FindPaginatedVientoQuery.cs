using MediatR;
using Sandwitch.Domain.ViewModels.Filters;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Queries.Viento;

public class FindPaginatedVientoQuery : IRequest<ViewPage<ViewViento>>
{
    public FilterPage ViewModel { get; set; }
}