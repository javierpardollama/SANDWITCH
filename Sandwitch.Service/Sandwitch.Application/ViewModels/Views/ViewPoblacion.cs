namespace Sandwitch.Application.ViewModels.Views;

/// <summary>
///     Represents a <see cref="ViewPoblacion" /> class. Inherits <see cref="ViewBase" />
/// </summary>
public class ViewPoblacion : ViewBase
{
    /// <summary>
    ///     Gets or Sets <see cref="Name" />
    /// </summary>  
    public string Name { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="ImageUri" />
    /// </summary>   
    public string ImageUri { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="Provincia" />
    /// </summary>   
    public ViewCatalog Provincia { get; set; }  
}