using MediatR;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Application.Queries.Bandera;

public class FindAllBanderaQuery : IRequest<IList<ViewCatalog>>
{
}