using MediatR;
using Sandwitch.Domain.ViewModels.Updates;
using Sandwitch.Domain.ViewModels.Views;

namespace Sandwitch.Application.Commands.Bandera;

public class UpdateBanderaCommand : IRequest<ViewBandera>
{
    public UpdateBandera ViewModel { get; set; }
}