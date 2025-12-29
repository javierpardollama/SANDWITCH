using MediatR;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Application.Queries.Beach;

public class FindAllBeachQuery : IRequest<IList<ViewCatalog>>
{
}