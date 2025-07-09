using MediatR;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Queries.Bandera;

public class FindAllBanderaQuery : IRequest<IList<ViewBandera>>
{
}