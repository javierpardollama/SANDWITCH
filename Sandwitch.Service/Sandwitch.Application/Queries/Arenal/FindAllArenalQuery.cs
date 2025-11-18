using MediatR;
using Sandwitch.Application.ViewModels.Views;

namespace Sandwitch.Application.Queries.Arenal;

public class FindAllArenalQuery : IRequest<IList<ViewCatalog>>
{
}