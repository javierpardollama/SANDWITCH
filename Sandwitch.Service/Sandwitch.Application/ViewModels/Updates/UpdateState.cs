using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Application.ViewModels.Updates;

/// <summary>
///     Represents a <see cref="UpdateState" /> class. Inherits <see cref="UpdateBase" />
/// </summary>
public class UpdateState : UpdateBase
{
    /// <summary>
    ///     Initializes a new Instance of <see cref="UpdateState" />
    /// </summary>
    public UpdateState()
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