using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Domain.Entities;

/// <summary>
///     Represents a <see cref="Provincia" /> class. Inherits <see cref="Base" />
/// </summary>
public class Provincia : Base
{
    /// <summary>
    ///     Initializes a new Instance of <see cref="Provincia" />
    /// </summary>
    public Provincia()
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
    ///     Gets or Sets <see cref="Poblaciones" />
    /// </summary>
    public virtual ICollection<Poblacion> Poblaciones { get; set; } = [];
}