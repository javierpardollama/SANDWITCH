using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Application.ViewModels.Updates;

/// <summary>
///     Represents a <see cref="UpdateBase" /> class.
/// </summary>
public abstract class UpdateBase
{
    /// <summary>
    ///     Gets or Sets <see cref="Id" />
    /// </summary>
    [Required]
    public int Id { get; set; }
}