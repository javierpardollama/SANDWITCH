using MediatR;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Application.Queries.Viento;

public class FindAllVientoQuery : IRequest<IList<ViewCatalog>>
{
}