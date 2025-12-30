using MediatR;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Application.Queries.Wind;

public class FindAllWindQuery : IRequest<IList<ViewCatalog>>
{
}