using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Application.ViewModels.Additions;

/// <summary>
///     Represents a <see cref="AddBandera" /> class.
/// </summary>
public class AddBandera
{
    /// <summary>
    ///     Initializes a new Instance of <see cref="AddBandera" />
    /// </summary>
    public AddBandera()
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