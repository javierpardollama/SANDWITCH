using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Domain.Entities;

/// <summary>
///     Represents a <see cref="Bandera" /> class. Inherits <see cref="Base" />
/// </summary>
public class Bandera : Base
{
    /// <summary>
    ///     Initializes a new Instance of <see cref="Bandera" />
    /// </summary>
    public Bandera()
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
    ///     Gets or Sets <see cref="Historicos" />
    /// </summary>
    public virtual ICollection<Historico> Historicos { get; set; } = [];
}