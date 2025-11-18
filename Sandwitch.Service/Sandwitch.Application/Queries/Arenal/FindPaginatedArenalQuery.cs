using MediatR;
using Sandwitch.Application.ViewModels.Filters;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Application.Queries.Arenal;

public class FindPaginatedArenalQuery : IRequest<ViewPage<ViewArenal>>
{
    public FilterPage ViewModel { get; set; }
}