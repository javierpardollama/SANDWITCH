using MediatR;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Application.Queries.Poblacion;

public class FindAllPoblacionQuery : IRequest<IList<ViewCatalog>>
{
}