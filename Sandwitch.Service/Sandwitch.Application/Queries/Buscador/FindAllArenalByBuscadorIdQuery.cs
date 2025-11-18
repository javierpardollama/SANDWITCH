using MediatR;
using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.ViewModels.Finders;

namespace Sandwitch.Application.Queries.Buscador;

public class FindAllArenalByBuscadorIdQuery : IRequest<IList<ViewArenal>>
{
    public FinderArenal ViewModel { get; set; }
}