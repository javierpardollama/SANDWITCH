using MediatR;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Queries.Poblacion;

public class FindAllPoblacionQuery : IRequest<IList<ViewPoblacion>>
{
}