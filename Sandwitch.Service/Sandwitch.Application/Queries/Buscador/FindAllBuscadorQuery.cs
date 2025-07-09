using MediatR;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Queries.Buscador;

public class FindAllBuscadorQuery : IRequest<IList<ViewBuscador>>
{
}