using MediatR;
using Sandwitch.Domain.ViewModels.Additions;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Commands.Poblacion;

public class AddPoblacionCommand : IRequest<ViewPoblacion>
{
    public AddPoblacion ViewModel { get; set; }
}