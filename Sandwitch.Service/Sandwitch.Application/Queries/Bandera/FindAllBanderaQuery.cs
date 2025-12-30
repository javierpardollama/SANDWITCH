using MediatR;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Application.Queries.Flag;

public class FindAllFlagQuery : IRequest<IList<ViewCatalog>>
{
}