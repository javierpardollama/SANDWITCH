namespace Sandwitch.Application.ViewModels.Views;

/// <summary>
///     Represents a <see cref="ViewBuscador" /> class. Inherits <see cref="ViewBase" />
/// </summary>
public class ViewBuscador : ViewBase
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
    ///     Gets or Sets <see cref="Type" />
    /// </summary>   
    public string Type { get; set; }
}