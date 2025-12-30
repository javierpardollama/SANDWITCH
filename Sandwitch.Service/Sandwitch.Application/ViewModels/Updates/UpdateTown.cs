using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Application.ViewModels.Updates;

/// <summary>
///     Represents a <see cref="UpdateTown" /> class. Inherits <see cref="UpdateBase" />
/// </summary>
public class UpdateTown : UpdateBase
{
    /// <summary>
    ///     Initializes a new Instance of <see cref="UpdateTown" />
    /// </summary>
    public UpdateTown()
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

    /// <summary>
    ///     Gets or Sets <see cref="StateId" />
    /// </summary>
    [Required]
    public int StateId { get; set; }
}