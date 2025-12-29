using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Application.ViewModels.Additions;

/// <summary>
///     Represents a <see cref="AddFlag" /> class.
/// </summary>
public class AddFlag
{
    /// <summary>
    ///     Initializes a new Instance of <see cref="AddFlag" />
    /// </summary>
    public AddFlag()
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