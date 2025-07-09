using MediatR;
using Sandwitch.Domain.ViewModels.Additions;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Commands.Bandera;

public class AddBanderaCommand : IRequest<ViewBandera>
{
    public AddBandera ViewModel { get; set; }
}