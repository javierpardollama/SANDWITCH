using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Application.ViewModels.Additions;

/// <summary>
///     Represents a <see cref="AddState" /> class.
/// </summary>
public class AddState
{
    /// <summary>
    ///     Initializes a new Instance of <see cref="AddState" />
    /// </summary>
    public AddState()
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