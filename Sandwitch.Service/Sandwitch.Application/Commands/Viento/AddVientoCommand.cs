using MediatR;
using Sandwitch.Domain.ViewModels.Additions;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Commands.Viento;

public class AddVientoCommand : IRequest<ViewViento>
{
    public AddViento ViewModel { get; set; }
}