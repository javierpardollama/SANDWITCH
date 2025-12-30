using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Application.ViewModels.Additions;

/// <summary>
///     Represents a <see cref="AddBeach" /> class.
/// </summary>
public class AddBeach
{
    /// <summary>
    ///     Initializes a new Instance of <see cref="AddBeach" />
    /// </summary>
    public AddBeach()
    {
    }

    /// <summary>
    ///     Gets or Sets <see cref="Name" />
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="TownsId" />
    /// </summary>
    [Required]
    public virtual IList<int> TownsId { get; set; }
}