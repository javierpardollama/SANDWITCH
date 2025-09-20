using MediatR;

namespace Sandwitch.Application.Commands.Viento;

/// <summary>
/// Represents a <see cref="RemoveVientoByIdCommand" /> class. Inherits <see cref="IRequest" />
/// </summary>
public class RemoveVientoByIdCommand : IRequest
{
    /// <summary>
    /// Gets or Sets <see cref="Id"/>
    /// </summary>
    public int Id { get; set; }
}