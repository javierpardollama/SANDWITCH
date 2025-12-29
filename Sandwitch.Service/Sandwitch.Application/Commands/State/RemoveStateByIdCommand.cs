using MediatR;

namespace Sandwitch.Application.Commands.State;

/// <summary>
/// Represents a <see cref="RemoveStateByIdCommand" /> class. Inherits <see cref="IRequest" />
/// </summary>
public class RemoveStateByIdCommand : IRequest
{
    /// <summary>
    /// Gets or Sets <see cref="Id"/>
    /// </summary>
    public int Id { get; set; }
}