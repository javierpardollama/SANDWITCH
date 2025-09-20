using MediatR;

namespace Sandwitch.Application.Commands.Bandera;

/// <summary>
/// Represents a <see cref="RemoveBanderaByIdCommand" /> class. Inherits <see cref="IRequest" />
/// </summary>
public class RemoveBanderaByIdCommand : IRequest
{
    /// <summary>
    /// Gets or Sets <see cref="Id"/>
    /// </summary>
    public int Id { get; set; }
}