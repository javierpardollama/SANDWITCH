using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Domain.Entities;

/// <summary>
///     Represents a <see cref="ArenalPoblacion" /> class. Inherits <see cref="Base" />
/// </summary>
public class ArenalPoblacion : Base
{
    /// <summary>
    ///     Initializes a new Instance of <see cref="ArenalPoblacion" />
    /// </summary>
    public ArenalPoblacion()
    {
    }

    /// <summary>
    ///     Gets or Sets <see cref="Arenal" />
    /// </summary>
    [Required]
    public Arenal Arenal { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="Poblacion" />
    /// </summary>
    [Required]
    public Poblacion Poblacion { get; set; }
}