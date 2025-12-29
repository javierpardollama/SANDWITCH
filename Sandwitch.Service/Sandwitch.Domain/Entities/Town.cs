using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Domain.Entities;

/// <summary>
///     Represents a <see cref="Town" /> class. Inherits <see cref="Base" />
/// </summary>
public class Town : Base
{
    /// <summary>
    ///     Initializes a new Instance of <see cref="Town" />
    /// </summary>
    public Town()
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
    ///     Gets or Sets <see cref="StateId" />
    /// </summary>
    [Required]
    public int StateId { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="State" />
    /// </summary> 
    public State State { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="BeachTownes" />
    /// </summary>
    public virtual ICollection<BeachTown> BeachTowns { get; set; } = [];
}