using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Domain.ViewModels.Updates;

/// <summary>
///     Represents a <see cref="UpdateBandera" /> class. Inherits <see cref="UpdateBase" />
/// </summary>
public class UpdateBandera : UpdateBase
{
    /// <summary>
    ///     Initializes a new Instance of <see cref="UpdateBandera" />
    /// </summary>
    public UpdateBandera()
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
    [Url]
    public string ImageUri { get; set; }
}