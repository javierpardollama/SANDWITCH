using MediatR;

namespace Sandwitch.Application.Commands.Arenal;

/// <summary>
/// Represents a <see cref="RemoveArenalByIdCommand" /> class. Inherits <see cref="IRequest" />
/// </summary>
public class RemoveArenalByIdCommand : IRequest
{
    /// <summary>
    /// Gets or Sets <see cref="Id"/>
    /// </summary>
    public int Id { get; set; }
}