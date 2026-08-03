using MediatR;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Application.Queries.Finder;

public class FindAllFinderQuery : IRequest<IList<ViewFinder>>
{
}