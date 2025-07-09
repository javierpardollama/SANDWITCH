using MediatR;

namespace Sandwitch.Application.Commands.Bandera;

public class RemoveBanderaByIdCommand : IRequest
{
    public int Id { get; set; }
}