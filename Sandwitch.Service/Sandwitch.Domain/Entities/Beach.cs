using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Domain.Entities;

/// <summary>
///     Represents a <see cref="Beach" /> class. Inherits <see cref="Base" />
/// </summary>
public class Beach : Base
{
    /// <summary>
    ///     Initializes a new Instance of <see cref="Beach" />
    /// </summary>
    public Beach()
    {
    }

    /// <summary>
    ///     Gets or Sets <see cref="Name" />
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="BeachTowns" />
    /// </summary>
    public virtual ICollection<BeachTown> BeachTowns { get; set; } = [];

    /// <summary>
    ///     Gets or Sets <see cref="Historics" />
    /// </summary>
    public virtual ICollection<Historic> Historics { get; set; } = [];
}