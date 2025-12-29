namespace Sandwitch.Application.ViewModels.Views;

/// <summary>
///     Represents a <see cref="ViewBeach" /> class. Inherits <see cref="ViewBase" />
/// </summary>
public class ViewBeach : ViewBase
{   
    /// <summary>
    /// Gets or Sets <see cref="Name"/>
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or Sets <see cref="Towns"/>
    /// </summary>
    public virtual ICollection<ViewCatalog> Towns { get; set; } = [];

    /// <summary>
    /// Gets or Sets <see cref="LastHistoric"/>
    /// </summary>
    public virtual ViewHistoric LastHistoric { get; set; }
}