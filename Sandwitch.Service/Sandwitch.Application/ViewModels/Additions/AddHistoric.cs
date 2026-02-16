using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Application.ViewModels.Additions;

/// <summary>
///     Represents a <see cref="AddHistoric" /> class.
/// </summary>
public class AddHistoric
{
    /// <summary>
    ///     Initializes a new Instance of <see cref="AddHistoric" />
    /// </summary>
    public AddHistoric()
    {
    }

    /// <summary>
    ///     Gets or Sets <see cref="BeachId" />
    /// </summary>
    [Required]
    public int BeachId { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="FlagId" />
    /// </summary>
    [Required]
    public int FlagId { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="WindId" />
    /// </summary>
    [Required]
    public int WindId { get; set; }

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