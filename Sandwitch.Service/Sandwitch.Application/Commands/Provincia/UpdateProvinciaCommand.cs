using MediatR;
using Sandwitch.Domain.ViewModels.Updates;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Commands.Provincia;

public class UpdateProvinciaCommand : IRequest<ViewProvincia>
{
    public UpdateProvincia ViewModel { get; set; }
}