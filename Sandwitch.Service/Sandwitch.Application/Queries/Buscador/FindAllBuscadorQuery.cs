using MediatR;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Application.Queries.Buscador;

public class FindAllBuscadorQuery : IRequest<IList<ViewBuscador>>
{
}