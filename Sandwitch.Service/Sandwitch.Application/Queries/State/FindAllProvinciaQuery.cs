using MediatR;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Application.Queries.State;

public class FindAllStateQuery : IRequest<IList<ViewCatalog>>
{
}