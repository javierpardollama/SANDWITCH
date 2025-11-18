using MediatR;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.ViewModels.Filters;

namespace Sandwitch.Application.Queries.Provincia;

public class FindPaginatedProvinciaQuery : IRequest<ViewPage<ViewProvincia>>
{
    public FilterPage ViewModel { get; set; }
}