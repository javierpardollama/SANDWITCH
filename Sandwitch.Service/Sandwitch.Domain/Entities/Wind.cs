using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Domain.Entities;

/// <summary>
///     Represents a <see cref="Wind" /> class. Inherits <see cref="Base" />
/// </summary>
public class Wind : Base
{
    /// <summary>
    ///     Initializes a new Instance of <see cref="Wind" />
    /// </summary>
    public Wind()
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
    ///     Gets or Sets <see cref="Historics" />
    /// </summary>
    public virtual ICollection<Historic> Historics { get; set; } = [];
}