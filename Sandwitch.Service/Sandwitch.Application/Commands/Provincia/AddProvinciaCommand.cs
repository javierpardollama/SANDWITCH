using MediatR;
using Sandwitch.Domain.ViewModels.Additions;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Commands.Provincia;

public class AddProvinciaCommand : IRequest<ViewProvincia>
{
    public AddProvincia ViewModel { get; set; }
}