using MediatR;
using Sandwitch.Domain.ViewModels.Updates;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Commands.Arenal;

public class UpdateArenalCommand : IRequest<ViewArenal>
{
    public UpdateArenal ViewModel { get; set; }
}