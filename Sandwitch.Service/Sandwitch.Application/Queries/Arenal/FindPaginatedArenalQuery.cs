using MediatR;
using Sandwitch.Domain.ViewModels.Filters;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Queries.Arenal;

public class FindPaginatedArenalQuery : IRequest<ViewPage<ViewArenal>>
{
    public FilterPage ViewModel { get; set; }
}