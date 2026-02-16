using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Domain.Entities;

/// <summary>
///     Represents a <see cref="Historic" /> class. Inherits <see cref="Base" />
/// </summary>
public class Historic : Base
{
    /// <summary>
    ///     Initializes a new Instance of <see cref="Historic" />
    /// </summary>
    public Historic()
    {
    }

    /// <summary>
    ///     Gets or Sets <see cref="FlagId" />
    /// </summary>
    [Required]
    public int FlagId { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="Flag" />
    /// </summary>
    public virtual Flag Flag { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="FlagId" />
    /// </summary>
    [Required]
    public int WindId { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="Wind" />
    /// </summary>   
    public virtual Wind Wind { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="FlagId" />
    /// </summary>
    [Required]
    public int BeachId { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="Beach" />
    /// </summary>  
    public virtual Beach Beach { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="Speed" />
    /// </summary>
    [Required]
    public double Speed { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="Temperature" />
    /// </summary>
    [Required]
    public double Temperature { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="LowSeaDawn" />
    /// </summary>
    [Required]
    public DateTime LowSeaDawn { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="LowSeaSunset" />
    /// </summary>
    [Required]
    public DateTime LowSeaSunset { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="HighSeaDawn" />
    /// </summary>
    [Required]
    public DateTime HighSeaDawn { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="HighSeaSunset" />
    /// </summary>
    [Required]
    public DateTime HighSeaSunset { get; set; }
}