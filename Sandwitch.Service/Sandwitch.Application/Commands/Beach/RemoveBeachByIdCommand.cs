using MediatR;

namespace Sandwitch.Application.Commands.Beach;

/// <summary>
/// Represents a <see cref="RemoveBeachByIdCommand" /> class. Inherits <see cref="IRequest" />
/// </summary>
public class RemoveBeachByIdCommand : IRequest
{
    /// <summary>
    /// Gets or Sets <see cref="Id"/>
    /// </summary>
    public int Id { get; set; }
}