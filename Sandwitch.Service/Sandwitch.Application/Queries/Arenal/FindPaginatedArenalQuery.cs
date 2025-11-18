using MediatR;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.ViewModels.Filters;

namespace Sandwitch.Application.Queries.Arenal;

public class FindPaginatedArenalQuery : IRequest<ViewPage<ViewArenal>>
{
    public FilterPage ViewModel { get; set; }
}