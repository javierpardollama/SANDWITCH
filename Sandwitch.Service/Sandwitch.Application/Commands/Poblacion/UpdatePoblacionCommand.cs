using MediatR;
using Sandwitch.Domain.ViewModels.Updates;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Commands.Poblacion;

public class UpdatePoblacionCommand : IRequest<ViewPoblacion>
{
    public UpdatePoblacion ViewModel { get; set; }
}