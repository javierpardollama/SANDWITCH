using MediatR;

namespace Sandwitch.Application.Commands.Wind;

/// <summary>
/// Represents a <see cref="RemoveWindByIdCommand" /> class. Inherits <see cref="IRequest" />
/// </summary>
public class RemoveWindByIdCommand : IRequest
{
    /// <summary>
    /// Gets or Sets <see cref="Id"/>
    /// </summary>
    public int Id { get; set; }
}