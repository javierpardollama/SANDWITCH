using MediatR;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Queries.Viento;

public class FindAllVientoQuery : IRequest<IList<ViewViento>>
{
}