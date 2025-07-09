using MediatR;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Queries.Provincia;

public class FindAllProvinciaQuery : IRequest<IList<ViewProvincia>>
{
}