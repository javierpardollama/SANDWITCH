using MediatR;

namespace Sandwitch.Application.Commands.Arenal;

public class RemoveArenalByIdCommand : IRequest
{
    public int Id { get; set; }
}