using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Tier.Entities.Classes;

/// <summary>
/// Represents a <see cref="Buscador"/> class. Inherits <see cref="Base"/>
/// </summary>
public partial class Buscador: Base
{
    /// <summary>
    /// Initializes a new Instance of <see cref="Historico"/>
    /// </summary>
    public Buscador()
    {
    }

    /// <summary>
    /// Gets or Sets <see cref="Name"/>
    /// </summary>
    [Required]
    public string Name { get; set; }
    
    /// <summary>
    /// Gets or Sets <see cref="ImageUri"/>
    /// </summary>
    [Required]
    public string ImageUri { get; set; }
    
    /// <summary>
    /// Gets or Sets <see cref="Name"/>
    /// </summary>
    [Required]
    public string Type { get; set; }
}