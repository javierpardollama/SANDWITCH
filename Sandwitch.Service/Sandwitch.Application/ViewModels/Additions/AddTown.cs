using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Application.ViewModels.Additions;

/// <summary>
///     Represents a <see cref="AddTown" /> class.
/// </summary>
public class AddTown
{
    /// <summary>
    ///     Initializes a new Instance of <see cref="AddTown" />
    /// </summary>
    public AddTown()
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