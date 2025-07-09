using MediatR;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Queries.Arenal;

public class FindAllArenalQuery : IRequest<IList<ViewArenal>>
{
}