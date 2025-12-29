using MediatR;

namespace Sandwitch.Application.Commands.Flag;

/// <summary>
/// Represents a <see cref="RemoveFlagByIdCommand" /> class. Inherits <see cref="IRequest" />
/// </summary>
public class RemoveFlagByIdCommand : IRequest
{
    /// <summary>
    /// Gets or Sets <see cref="Id"/>
    /// </summary>
    public int Id { get; set; }
}