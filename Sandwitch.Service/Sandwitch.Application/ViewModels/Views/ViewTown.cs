namespace Sandwitch.Application.ViewModels.Views;

/// <summary>
///     Represents a <see cref="ViewTown" /> class. Inherits <see cref="ViewBase" />
/// </summary>
public class ViewTown : ViewBase
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
    ///     Gets or Sets <see cref="State" />
    /// </summary>   
    public ViewCatalog State { get; set; }  
}