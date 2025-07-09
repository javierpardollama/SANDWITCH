using MediatR;
using Sandwitch.Domain.ViewModels.Additions;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Commands.Arenal;

public class AddArenalCommand : IRequest<ViewArenal>
{
    public AddArenal ViewModel { get; set; }
}