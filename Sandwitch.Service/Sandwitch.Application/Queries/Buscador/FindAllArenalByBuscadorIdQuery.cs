using MediatR;
using Sandwitch.Application.ViewModels.Finders;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Application.Queries.Buscador;

public class FindAllArenalByBuscadorIdQuery : IRequest<IList<ViewArenal>>
{
    public FinderArenal ViewModel { get; set; }
}