using MediatR;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Application.Queries.Town;

public class FindAllTownQuery : IRequest<IList<ViewCatalog>>
{
}