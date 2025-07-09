using MediatR;
using Sandwitch.Domain.ViewModels.Filters;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Queries.Provincia;

public class FindPaginatedProvinciaQuery : IRequest<ViewPage<ViewProvincia>>
{
    public FilterPage ViewModel { get; set; }
}