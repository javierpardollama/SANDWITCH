using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Domain.Entities;

/// <summary>
///     Represents a <see cref="Poblacion" /> class. Inherits <see cref="Base" />
/// </summary>
public class Poblacion : Base
{
    /// <summary>
    ///     Initializes a new Instance of <see cref="Poblacion" />
    /// </summary>
    public Poblacion()
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
    ///     Gets or Sets <see cref="Provincia" />
    /// </summary>
    [Required]
    public Provincia Provincia { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="ArenalPoblaciones" />
    /// </summary>
    public virtual ICollection<ArenalPoblacion> ArenalPoblaciones { get; set; } = [];
}