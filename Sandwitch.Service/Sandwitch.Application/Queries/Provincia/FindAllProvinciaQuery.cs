using MediatR;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Application.Queries.Provincia;

public class FindAllProvinciaQuery : IRequest<IList<ViewCatalog>>
{
}