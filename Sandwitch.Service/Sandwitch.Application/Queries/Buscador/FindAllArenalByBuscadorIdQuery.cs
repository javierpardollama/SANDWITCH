using MediatR;
using Sandwitch.Domain.ViewModels.Finders;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Queries.Buscador;

public class FindAllArenalByBuscadorIdQuery : IRequest<IList<ViewArenal>>
{
    public FinderArenal ViewModel { get; set; }
}