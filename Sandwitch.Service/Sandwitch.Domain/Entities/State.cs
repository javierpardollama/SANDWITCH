using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Domain.Entities;

/// <summary>
///     Represents a <see cref="State" /> class. Inherits <see cref="Base" />
/// </summary>
public class State : Base
{
    /// <summary>
    ///     Initializes a new Instance of <see cref="State" />
    /// </summary>
    public State()
    {
    }

    /// <summary>
    ///     Gets or Sets <see cref="Name" />
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="ImageUri" />
    /// </summary>
    [Required]
    public string ImageUri { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="Townes" />
    /// </summary>
    public virtual ICollection<Town> Towns { get; set; } = [];
}