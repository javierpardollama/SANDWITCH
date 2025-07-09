using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Domain.Entities;

/// <summary>
///     Represents a <see cref="Arenal" /> class. Inherits <see cref="Base" />
/// </summary>
public class Arenal : Base
{
    /// <summary>
    ///     Initializes a new Instance of <see cref="Arenal" />
    /// </summary>
    public Arenal()
    {
    }

    /// <summary>
    ///     Gets or Sets <see cref="Name" />
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="ArenalPoblaciones" />
    /// </summary>
    public virtual ICollection<ArenalPoblacion> ArenalPoblaciones { get; set; } = [];

    /// <summary>
    ///     Gets or Sets <see cref="Historicos" />
    /// </summary>
    public virtual ICollection<Historico> Historicos { get; set; } = [];
}