using MediatR;

namespace Sandwitch.Application.Commands.Poblacion;

public class RemovePoblacionByIdCommand : IRequest
{
    public int Id { get; set; }
}