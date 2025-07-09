using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Domain.Entities;

/// <summary>
///     Represents a <see cref="Historico" /> class. Inherits <see cref="Base" />
/// </summary>
public class Historico : Base
{
    /// <summary>
    ///     Initializes a new Instance of <see cref="Historico" />
    /// </summary>
    public Historico()
    {
    }

    /// <summary>
    ///     Gets or Sets <see cref="Bandera" />
    /// </summary>
    [Required]
    public virtual Bandera Bandera { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="Viento" />
    /// </summary>
    [Required]
    public virtual Viento Viento { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="Arenal" />
    /// </summary>
    [Required]
    public virtual Arenal Arenal { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="Velocidad" />
    /// </summary>
    [Required]
    public double Velocidad { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="Temperatura" />
    /// </summary>
    [Required]
    public double Temperatura { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="BajaMarAlba" />
    /// </summary>
    [Required]
    public TimeSpan BajaMarAlba { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="BajaMarOcaso" />
    /// </summary>
    [Required]
    public TimeSpan BajaMarOcaso { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="AltaMarAlba" />
    /// </summary>
    [Required]
    public TimeSpan AltaMarAlba { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="AltaMarOcaso" />
    /// </summary>
    [Required]
    public TimeSpan AltaMarOcaso { get; set; }
}