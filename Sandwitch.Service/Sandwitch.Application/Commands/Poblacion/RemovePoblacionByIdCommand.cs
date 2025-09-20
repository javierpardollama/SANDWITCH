using MediatR;

namespace Sandwitch.Application.Commands.Poblacion;

/// <summary>
/// Represents a <see cref="RemovePoblacionByIdCommand" /> class. Inherits <see cref="IRequest" />
/// </summary>
public class RemovePoblacionByIdCommand : IRequest
{
    /// <summary>
    /// Gets or Sets <see cref="Id"/>
    /// </summary>
    public int Id { get; set; }
}