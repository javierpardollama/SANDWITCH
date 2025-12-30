using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Domain.Entities;

/// <summary>
///     Represents a <see cref="BeachTown" /> class. Inherits <see cref="Base" />
/// </summary>
public class BeachTown : Base
{
    /// <summary>
    ///     Initializes a new Instance of <see cref="BeachTown" />
    /// </summary>
    public BeachTown()
    {
    }

    /// <summary>
    ///     Gets or Sets <see cref="Beach" />
    /// </summary>
    [Required]
    public int BeachId { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="Beach" />
    /// </summary>    
    public Beach Beach { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="TownId" />
    /// </summary>
    [Required]
    public int TownId { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="Town" />
    /// </summary>   
    public Town Town { get; set; }
}