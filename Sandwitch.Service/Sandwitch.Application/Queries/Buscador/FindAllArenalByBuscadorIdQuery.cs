using MediatR;
using Sandwitch.Application.ViewModels.Finders;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Application.Queries.Finder;

public class FindAllBeachByFinderIdQuery : IRequest<IList<ViewBeach>>
{
    public FinderBeach ViewModel { get; set; }
}