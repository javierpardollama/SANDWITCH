using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Domain.ViewModels.Additions;

/// <summary>
///     Represents a <see cref="AddProvincia" /> class.
/// </summary>
public class AddProvincia
{
    /// <summary>
    ///     Initializes a new Instance of <see cref="AddProvincia" />
    /// </summary>
    public AddProvincia()
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