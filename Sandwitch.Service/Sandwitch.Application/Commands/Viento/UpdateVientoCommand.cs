using MediatR;
using Sandwitch.Domain.ViewModels.Updates;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Commands.Viento;

public class UpdateVientoCommand : IRequest<ViewViento>
{
    public UpdateViento ViewModel { get; set; }
}