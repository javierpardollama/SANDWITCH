using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Application.ViewModels.Updates;

/// <summary>
///     Represents a <see cref="UpdateBeach" /> class. Inherits <see cref="UpdateBase" />
/// </summary>
public class UpdateBeach : UpdateBase
{
    /// <summary>
    ///     Initializes a new Instance of <see cref="UpdateBeach" />
    /// </summary>
    public UpdateBeach()
    {
    }

    /// <summary>
    ///     Gets or Sets <see cref="Name" />
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="TownesId" />
    /// </summary>
    [Required]
    public virtual IList<int> TownesId { get; set; }
}