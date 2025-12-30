namespace Sandwitch.Application.ViewModels.Views;

/// <summary>
///     Represents a <see cref="ViewFinder" /> class. Inherits <see cref="ViewBase" />
/// </summary>
public class ViewFinder : ViewBase
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
    ///     Gets or Sets <see cref="Group" />
    /// </summary>   
    public string Group { get; set; }
}