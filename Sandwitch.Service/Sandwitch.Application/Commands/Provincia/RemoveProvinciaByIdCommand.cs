using MediatR;

namespace Sandwitch.Application.Commands.Provincia;

public class RemoveProvinciaByIdCommand : IRequest
{
    public int Id { get; set; }
}