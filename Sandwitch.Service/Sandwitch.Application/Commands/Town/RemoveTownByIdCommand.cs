using MediatR;

namespace Sandwitch.Application.Commands.Town;

/// <summary>
/// Represents a <see cref="RemoveTownByIdCommand" /> class. Inherits <see cref="IRequest" />
/// </summary>
public class RemoveTownByIdCommand : IRequest
{
    /// <summary>
    /// Gets or Sets <see cref="Id"/>
    /// </summary>
    public int Id { get; set; }
}