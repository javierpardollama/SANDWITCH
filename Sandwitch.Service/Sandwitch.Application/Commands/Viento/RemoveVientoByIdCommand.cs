using MediatR;

namespace Sandwitch.Application.Commands.Viento;

public class RemoveVientoByIdCommand : IRequest
{
    public int Id { get; set; }
}