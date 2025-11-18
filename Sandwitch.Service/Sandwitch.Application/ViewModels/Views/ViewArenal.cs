namespace Sandwitch.Application.ViewModels.Views;

/// <summary>
///     Represents a <see cref="ViewArenal" /> class. Inherits <see cref="ViewBase" />
/// </summary>
public class ViewArenal : ViewBase
{   
    /// <summary>
    /// Gets or Sets <see cref="Name"/>
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or Sets <see cref="Poblaciones"/>
    /// </summary>
    public virtual ICollection<ViewCatalog> Poblaciones { get; set; } = [];

    /// <summary>
    /// Gets or Sets <see cref="LastHistorico"/>
    /// </summary>
    public virtual ViewHistorico LastHistorico { get; set; }
}