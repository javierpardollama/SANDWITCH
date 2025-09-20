using MediatR;

namespace Sandwitch.Application.Commands.Provincia;

/// <summary>
/// Represents a <see cref="RemoveProvinciaByIdCommand" /> class. Inherits <see cref="IRequest" />
/// </summary>
public class RemoveProvinciaByIdCommand : IRequest
{
    /// <summary>
    /// Gets or Sets <see cref="Id"/>
    /// </summary>
    public int Id { get; set; }
}